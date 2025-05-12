using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Repository
{
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {       
        public BlogDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            optionsBuilder.UseSqlServer(connectionString);

            return new BlogDbContext(optionsBuilder.Options, configuration);
        }
    }
}

