using Microsoft.EntityFrameworkCore;
using MyFilmListWeb.Models;

namespace MyFilmListWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Film> Films { get; set; }
    }
}
