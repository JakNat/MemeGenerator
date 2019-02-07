using Server.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Repositories
{
    public interface IMemeRepository
    {
        Task<Meme> GetAsync(Guid id);
        Task<Meme> GetAsync(string title);
        Task<IEnumerable<Meme>> GetAllAsync();
        Task AddAsync(Meme user);
        Task UpdateAsync(Meme user);
        Task RemoveAsync(Meme id);
    }
}
