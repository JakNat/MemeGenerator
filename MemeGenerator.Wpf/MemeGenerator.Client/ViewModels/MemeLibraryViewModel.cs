using Caliburn.Micro;
using MemeGenerator.Client.Services;
using MemeGenerator.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemeGenerator.Client.ViewModels
{

    public class MemeLibraryViewModel : Screen
    {
        private readonly IMemeService _memeService;

        public MemeLibraryViewModel(IMemeService memeService)
        {
            _memeService = memeService;
        }

        private string _searchByNameProperty;
        private List<MemeVM> _memes;

        public List<MemeVM> Memes
        {
            get { return _memes; }
            set
            {
                _memes = value;
                NotifyOfPropertyChange(() => Memes);
            }
        }

        public string SearchByNameProperty
        {
            get { return _searchByNameProperty; }
            set
            {
                _searchByNameProperty = value;
                NotifyOfPropertyChange(() => SearchByNameProperty);
                NotifyOfPropertyChange(() => CanLoadMemeByTitle);
            }
        }

        #region Buttons

        /// <summary>
        /// button -> Load memes by user id 
        /// </summary>
        public async Task<List<MemeVM>> LoadMemeByUser()
        {
            Memes = await _memeService.GetMemesByUserId();
            return Memes;
        }

        /// <summary>
        /// button -> Load memes by typed tittle
        /// </summary>
        public async Task<List<MemeVM>> LoadMemeByTitle()
        {
            MemeVM meme = await _memeService.GetMemesByTitle(SearchByNameProperty);
            Memes = new List<MemeVM>() { meme };
            return Memes;
        }

        #endregion

        #region Validators

        /// <summary>
        /// turn on or off button -> Load memes by user id
        /// </summary>
        //public bool CanLoadMemeByUser
        //{
        //    get
        //    {
        //    }
        //}

        /// <summary>
        /// turn on or off button -> Load memes by typed tittle
        /// </summary>
        public bool CanLoadMemeByTitle
        {
            get
            {
                return !String.IsNullOrWhiteSpace(SearchByNameProperty);
            }
        }

        #endregion
    }
}
