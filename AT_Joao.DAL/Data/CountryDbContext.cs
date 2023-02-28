using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using AT_Joao.BLL.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace AT_Joao.DAL.Data
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext(DbContextOptions<CountryDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CountryDbContext>
    {
        public CountryDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory()
      + "/../AT_Joao_WCF_AZURE/appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<CountryDbContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new CountryDbContext(builder.Options);
        }
    }
}
