using Server.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Services
{
    public interface IMemeService : IService
    {
        Task<MemeDto> GetAsync(string title);
        Task<IEnumerable<MemeDto>> BrowseAsync();
        Task AddAsync(Guid memeId, string title, Guid userId);
        Task<IEnumerable<MemeDto>> GetAllAsync();
    }
}
