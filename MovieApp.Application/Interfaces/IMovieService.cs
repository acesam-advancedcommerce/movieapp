using MovieApp.Domain.Entities;

namespace MovieApp.Application.Interfaces
{
    public interface IMovieService
    {
        Task<Movie> GetMovieAsync(string title);
        Task SaveMetadataAsync(MovieMetadata movieMetadata);
        Task<List<MovieMetadata>> GetAllMetadataAsync();
    }
}
