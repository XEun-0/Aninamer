using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aninamer.util
{
    internal static class FileHelper
    {
        public static AnimeFile CreateAnimeFile(string startPath, string fileDir, string fileExt, int startIdx)
        {
            return new AnimeFile(startPath, fileDir, fileExt, startIdx);
        }

        public static string SanitizeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c.ToString(), "");
            }
            return name;
        }
    }

    // Just a struct to organize the contents of the episodes
    public struct AnimeFile
    {
        // Immutable after construction
        public readonly string  FilePath;
        public readonly string  FileDir;
        public readonly string  FileExt;
        public readonly int     StartingIdx;

        // Mutable
        public string   CurrentFileRef { get; set; }
        public string   TargetFilePath { get; set; }
        public int      CurrIdx { get; set; }

        public AnimeFile(string filePath, string fileDir, string fileExt, int startingIdx)
        {
            FilePath    = filePath;
            FileDir     = fileDir;
            FileExt     = fileExt;
            StartingIdx = startingIdx;

            // Initialize mutable fields too (required)
            CurrentFileRef  = filePath;
            CurrIdx         = startingIdx;
            TargetFilePath  = filePath;
        }

        // Override ToString for readonly fields only
        public override string ToString()
        {
            return $"FilePath: {FilePath}\nFileDir: {FileDir}\nFileExt: {FileExt}\nStartingIdx: {StartingIdx}\n";
        }
    }
}
