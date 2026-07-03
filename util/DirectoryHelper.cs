using System.IO;

namespace Aninamer.util
{
    /// <summary>
    /// 
    /// </summary>
    internal static class DirectoryHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingDir"></param>
        /// <param name="resDirName"></param>
        /// <returns></returns>
        public static string CreatePackageDirectory(string workingDir, string resDirName)
        {
            string madeDir = Path.Combine(workingDir, resDirName);

            CreateDirectory(madeDir);

            return madeDir;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirName"></param>
        public static void CreateDirectory(string dirName)
        {
            Directory.CreateDirectory(dirName);
        }
    }
}
