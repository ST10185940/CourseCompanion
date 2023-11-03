using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using CourseCompanion.Models;

namespace CourseCompanion.DataAccess
{
    public class AppData : DbContext
    {
        public DbSet<user> user {get;set;}

        public DbSet<module> module { get;set;}

        public DbSet<semester> semester { get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=course_companion;User=root;Password=;", new MySqlServerVersion(new Version(8, 0, 28)));
        }
    }
}
