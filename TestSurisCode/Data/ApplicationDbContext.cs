using Microsoft.EntityFrameworkCore;
using TestSurisCode.Models;

namespace TestSurisCode.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Pongo las entidades, modelos, aca, NO Olvidarme
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
