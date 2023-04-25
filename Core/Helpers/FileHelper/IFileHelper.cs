using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string AddFile(IFormFile file, string rootPath);
        string UpdateFile(IFormFile file,string filPath, string rootPath);
        void DeleteFile(string filePath);
    }
}
