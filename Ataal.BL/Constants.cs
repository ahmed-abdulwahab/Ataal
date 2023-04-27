using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ataal.BL;

public static class Constants
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string Technical = "Technical";
    }

    public static class DealWithImages
    {

        private static IWebHostEnvironment _env;

        public static void Initialize(IWebHostEnvironment env)
        {
            _env = env;
        }

        public static async Task<string?> ReturnImagePath(IFormFile File)
        {
            if (File != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(File.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath, fileName);

                // Save the image to disk
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
                return fileName;
            }
            return null;

        }
        public static void DeleteFile(string fileName)
        {
            var path = Path.Combine("wwwroot", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }



    }
}
