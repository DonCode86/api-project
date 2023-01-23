using api_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly FilmContext _dbContext;

        public GenresController(FilmContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: api/Genres
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            if (_dbContext.Genres == null)
            {
                return NotFound();
            }
            return await _dbContext.Genres.ToListAsync();
        }

        //GET: api/Genres/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            if (_dbContext.Genres == null)
            {
                return NotFound();
            }
            var genre = await _dbContext.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        //POST: api/Genres
        [HttpPost]

        public async Task<ActionResult<Genre>> PostFilm(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
        }

        //PUT: api/Genres/5
        [HttpPut("{id}")]

        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(genre).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool GenreExists(long id)
        {
            return (_dbContext.Genres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

