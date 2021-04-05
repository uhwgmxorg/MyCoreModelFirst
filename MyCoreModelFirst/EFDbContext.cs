using Microsoft.EntityFrameworkCore;

namespace MyCoreModelFirst
{
    public class EFDbContext : DbContext
    {
        public string ConnectionString { get; set; } = "Server=.;Database=MyEFCoreDataBase;Trusted_Connection=true";
        public DbSet<EFName> Names { get; set; }

        /// <summary>
        /// Constuctor
        /// </summary>
        public EFDbContext()
        {
            // uncomment this if we are uning SQL-EXPRESS:
            //ConnectionString = "Server=.\\SQLEXPRESS;Database=MyEFCoreDataBase;Trusted_Connection=true";
        }

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
