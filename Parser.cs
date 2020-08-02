using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeriesManager
{
    public class Parser
    {
        /// <summary>
        /// Loads episode names from given file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List of episode names in correct format</returns>
        public List<string> ExtractEpNamesFromFile(string filePath)
        {
            List<string> episodes = new List<string>();

            // EXAMPLE: S02 E10 · Valar Morghulis

            if (filePath is null) { return episodes; }

            var lines = File.ReadAllLines(filePath).Where(line => line.StartsWith("S") || line.StartsWith("s")).ToList();

            foreach (var line in lines)
            {
                var episode = line.Split('·');
                var epLabel = Regex.Replace(episode[0].Trim(), @"\s+", "");
                var epName = Regex.Replace(episode[1].Trim(), @"\s", "_");

                var epFullName = $"{epLabel}-{epName}";
                episodes.Add(epFullName);

            }

            return episodes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="episodes"></param>
        /// <param name="epNames"></param>
        /// <param name="progressBar"></param>
        /// <returns></returns>
        public async Task<bool> RenameAndMoveEpisodes(List<string> episodes, List<string> epNames, ProgressBar progressBar)
        {
            var newNames = GetNewNamesForEpisodes(episodes, epNames);
            if (newNames is null) { return false; }

            foreach (var episode in newNames)
            {
                new System.IO.FileInfo($"{episode.Value}").Directory?.Create();
                await Task.Run(() => File.Move(episode.Key, episode.Value));

                progressBar.PerformStep();
            }

            return true;
        }


        private Dictionary<string, string> GetNewNamesForEpisodes(List<string> episodes, List<string> epNames)
        {
            var result = new Dictionary<string, string>();
            // EP FORMAT: "C:\Users\honza\Downloads\test\Game.Of.Thrones.S03E01[1080p].mkv"
            foreach (var episode in episodes)
            {
                FileInfo epInfo = new FileInfo(episode);
                
                var name = epInfo.Name;     // Game.Of.Thrones.S03E10[1080p].mkv

                var epExtension = epInfo.Extension;     // .mkv

                var lbl = Regex.Match(name, @".*([Ss]\d+[Ee]\d+).*").Groups[1].Value;   // S03E10

                //Regex.Match(epNam, $"{lbl}-"))
                var regex = new Regex($"{lbl}-");
                var matches = epNames.Where(l => regex.IsMatch(l)).ToList();
                string newName;
                if (matches.Count == 0)
                {
                    var res = MessageBox.Show(
                        $"Episode Name NOT Found!\n\nTrying to find {lbl} in Episode Name List...\n\nIf you press 'OK' default name will be used.",
                        "EP NAME NOT FOUND", MessageBoxButtons.OKCancel);

                    if (res == DialogResult.Cancel) { return null; }

                    newName = lbl;
                }
                else
                {
                    newName = matches[0];
                }

                newName = $"{epInfo.Directory.FullName}\\{newName}\\{newName}{epExtension}";
                result.Add(episode, newName);
            }

            return result;
        }
    }
}