using System;
using System.Drawing;

namespace Server.Infrastructure.Services
{
    public interface IImageHandler
    {
        Image GetImageFromStorage(Guid id);
        void SaveImageToStorage(Image image, Guid id);
    }
}