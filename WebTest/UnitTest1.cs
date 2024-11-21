using Entities;
using Infrastructure;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCases;

namespace WebTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            // Arrange
            SocialNetworkContext context = new("Server=.\\SQLEXPRESS;Database=Mini_Social_Network;Trusted_Connection=True;TrustServerCertificate=True");

            IAccountRepository accountRepository = new AccountRepository(context);    

            var account = new Account()
            {
                Username = "test1",
                Password = "test",
                DisplayName = "test"
            };

            // Act
            accountRepository.Add(account);

            // Assert
            var savedAccount = accountRepository.GetAccountByUsername("test");
            Assert.NotNull(savedAccount);
            Assert.Equal("test", savedAccount.Username);
            Assert.Equal("test", savedAccount.Password);
            Assert.Equal("test", savedAccount.DisplayName);
        }
    }

}