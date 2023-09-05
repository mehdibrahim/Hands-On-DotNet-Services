using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using System.IO;

namespace SchoolAPI.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<School> Schools { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasData(
                new School
                {

                    Id = 1,
                    Name = "ENISo",
                    Sections = "IA,GTE,GMP",
                    Director = "Ali Douik",
                    Rating = 3.5,
                    WebSite = "http://www.eniso.rnu.tn"
                },
                new School
                {

                Id = 2,
                    Name = "ENIM",
                    Sections = "Mécanique,énergitique,textile",
                    Director = "Mohamed Salah",
                    Rating = 2.8
                   
                },
                 new School
                 {

                     Id = 3,
                     Name = "ENIT",
                     Sections = "Télécom,Info,Indus",
                     Director = "Ali Salah",
                     Rating = 4,
                     WebSite = "http://www.enit.rnu.tn"
                 }
             );
        }
    }
}
