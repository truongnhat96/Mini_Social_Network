using Entities;

namespace UseCases
{
    public interface IAccountRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Account> AddAsync(Account account);
        Account Delete(Account account);
        Account Update(Account account);
        Task<Account> GetAccountByUsernameAsync(string username);
        IEnumerable<Account> GetAllAccounts();

        bool CheckAccountLogin(string username, string password);
    }
}
