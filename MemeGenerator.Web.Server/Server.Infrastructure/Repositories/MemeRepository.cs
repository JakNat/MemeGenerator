using Microsoft.EntityFrameworkCore;
using Server.Core.Domain;
using Server.Core.Repositories;
using Server.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class MemeRepository : IMemeRepository, ISqlRepository
    {
        private readonly ServerContext _context;

        public MemeRepository(ServerContext context)
        {
            _context = context;
        }

        public async Task<Meme> GetAsync(Guid id)
        {
            return await _context.Memes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Meme> GetAsync(string title)
        {
            return await _context.Memes.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<IEnumerable<Meme>> GetAllAsync()
        {
            return await _context.Memes.ToListAsync();
        }

        public async Task AddAsync(Meme meme)
        {
            await _context.Memes.AddAsync(meme);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Meme meme)
        {
            _context.Memes.Update(meme);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var meme = await GetAsync(id);
            _context.Memes.Remove(meme);
            await _context.SaveChangesAsync();
        }
    }
}
