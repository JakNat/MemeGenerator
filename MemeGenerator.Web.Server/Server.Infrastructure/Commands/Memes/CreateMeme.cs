using System.Drawing;

namespace Server.Infrastructure.Commands.Memes
{
    public class CreateMeme : ICommand
    {
        public string Title { get; set; }
        public Image Image { get; set; }
        public string UpperText { get; set; }
        public string BottomText { get; set; }
    }
}
