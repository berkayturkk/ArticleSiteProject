using ArticleSiteProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSiteProject.DataAccess.Concrete.Context
{
    public class SqlDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-R443NGM;database=ArticleSiteProject;integrated security=true;");
        }

        public DbSet<Article> Articles { get; set; }
    }
}
