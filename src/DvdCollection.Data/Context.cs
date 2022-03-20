using Microsoft.EntityFrameworkCore;

namespace DvdCollection.Data
{
    public class Context : DbContext
    {
        private string _connStr;

        public DbSet<Models.MediaFile> MediaFiles { get; set; }

        public void SetConnectionString(string connStr)
        {
            _connStr = connStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connStr ?? "Server=.;Database=MyDb;Trusted_Connection=True;");
            }
        }

    }
}
