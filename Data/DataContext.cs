using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EntityFramework.Data
{
    internal class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { }

        public DbSet<PersonModel> People { get; set; }
    }
}
