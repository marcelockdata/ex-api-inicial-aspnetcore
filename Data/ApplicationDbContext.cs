using ex_api_inicial.Models;
using Microsoft.EntityFrameworkCore;

namespace ex_api_inicial.Data
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Ignore<Client>();
            base.OnModelCreating(builder);
        }
    }
}