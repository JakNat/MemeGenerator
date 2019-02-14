using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MemeGenerator.Model.Dto;
using MemeGenerator.Model.ViewModels;

namespace MemeGenerator.Client.Services
{
    public interface IMemeService : IService
    {
        Task CreateMeme(string title, string upperText, string bottomText, BitmapImage bitmapImage);
        Task<List<MemeVM>> GetMemesByUserId();
        Task<MemeVM> GetMemesByTitle(string searchByNameProperty);
    }
}