using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aninamer.util
{
    internal static class DirectoryHelper
    {
        public static string CreatePackageDirectory(string workingDir, string resDirName)
        {
            string madeDir = string.Join("//", workingDir, resDirName);

            CreateDirectory(madeDir);

            return madeDir;
        }

        public static void CreateDirectory(string dirName)
        {
            Directory.CreateDirectory(dirName);
        }
    }
}
