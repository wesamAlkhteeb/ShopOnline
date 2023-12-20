using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;


namespace ShopOnline.API.Domain.ImageHelper
{
    public class ImageHelper
    {
        public static ImageHelper Instance { get; private set; } = new ImageHelper();
        private ImageHelper() { }

        public async Task<string> StoreImageWithManyDemonission(IFormFile file, string nameFile = "", string nameFolder = "")
        {

            if (string.IsNullOrEmpty(nameFile))
            {
                nameFile = GenerateName(file);
            }
            string[] pathes = GetPathesImage(nameFile);

            await StoreImage(file, nameFolder, pathes[0], 25, 25);
            await StoreImage(file, nameFolder, pathes[1], 60, 60);
            await StoreImage(file, nameFolder, pathes[2], -1, -1);
            return nameFile;
        }

        public string[] GetPathesImage(string path)
        {
            string name = SplitName(path), extension = Path.GetExtension(path);
            return new string[]
            {
                $"{name}-small"+extension,
                $"{name}-medium"+extension,
                $"{name}-large"+extension
            };
        }

        private async Task<string> StoreImage(IFormFile file, string nameFolder = "", string nameFile = "", int widthPercent = -1, int hightPercent = -1)
        {
            string path = BuildPath(nameFolder);
            path = Path.Combine(path, nameFile);
            Image image = BuildImage(file, widthPercent, hightPercent);
            await image.SaveAsync(path);

            return path.Replace("\\", "/");
        }
        public async Task UpdateImageProcess(string oldPath, IFormFile file, string nameFolder = "", int widthPercent = -1, int hightPercent = -1)
        {
            DeleteImageProcees(oldPath, nameFolder);
            await StoreImageWithManyDemonission(file, oldPath, nameFolder);
        }
        public void DeleteImageProcees(string path, string nameFolder = "")
        {
            string dir = "wwwroot/";
            if (!string.IsNullOrEmpty(nameFolder))
            {
                dir += nameFolder + "/";
            }
            string[] pathes = GetPathesImage(path);
            foreach (var pathh in pathes)
            {
                var p = dir + pathh;
                File.Delete(p);
            }
        }

        private string GetNameFileFromPath(string path)
        {
            string[] sp = path.Split('/');
            return sp.Last();
        }

        private Image BuildImage(IFormFile file, int widthPercent = -1, int hightPercent = -1)
        {
            Image image = Image.Load(file.OpenReadStream());
            if (widthPercent > 0 && hightPercent > 0)
            {
                int newWidth = image.Width * widthPercent / 100,
                newHeiht = image.Height * hightPercent / 100;
                image.Mutate(img => img.Resize(new ResizeOptions
                {
                    Size = new Size(newWidth, newHeiht),
                }));

            }
            return image;
        }
        private string BuildPath(string nameFolder)
        {
            if (string.IsNullOrEmpty(nameFolder))
            {
                return "wwwroot";
            }
            string fullpath = Path.Combine("wwwroot", nameFolder);
            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }
            return fullpath;
        }
        private string GenerateName(IFormFile file)
        {
            string name = SplitName(file.FileName), extension = Path.GetExtension(file.FileName);
            return name + DateTime.Now.GetHashCode() + new Random().Next(100) + extension;
        }
        private string SplitName(string nameFile)
        {
            string[] np = nameFile.Split(".");
            string name = string.Empty;
            string[] splitNameFile = np[0].Split(" ");
            foreach (var b in splitNameFile)
            {
                name += b;
            }
            return name;
        }
    }
}
