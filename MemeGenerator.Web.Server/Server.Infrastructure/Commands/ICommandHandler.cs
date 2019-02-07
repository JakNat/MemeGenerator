using System.Threading.Tasks;

namespace Server.Infrastructure.Commands
{

    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
