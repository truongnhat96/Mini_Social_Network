using Microsoft.EntityFrameworkCore;
using UseCases;

namespace Infrastructure.DataContext
{
    public class SocialNetworkContext : DbContext, IUnitOfWork
    {
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Accounts> Accounts { get; set; }

        private readonly string _connectionString;

        public SocialNetworkContext()
        {
            _connectionString = "Server=.\\SQLEXPRESS;Database=Mini_Social_Network;Trusted_Connection=True;TrustServerCertificate=True";
        }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public SocialNetworkContext(DbContextOptions Option) : base(Option)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString)
                              .UseLazyLoadingProxies();
            }
        }

        public async Task<bool> SaveChangeAsync()
        {
            await base.SaveChangesAsync();
            return true;
        }
    }
}
