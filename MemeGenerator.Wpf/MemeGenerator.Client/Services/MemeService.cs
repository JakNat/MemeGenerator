using MemeGenerator.Client.Extensions;
using MemeGenerator.Client.Utils;
using MemeGenerator.Client.ViewModels;
using MemeGenerator.Model.Dto;
using MemeGenerator.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MemeGenerator.Client.Services
{
    public class MemeService : IMemeService
    {
        private readonly IRestClientApp _restClientApp;

        public MemeService(IRestClientApp restClientApp)
        {
            _restClientApp = restClientApp;
        }

        public async Task CreateMeme(string title, string upperText, string bottomText, BitmapImage bitmapImage)
        {
            var meme = new
            {
                title = title,
                upperText = upperText,
                bottomText = bottomText,
                image64 = bitmapImage.ToBase64()
            };

            dynamic client = await _restClientApp.Build();
            var result = await client.Memes.Post(meme);
        }

        public async  Task<MemeVM> GetMemesByTitle(string searchByNameProperty)
        {
            dynamic client = await _restClientApp.Build();
            var result = await client.Memes.Query(new { title = searchByNameProperty }).Get();

            foreach (var meme in result)
            {
                Console.WriteLine(user.name);
            }

            string image64 = result.image64;
            BitmapImage image = image64.ToBitmapImage();

            MemeVM meme = new MemeVM()
            {
                Image = image,
                Title = result.title
            };
            return meme;
        }

        public Task<List<MemeVM>> GetMemesByUserId()
        {
            throw new NotImplementedException();
        }
    }
}
