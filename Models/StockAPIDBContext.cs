using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using stockResearchAPI.Models;

namespace stockResearchAPI.Models
{
    public class StockAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public StockAPIDBContext(DbContextOptions<StockAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("stockInfoDB");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Research> Research { get; set; } = null!;
        public DbSet<CompanyEvent> CompanyEvent { get; set; } = null!;
        public DbSet<Stock> Stock { get; set; } = null!;
    }
}
