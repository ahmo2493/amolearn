using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProjectMVC.SQLinfo
{
    public class BasicJSDBContext : DbContext
    {
        public DbSet<BasicJs> BasicJs { get; set; }
        public DbSet<BasicCSharp> BasicCSharp { get; set; }
        public DbSet<BasicMVC> BasicMVC { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= MyDatabase");
        }
    }
}
