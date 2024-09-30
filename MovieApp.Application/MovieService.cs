using MovieApp.Application.Interfaces;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly HttpClient _httpClient;

        public MovieService(IMovieRepository movieRepository, HttpClient httpClient)
        {
            _movieRepository = movieRepository;
            _httpClient = httpClient;
        }

        public async Task<Movie> GetMovieAsync(string title)
        {
            var response = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?i=tt3896198&apikey=a023f59a&t={title}");
            return JsonConvert.DeserializeObject<Movie>(response);
        }

        public async Task SaveMetadataAsync(MovieMetadata metadata)
        {
            await _movieRepository.AddAsync(metadata);
        }

        public async Task<List<MovieMetadata>> GetAllMetadataAsync()
        {
            return await _movieRepository.GetAllAsync();
        }
    }
}
