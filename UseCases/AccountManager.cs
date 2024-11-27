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

        public void RemoveAccount(Account account) 
        {
            _accountRepository.Delete(account);
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

        public void UpdateAccount(Account account)
        {
            _accountRepository.Update(account);
        }

        public async Task<bool> Commit()
        {
            await _accountRepository.UnitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
