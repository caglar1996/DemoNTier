using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class DemoContext : DbContext
    {
        private readonly string connStr = String.Empty;

        public DemoContext(string connStr)
        {
            this.connStr = connStr;
        }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }
           
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connStr);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> User { get; set; }
    }
}
