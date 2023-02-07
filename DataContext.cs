using KeyPathAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace KeyPathAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<PersonModel> Person { get; set; }
    }
}
