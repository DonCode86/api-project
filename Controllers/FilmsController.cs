using api_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly FilmContext _dbContext;

        public FilmsController(FilmContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: api/Films
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Film>>> GetFilms()
        {
            if (_dbContext.Films == null)
            {
                return NotFound();
            }
            return await _dbContext.Films.ToListAsync();
        }

        //GET: api/Films/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            if (_dbContext.Films == null)
            {
                return NotFound();
            }
            var film = await _dbContext.Films.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }
            return film;
        }

        //POST: api/Films
        [HttpPost]

        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            _dbContext.Films.Add(film);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilm), new {id=film.Id}, film);
        }

        //PUT: api/Films/5
        [HttpPut("{id}")]

        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(film).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            { 
                if(!FilmExists(id))
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

        private bool FilmExists(long id) 
        { 
            return (_dbContext.Films?.Any(e => e.Id== id)).GetValueOrDefault();
        }
    }
}
