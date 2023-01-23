using Microsoft.EntityFrameworkCore;

namespace api_project.Models
{
    public class FilmContext : DbContext
    {
        public FilmContext (DbContextOptions<FilmContext> options) : base(options) 
        { 
        }

        DbSet<Film> Films { get; set; } = null!;
    }
}
