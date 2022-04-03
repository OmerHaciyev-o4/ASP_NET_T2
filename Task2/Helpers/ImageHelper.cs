using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Task2.Helpers
{
    public class ImageHelper
    {
        private readonly IWebHostEnvironment _environment;

        public ImageHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string SaveFile(IFormFile file)
        {
            var imgUrl = Path.Combine(_environment.WebRootPath, "images", file.FileName);

            using (var img = new FileStream(imgUrl, FileMode.Create))
            {
                file.CopyTo(img);
            }
            return file.FileName;
        }
    }
}