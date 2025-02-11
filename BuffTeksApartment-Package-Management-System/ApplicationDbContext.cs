using Microsoft.EntityFrameworkCore;

namespace BuffTeksApartment
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Package> Packages { get; set; }
        public DbSet<Resident> Residents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=apartment.db");
        }

        
        }
    }
