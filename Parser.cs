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
        private static List<string> _namelist = new List<string>();


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

            _namelist = episodes;
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

        public static bool RenameSubtitleFiles(string subtitleDir)
        {
            var files = Directory.GetFiles(subtitleDir).ToList();

            var regex = TryMatchRegexForFiles(files[0]);

            if (regex is null) { return false; }
            Console.WriteLine($"Regex for Subtitles: \'{regex}\'");

            foreach (var file in files)
            {
                FileInfo subtitle = new FileInfo(file);

                var extension = subtitle.Extension;

                var match = Regex.Match(subtitle.Name, regex.ToString()).Groups;
                var (seNum, epNum) = PadNamesIfNeeded(match);

                // Get new name for file
                var newName = _namelist.Count == 0 ? $"S{seNum}E{epNum}" : _namelist.Where(name => name.StartsWith($"S{seNum}E{epNum}")).ToString();
                var newLocation = $"{subtitleDir}\\{newName}{extension}";
                File.Move(subtitle.FullName,newLocation);
            }
            return true;
        }


        private static (string, string) PadNamesIfNeeded(GroupCollection match)
        {
            var seNum = match["se"].Value;
            var epNum = match["ep"].Value;

            // ... S3 E1 ... --> S03 E01
            seNum = seNum.Length == 1 ? seNum.PadLeft(2, '0') : seNum;
            epNum = epNum.Length == 1 ? epNum.PadLeft(2, '0') : epNum;

            return (seNum, epNum);
        }

        private static Regex TryMatchRegexForFiles(string file)
        {
            var regexs = new List<Regex>
            {
                new Regex(@".*[Ss](?<se>\d+)[Ee](?<ep>\d+).*"),                     // ... S3E1 ...
                new Regex(@".*[Ss](?<se>\d+)\s*[Ee](?<ep>\d+).*"),                  // ... S3 E1 ...
                new Regex(@".*(?<se>\d+)[xX](?<ep>\d+).*"),                         // ... 3x01 ...
                new Regex(@".*[Ss][Ee](?<se>\d+)[Ee][Pp](?<ep>\d+).*"),             // ... Se3Ep1 ...
                new Regex(@".*[Ss][Ee](?<se>\d+)\s*[Ee][Pp](?<ep>\d+).*"),          // ... Se3 Ep1 ...
                new Regex(@".*(?<se>\d+)\s*(?<ep>\d+).*"),                          // ... (0)3 01 ...
                new Regex(@".*[Ss]eason\s*(?<se>\d+)\s*[Ee]pisode\s*(?<ep>\d+).*"), // ... Season 3 Episode01 ...
                new Regex(@".*[Ss]EASON\s*(?<se>\d+)\s*[Ee]PISODE\s*(?<ep>\d+).*")  // ... SEASON 3 EPISODE01 ...
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


                // TODO REGEX TRY FROM SUBTITLES IN PARSER Parser.TryMatchRegex
                var lbl = Regex.Match(name, @".*[Ss](?<se>\d+)[Ee](?<ep>\d+).*").Groups[1].Value;   // S03E10

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