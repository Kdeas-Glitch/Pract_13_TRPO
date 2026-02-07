using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_12.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Students { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=Demin_04;User Id = student_04; Password = student_04;TrustServerCertificate = True; ");
            //optionsBuilder.UseSqlServer("Server = localhost; Database = Demin_04; Trusted_Connection = True; User Id = student_04; Password = student_04;TrustServerCertificate = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(s => s.UserProfile)
                .WithOne(ps => ps.User)
                .HasForeignKey<UserProfile>(ps => ps.Id);

        }
    }
}
