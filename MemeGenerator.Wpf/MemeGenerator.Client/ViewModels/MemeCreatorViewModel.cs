using Caliburn.Micro;
using MemeGenerator.Model.Dto;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using MemeGenerator.Client;
using MemeGenerator.Model;
using MemeGenerator.Client.Utils;
using NetworkCommsDotNet;
using MemeGenerator.Client.Services;
using System.IO;
using System.Drawing.Imaging;

namespace MemeGenerator.Client.ViewModels
{
    public class MemeCreatorViewModel : Screen
    {

        private readonly IMemeService _memeService;
        public MemeCreatorViewModel(IMemeService memeService)
        {
            _memeService = memeService;
        }

        #region private properties
        private string _topText;
        private string _bottomText;
        private BitmapImage _image;
        private string _title;
        #endregion

        #region public properties
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public string TopText
        {
            get { return _topText; }
            set
            {
                _topText = value;
                NotifyOfPropertyChange(() => TopText);
            }
        }

        public string BottomText
        {
            get { return _bottomText; }
            set
            {
                _bottomText = value;
                NotifyOfPropertyChange(() => BottomText);
            }
        }

        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                NotifyOfPropertyChange(() => Image);
                NotifyOfPropertyChange(() => CanCreateByServer);
            }
        }
        #endregion
                
        #region Buttons
        /// <summary>
        /// button -> sending your new meme properties to a server
        /// </summary>
        public async Task CreateByServer()
        {
            await _memeService.CreateMeme(Title, TopText, BottomText, Image);
        }


        /// <summary>
        /// button -> select image to generate your new meme
        /// </summary>
        public void UploadImage()
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
            };
            if (op.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(op.FileName));
            }
        }
        #endregion

        #region Validators
        /// <summary>
        /// Validator -> "Generetae Meme" button
        /// </summary>
        public bool CanCreateByServer
        {
            get { return Image != null; }
        }
        #endregion
    }
}
