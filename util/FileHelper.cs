using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aninamer.util
{
    internal static class FileHelper
    {
        public static EpisodeFile CreateAnimeFile(string startPath, string fileDir, string fileExt, int startIdx)
        {
            return new EpisodeFile(startPath, fileDir, fileExt, startIdx);
        }

        public static string SanitizeFileName(string name, string dateString = "(xxxx)")
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c.ToString(), "");
            }

            if (name.Contains(dateString))
            {
                name = name.Replace(dateString, "");
                name = Regex.Replace(name, @"\s+", " ").Trim();
            }

            return name;
        }

        public static int? ExtractEpisodeNumber(string name, int maxEpisodes)
        {
            var candidates = new List<(int num, int score)>();

            foreach (Match m in Regex.Matches(name, @"\d+"))
            {
                int n = int.Parse(m.Value);
                int score = 0;

                if (m.Index > name.LastIndexOf('-')) score += 40;
                if (m.Index + m.Length == name.Length) score += 30;
                if (n < 200) score += 20;
                if (n <= maxEpisodes + 5) score += 50;

                candidates.Add((n, score));
            }

            return candidates
                .OrderByDescending(c => c.score)
                .FirstOrDefault().num;
        }

    }

    // Just a struct to organize the contents of the episodes
    public struct EpisodeFile
    {
        // Immutable after construction
        public readonly string FilePath;
        public readonly string FileDir;
        public readonly string FileExt;
        public readonly int StartingIdx;

        // Mutable
        public string CurrentFileRef { get; set; }
        public string TargetFilePath { get; set; }
        public int CurrIdx { get; set; }

        public EpisodeFile(string filePath, string fileDir, string fileExt, int startingIdx)
        {
            FilePath = filePath;
            FileDir = fileDir;
            FileExt = fileExt;
            StartingIdx = startingIdx;

            // Initialize mutable fields too (required)
            // Mutable fields need to be changed
            CurrentFileRef = "";
            CurrIdx = -1;
            TargetFilePath = "";
        }

        // Override ToString for readonly fields only
        public override string ToString()
        {
            return $"FilePath: {FilePath}\nFileDir: {FileDir}\nFileExt: {FileExt}\nStartingIdx: {StartingIdx}\n";
        }
    }
}
