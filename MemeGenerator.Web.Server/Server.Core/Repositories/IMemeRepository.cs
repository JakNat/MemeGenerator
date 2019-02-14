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
        Task AddAsync(Meme meme);
        Task UpdateAsync(Meme meme);
        Task RemoveAsync(Guid id);
    }
}
