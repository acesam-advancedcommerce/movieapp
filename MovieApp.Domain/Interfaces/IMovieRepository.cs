using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task AddAsync(MovieMetadata movie);
        Task<List<MovieMetadata>> GetAllAsync();
    }
}
