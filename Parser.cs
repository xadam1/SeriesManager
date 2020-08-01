using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SeriesManager
{
    public class Parser
    {
        public List<string> ExtractEpNamesFromFile(string filePath)
        {
            // EXAMPLE: S02 E10 · Valar Morghulis

            var lines = File.ReadAllLines(filePath).Where(line => line.StartsWith("S") || line.StartsWith("s")).ToList();
            List<string> episodes = new List<string>();

            foreach (var line in lines)
            {
                var episode = line.Split('·');
                var epLabel= Regex.Replace(episode[0].Trim(), @"\s+", "");
                var epName = Regex.Replace(episode[1].Trim(), @"\s", "_");

                var epFullName = $"{epLabel}-{epName}";
                episodes.Add(epFullName);

            }

            return episodes;
        }


    }
}