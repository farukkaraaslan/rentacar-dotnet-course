using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string AddFile(IFormFile file, string rootPath)
        {
            CreateRootDirectoryIfNotExists(rootPath);
            var imageExtension = Path.GetExtension(file.FileName);
            var imageName = Guid.NewGuid() + imageExtension;

            using var fileStream = File.Create(rootPath + imageName);

            file.CopyTo(fileStream);
            fileStream.Flush();

            return imageName;
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string UpdateFile(IFormFile file, string filePath, string rootPath)
        {
            DeleteFile(filePath);
            return AddFile(file, rootPath);
        }

        private void CreateRootDirectoryIfNotExists(string rootPath)
        {
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
        }
    }
}