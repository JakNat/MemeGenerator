using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Api.Controllers;
using Server.Infrastructure.Commands;
using Server.Infrastructure.Commands.Accounts;
using Server.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICommandDispatcher _commandDispatcher;

        public LoginController(ICommandDispatcher commandDispatcher,
                                IMemoryCache memoryCache) : base(commandDispatcher)
        {
            _memoryCache = memoryCache;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Login command)
        {
            command.TokenId = Guid.NewGuid();
            await _commandDispatcher.DispatchAsync(command);
            var token = _memoryCache.GetJwt(command.TokenId);
            return Json(token);
        }
    }
}
