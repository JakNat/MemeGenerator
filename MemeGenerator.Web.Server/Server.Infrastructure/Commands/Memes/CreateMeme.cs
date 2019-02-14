using System;
using System.Drawing;

namespace Server.Infrastructure.Commands.Memes
{
    public class CreateMeme : AuthenticatedCommandBase
    {
        public string Title { get; set; }
        public string Image64 { get; set; }
        public string UpperText { get; set; }
        public string BottomText { get; set; }
    }
}
