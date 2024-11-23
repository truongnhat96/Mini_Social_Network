using Entities;
using Infrastructure.DataContext;
using UseCases;

namespace Infrastructure
{
    public class AccountRepository(SocialNetworkContext context) : IAccountRepository
    {
        private readonly SocialNetworkContext _context = context;

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(new Accounts() 
            { 
                Username = account.Username, 
                Password = account.Password, 
                DisplayName = account.DisplayName
            });
            await _context.SaveChangesAsync();
        }

        public bool CheckAccountLogin(string username, string password)
        {
            var query = from a in _context.Accounts
                        where a.Username == username && a.Password == password
                        select a;
            return query.Any();
        }

        public async Task DeleteAsync(Account account)
        {
            _context.Accounts.Remove(new Accounts()
            {
                Username = account.Username,
                Password = account.Password,
                DisplayName = account.DisplayName
            });
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            var acc = await _context.Accounts.FindAsync(username) ?? new Accounts() { DisplayName = "", Password = "", Username = ""};
            return new Account()
            {
                Username = acc.Username,
                Password = acc.Password,
                DisplayName = acc.DisplayName
            };
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            List<Account> accounts = [];
            _context.Accounts.ToList().ForEach(acc =>
            {
                accounts.Add(new Account()
                {
                    Username = acc.Username,
                    Password = acc.Password,
                    DisplayName = acc.DisplayName
                });
            });
            return accounts;
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(new Accounts()
            {
                Username = account.Username,
                Password = account.Password,
                DisplayName = account.DisplayName
            });
            await _context.SaveChangesAsync();
        }
    }
}
