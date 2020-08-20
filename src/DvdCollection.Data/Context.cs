using Microsoft.EntityFrameworkCore;

namespace DvdCollection.Data
{
    public class Context : DbContext
    {
        public DbSet<Models.MediaFile> MediaFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=MyDb;Trusted_Connection=True;");
            }
        }

    }
}
