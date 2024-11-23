using Entities;

namespace UseCases
{
    public class AccountManager(IAccountRepository accountRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task AddAccount(Account account)
        {
            await _accountRepository.AddAsync(account);
        }

        public async Task RemoveAccount(Account account) 
        {
            await _accountRepository.DeleteAsync(account);
        }

        public bool LoginValidation(string username, string password)
        {
            return _accountRepository.CheckAccountLogin(username, password);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public async Task<Account> GetAccountByUsername(string username)
        {
            return await _accountRepository.GetAccountByUsernameAsync(username);
        }
    }
}
