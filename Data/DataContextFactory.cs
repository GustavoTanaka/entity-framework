using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityFramework.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        // Implementação explícita da interface
        DataContext IDesignTimeDbContextFactory<DataContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\gustavo.tanaka\\source\\repos\\EntityFramework\\people.db");

            return new DataContext(optionsBuilder.Options);
        }
    }
}