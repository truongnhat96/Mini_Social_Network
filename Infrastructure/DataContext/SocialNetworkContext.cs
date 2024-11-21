using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class SocialNetworkContext : DbContext
    {
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Accounts> Accounts { get; set; }

        private readonly string _connectionString = "Server=.\\SQLEXPRESS;Database=Mini_Social_Network;Trusted_Connection=True;TrustServerCertificate=True";

        public SocialNetworkContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SocialNetworkContext(DbContextOptions Option) : base(Option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
