using Microsoft.AspNetCore.Mvc;

namespace MoviesCategoryAPIEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DataContext _context;

        public MovieController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get(int categoryId, string name)
        {
            var movies = await _context.Movies
                .Where(c => c.CategoryId == categoryId)
                .Include(c =>c.Name == name)
                .ToListAsync();

            return movies;
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> Create(CreateMovieDto request)
        {
            var category = await _context.Categories.FindAsync(request.CategoryId);
            if (category == null)
                return NotFound();

            var newMovie = new Movie { 
                Category = category,
                Name = request.Name
            };
            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();

            return await Get(newMovie.CategoryId);

        }  
    }
}
