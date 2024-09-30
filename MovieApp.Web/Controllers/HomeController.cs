using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;
using MovieApp.Domain.Entities;
using MovieApp.Web.Models;
using System.Diagnostics;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> GetMovie(string title)
        {
            var movie = await _movieService.GetMovieAsync(title);
            return Json(movie);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMetadata(string title, string userComment)
        {
            var metadata = new MovieMetadata { Title = title, UserComment = userComment };
            await _movieService.SaveMetadataAsync(metadata);
            return Ok();
        }

        public async Task<IActionResult> Index()
        {
            var metadataList = await _movieService.GetAllMetadataAsync();
            return View(metadataList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
