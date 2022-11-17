using System;
using System.Collections.Generic;
using System.Linq;
using BED_Assignment_3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;


namespace BED_Assignment_3.Data
{
    public class MorgenmadsBuffetDBContext : IdentityDBContext
    {

        public DbSet<Resevation> Resevations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionn)
        {
            optionn.UseSqlServer("Data Source=127.0.0.1, 1433; Database=DAB2_1; User ID = sa; Password=Rasm223j. ; TrustServerCertificate=true; ApplicationIntent=ReadWrite; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resevation>().HasKey(r => new {r.RoomNumber, r.Date});
            base.OnModelCreating(modelBuilder);
        }
    }
}
