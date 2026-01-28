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
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=Demin_04;User Id = student_04; Password = student_04;TrustServerCertificate = True; ");
        }
    }
}
