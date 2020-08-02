using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeriesManager
{
    public static class Parser
    {
        /// <summary>
        /// Loads episode names from given file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List of episode names in correct format</returns>
        public static List<string> ExtractEpNamesFromFile(string filePath)
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
        public static async Task<bool> RenameAndMoveEpisodes(List<string> episodes, List<string> epNames, ProgressBar progressBar)
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

        public static bool RenameSubtitleFiles(string subtitleDir, string regexStr = null)
        {
            var files = Directory.GetFiles(subtitleDir).ToList();

            var regex = TryMatchRegexForSubFiles(files[0]);
            if (regex is null)
            {
                MessageBox.Show("Unable to detect pattern in subtitles files.\n");
            }
            Console.WriteLine($"Regex for Subtitles: {regex}");

            return true;
        }


        private static Regex TryMatchRegexForSubFiles(string file)
        {
            var regexs = new List<Regex>
            {
                new Regex(@".*([Ss]\d+[Ee]\d+).*"),                     // ... S3E1 ...
                new Regex(@".*([Ss]\d+\s*[Ee]\d+).*"),                  // ... S3 E1 ...
                new Regex(@".*(\d+[xX]{0,1}\d+).*"),                    // ... 3x01 ...
                new Regex(@".*([Ss][Ee]\d+[Ee][Pp]\d+).*"),             // ... Se3Ep1 ...
                new Regex(@".*([Ss][Ee]\d+\s*[Ee][Pp]\d+).*"),          // ... Se3 Ep1 ...
                new Regex(@".*(\d+\s*\d+).*"),                          // ... (0)3 01 ...
                new Regex(@".*([Ss]eason\s*\d+\s*[Ee]pisode\s*\d+).*"), // ... Season 3 Episode01 ...
                new Regex(@".*([Ss]EASON\s*\d+\s*[Ee]PISODE\s*\d+).*")  // ... SEASON 3 EPISODE01 ...
            };


            foreach (var regex in regexs)
            {
                if (regex.IsMatch(file))
                {
                    return regex;
                }
            }

            return null;
        }

        private static Dictionary<string, string> GetNewNamesForEpisodes(List<string> episodes, List<string> epNames)
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