using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Infrastructure.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
