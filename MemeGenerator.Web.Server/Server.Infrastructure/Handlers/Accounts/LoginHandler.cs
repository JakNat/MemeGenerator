using Microsoft.Extensions.Caching.Memory;
using Server.Infrastructure.Commands;
using Server.Infrastructure.Commands.Accounts;
using Server.Infrastructure.Extensions;
using Server.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Server.Infrastructure.Handlers.Accounts
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService userService;
        private readonly IJwtHandler jwtHandler;
        private readonly IMemoryCache cache;

        public LoginHandler(IUserService userService, IJwtHandler jwtHandler,
                            IMemoryCache cache)
        {
            this.userService = userService;
            this.jwtHandler = jwtHandler;
            this.cache = cache;
        }

        public async Task HandleAsync(Login command)
        {
            await userService.LoginAsync(command.Email, command.Password);
            var user = await userService.GetAsync(command.Email);
            var jwt = jwtHandler.CreateToken(user.Id, user.Role);
            cache.SetJwt(command.TokenId, jwt);
        }
    }
}
