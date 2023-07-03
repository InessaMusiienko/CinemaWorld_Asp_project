using CinemaWorld.Contacts;
using CinemaWorld.Data;
using CinemaWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext dbContext;

        public GenreService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<GenreViewModel>> AllGenresAsync()
        {
            return await dbContext.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            bool result = await dbContext.Genres
                .AnyAsync(g => g.Id == id);

            return result;
        }
    }
}
