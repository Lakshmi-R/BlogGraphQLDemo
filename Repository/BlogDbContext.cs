using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BlogDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<Post> posts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options, IConfiguration configuration): base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        
    }
}
