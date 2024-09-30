using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces;
using MovieApp.Infrastructure.Data;

namespace MovieApp.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MovieMetadata movieMetadata)
        {
            await _context.MovieMetadata.AddAsync(movieMetadata);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MovieMetadata>> GetAllAsync()
        {
            return await _context.MovieMetadata.ToListAsync();
        }
    }
}
