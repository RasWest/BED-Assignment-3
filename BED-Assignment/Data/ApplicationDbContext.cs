using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BED_Assignment_3.Models;

namespace BED_Assignment_3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionn)
        {
            optionn.UseSqlServer("Data Source=127.0.0.1, 1433; Database=DAB2_1; User ID = sa; Password=Rasm223j. ; TrustServerCertificate=true; ApplicationIntent=ReadWrite; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasKey(r => new { r.RoomNumber, r.Date });
            base.OnModelCreating(modelBuilder);
        }
    }
}