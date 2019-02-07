using Server.Infrastructure.Commands;
using Server.Infrastructure.Commands.Users;
using Server.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Server.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        private readonly IUserService userService;

        public ChangeUserPasswordHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public Task HandleAsync(ChangeUserPassword command)
        {
            //userService.ChangePasswordAsync()
            throw new NotImplementedException();
        }
    }
}
