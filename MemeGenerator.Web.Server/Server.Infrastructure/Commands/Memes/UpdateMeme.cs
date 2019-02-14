using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Infrastructure.Commands.Memes
{
    public class UpdateMeme : AuthenticatedCommandBase
    {
        public string Title { get; set; }
    }
}
