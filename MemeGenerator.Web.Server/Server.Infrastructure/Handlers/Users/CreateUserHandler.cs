using System;
using System.Threading.Tasks;
using Server.Infrastructure.Commands;
using Server.Infrastructure.Commands.Users;
using Server.Infrastructure.Services;

namespace Server.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email,
                command.UserName, command.Password /*,command.Role*/);
        }
    }
}
