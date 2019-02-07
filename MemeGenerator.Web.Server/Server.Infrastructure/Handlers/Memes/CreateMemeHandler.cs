using System.Threading.Tasks;
using Server.Infrastructure.Commands;
using Server.Infrastructure.Commands.Memes;

namespace Server.Infrastructure.Handlers.Memes
{
    public class CreateMemeHandler : ICommandHandler<CreateMeme>
    {
        public CreateMemeHandler()
        {

        }

        public Task HandleAsync(CreateMeme command)
        {
            throw new System.NotImplementedException();
        }
    }
}
