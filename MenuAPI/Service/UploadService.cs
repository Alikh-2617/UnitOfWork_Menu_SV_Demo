using Microsoft.AspNetCore.Hosting;

namespace MenuAPI.Service
{
    public class UploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<UploadService> _logger;

        public UploadService(IWebHostEnvironment webHostEnvironment , ILogger<UploadService> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        public bool upload(IFormFile file , out string filename)
        {
            filename = file.FileName;
            try
            {
                string path = _webHostEnvironment.WebRootPath + "\\Pic\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }
            return false;
        }
        public bool download(string fileName , out byte[] file)
        {
            string path = _webHostEnvironment.WebRootPath + "\\Pic\\";
            var filePath = path + fileName;
            if (!System.IO.File.Exists(filePath))
            {
                file = new byte[0]; 
                return false;
            }
            file = System.IO.File.ReadAllBytes(filePath);
            return true;
        }

        public string upload(IFormFile file)
        {
            try
            {
                string path = _webHostEnvironment.WebRootPath + "\\Pic\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return file.Name;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }
            return "Item have not pic";
        }

        public byte[] download(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\Pic\\";
            var filePath = path + fileName;
            if (!System.IO.File.Exists(filePath))
            {
                return new byte[0];
            }
            byte[] file = System.IO.File.ReadAllBytes(filePath);
            return file;
        }

        public string SavePic(IFormFile image)
        {
            // för att kunna ha unika name för bilder
            string imageName = new string(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmss") + Path.GetExtension(image.FileName);
            var imagePath = _webHostEnvironment.WebRootPath + "\\Pic\\";

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            using (FileStream fileStream = System.IO.File.Create(imagePath + imageName))
            {
                image.CopyTo(fileStream);
                fileStream.Flush();
                return imageName;
            }
        }
    }
}
