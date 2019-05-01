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
            optionsBuilder.UseSqlServer(@"Server=tcp:amolearnserver.database.windows.net,1433;Initial Catalog=amoLearnDatabase;Persist Security Info=False;User ID=ahmo2493;Password=Spiodic10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
