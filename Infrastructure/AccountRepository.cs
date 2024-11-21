using Entities;
using Infrastructure.DataContext;
using UseCases;

namespace Infrastructure
{
    public class AccountRepository(SocialNetworkContext context) : IAccountRepository
    {
        private readonly SocialNetworkContext _context = context;

        public void Add(Account account)
        {
            _context.Accounts.Add(new Accounts() 
            { 
                Username = account.Username, 
                Password = account.Password, 
                DisplayName = account.DisplayName
            });
            _context.SaveChanges();
        }

        public bool CheckAccountLogin(string username, string password)
        {
            var query = from a in _context.Accounts
                        where a.Username == username && a.Password == password
                        select a;
            return query.Any();
        }

        public void Delete(Account account)
        {
            _context.Accounts.Remove(new Accounts()
            {
                Username = account.Username,
                Password = account.Password,
                DisplayName = account.DisplayName
            });
            _context.SaveChanges();
        }

        public Account GetAccountByUsername(string username)
        {
           var acc = _context.Accounts.FirstOrDefault(a => a.Username == username) ?? new Accounts() { Username = "Unknow", DisplayName = "", Password = "???"};
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

        public void Update(Account account)
        {
            _context.Accounts.Update(new Accounts()
            {
                Username = account.Username,
                Password = account.Password,
                DisplayName = account.DisplayName
            });
            _context.SaveChanges();
        }
    }
}
