using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public static class FileExtensions
    {

        public const string ChefImagesPath = "chefimages";

        public static async Task<string> SaveAndProvideUrlAsync(this IFormFile file,IWebHostEnvironment env,string imagesPath)
        {
            var rootFolder = env.WebRootPath;

            var folderPath = Path.Combine(rootFolder, imagesPath);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var newFileName = Guid.NewGuid() + file.FileName;

            var newFilePath = Path.Combine(folderPath, newFileName);

            using (var newFile = File.Create(newFilePath))
            {
                await file.CopyToAsync(newFile);
            }

            return Path.Combine(imagesPath, newFileName);
        }

    }
}
