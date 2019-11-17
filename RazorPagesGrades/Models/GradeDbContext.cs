using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesGrades.Models
{
    public class GradeDbContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public GradeDbContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GradeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subject>().HasData(new Subject { Acronym = "MAT", Name = "Matematika" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Acronym = "PRG", Name = "Programování" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Acronym = "WEB", Name = "Webové aplikace" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Acronym = "TEV", Name = "Tělocvik" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Acronym = "CJL", Name = "Český jazyk a literatura" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Acronym = "ANJ", Name = "Anglický jazyk" });
        }

    }
}
