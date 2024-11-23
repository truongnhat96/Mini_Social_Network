using Entities;

namespace UseCases
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task DeleteAsync(Account account);
        Task UpdateAsync(Account account);
        Task<Account> GetAccountByUsernameAsync(string username);
        IEnumerable<Account> GetAllAccounts();

        bool CheckAccountLogin(string username, string password);
    }
}
