using P01.Logger.Models.Contracts;
using System;
using System.IO;

namespace P01.Logger.Models.PathManagment
{
    public class PathManager : IPathManager
    {
        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        // Tells me the path where my app is running on my PC
        private PathManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        // They should pass folder name and file name
        public PathManager(string folderName, string fileName)
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath => Path.Combine(this.currentPath, this.folderName);

        public string CurrentFilePath => Path.Combine(this.CurrentDirectoryPath, this.fileName);

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.AppendAllText(this.CurrentFilePath, String.Empty);
        }
    }
}
