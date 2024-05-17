using LogisticsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticsAPI.DatabaseContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }
    }
}
