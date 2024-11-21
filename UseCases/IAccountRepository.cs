using Entities;

namespace UseCases
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Delete(Account account);
        void Update(Account account);
        Account GetAccountByUsername(string username);
        IEnumerable<Account> GetAllAccounts();

        bool CheckAccountLogin(string username, string password);
    }
}
