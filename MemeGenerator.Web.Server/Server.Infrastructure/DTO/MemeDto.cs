using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Server.Infrastructure.DTO
{
    public class MemeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image64 { get; set; }
    }
}
