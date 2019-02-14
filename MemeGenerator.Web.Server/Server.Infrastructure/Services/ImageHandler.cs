using Server.Infrastructure.Extensions;
using Server.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Server.Infrastructure.Services
{
    public class ImageHandler : IImageHandler
    {
        private readonly ImageStorageSettings _imageStorageSettings;

        public ImageHandler(ImageStorageSettings imageStorageSettings)
        {
            _imageStorageSettings = imageStorageSettings;
        }

        public void SaveImageToStorage(Image image, Guid id)
        {
            System.IO.Directory.CreateDirectory(_imageStorageSettings.StoragePath);
            var base64meme = image.ToBase64();
            File.WriteAllBytes(_imageStorageSettings.StoragePath + "\\" + id, Convert.FromBase64String(base64meme));
        }

        public Image GetImageFromStorage(Guid id)
        {
            var imageBytes =  File.ReadAllBytes($"{_imageStorageSettings.StoragePath}\\{id}");
            return imageBytes.ToImage();
        }
    }
}
