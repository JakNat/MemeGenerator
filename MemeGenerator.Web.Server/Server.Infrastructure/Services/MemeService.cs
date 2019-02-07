using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Server.Infrastructure.DTO;

namespace Server.Infrastructure.Services
{
    public class MemeService : IMemeService
    {
        public Task AddAsync(Guid memeId, string title, Image image)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MemeDto>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MemeDto> GetAsync(string title)
        {
            throw new NotImplementedException();
        }
    }
}
