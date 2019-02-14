using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Server.Core.Domain;
using Server.Infrastructure.Commands;
using Server.Infrastructure.Commands.Memes;
using Server.Infrastructure.Extensions;
using Server.Infrastructure.Services;

namespace Server.Infrastructure.Handlers.Memes
{
    public class CreateMemeHandler : ICommandHandler<CreateMeme>
    {
        private readonly IMemeService _memeService;
        private readonly IImageHandler _imageHandler;

        public CreateMemeHandler(IMemeService memeService,
                                  IImageHandler imageHandler)
        {
            _memeService = memeService;
            _imageHandler = imageHandler;
        }

        public async Task HandleAsync(CreateMeme command)
        {
            var image = command.Image64.ToImage();
            var memeContent = MemeBuilder.GenerateMeme(image, command.UpperText, command.BottomText);
            var id = Guid.NewGuid();

            _imageHandler.SaveImageToStorage(memeContent, id);

            await _memeService.AddAsync(id,command.Title, command.UserId);
        }
    }
}
