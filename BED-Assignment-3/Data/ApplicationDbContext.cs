using BED_Assignment_3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BED_Assignment_3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BEDAssign;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
              .HasKey(r => new { r.RoomNumber, r.Date });
            base.OnModelCreating(modelBuilder);
        }

    }
}