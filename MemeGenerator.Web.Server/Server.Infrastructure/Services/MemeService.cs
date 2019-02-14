using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AutoMapper;
using Server.Core.Domain;
using Server.Core.Repositories;
using Server.Infrastructure.DTO;
using Server.Infrastructure.Extensions;

namespace Server.Infrastructure.Services
{
    public class MemeService : IMemeService
    {
        private readonly IMemeRepository _memeRepository;
        private readonly IMapper _mapper;
        private readonly IImageHandler _imageHandler;

        public MemeService(IMemeRepository memeRepository,
                            IMapper mapper, IImageHandler imageHandler)
        {
            _memeRepository = memeRepository;
            _mapper = mapper;
            _imageHandler = imageHandler;
        }

        public async Task AddAsync(Guid memeId, string title, Guid userId)
        {
            var meme = new Meme(memeId, title, userId);
            await _memeRepository.AddAsync(meme);
        }

        public async Task<IEnumerable<MemeDto>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MemeDto>> GetAllAsync()
        {
            var memes = await _memeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MemeDto>>(memes);
        }

        public async Task<MemeDto> GetAsync(string title)
        {
            var meme = await _memeRepository.GetAsync(title);
            var memeImage = _imageHandler.GetImageFromStorage(meme.Id);
            var memeDto = _mapper.Map<MemeDto>(meme);
            memeDto.Image64 = memeImage.ToBase64();
            return memeDto;
        }
    }
}
