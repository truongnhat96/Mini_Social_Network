using Infrastructure;
using Infrastructure.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Entities;
using UseCases;

namespace WebTest
{
    public class AccountTest
    {
        [Fact]
        public async Task Add_Account_Success()
        {
            var _acccountRepository = AccountFactory.CreateAccountRepository();
            var account = new Account()
            {
                Username = "test",
                Password = "test",
                DisplayName = "test"
            };

            await _acccountRepository.AddAsync(account);
            await _acccountRepository.UnitOfWork.SaveChangeAsync();

            Assert.True(_acccountRepository.CheckAccountLogin("test", "test"));
        }

        [Fact]
        public async Task Delete_Account_Success()
        {
            var _acccountRepository = AccountFactory.CreateAccountRepository();
            var account = new Account()
            {
                Username = "testER",
                Password = "testT",
                DisplayName = "TTT"
            };

            await _acccountRepository.AddAsync(account);
            await _acccountRepository.UnitOfWork.SaveChangeAsync();

            _acccountRepository = AccountFactory.CreateAccountRepository();

            _acccountRepository.Delete(account);
            await _acccountRepository.UnitOfWork.SaveChangeAsync();

            Assert.NotEqual(account, await _acccountRepository.GetAccountByUsernameAsync("testER"));
        }

        [Fact]
        public async Task Update_Account_Success()
        {
            var _acccountRepository = AccountFactory.CreateAccountRepository();
            var account = new Account()
            {
                Username = "tester",
                Password = "testT",
                DisplayName = "TTT"
            };

            await _acccountRepository.AddAsync(account);
            await _acccountRepository.UnitOfWork.SaveChangeAsync();

            _acccountRepository = AccountFactory.CreateAccountRepository();

            account.DisplayName = "TTTTTT";
            _acccountRepository.Update(account);
            await _acccountRepository.UnitOfWork.SaveChangeAsync();

            Assert.Equal(account.DisplayName, (await _acccountRepository.GetAccountByUsernameAsync("tester")).DisplayName);
        }
    }
}
