using Entities;

namespace UseCases
{
    public class AccountManager(IAccountRepository accountRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public void AddAccount(Account account)
        {
            _accountRepository.Add(account);
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

        public Account GetAccountByUsername(string username)
        {
            return _accountRepository.GetAccountByUsername(username);
        }
    }
}
