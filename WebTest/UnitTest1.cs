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
    public class ProgramTests
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=Mini_Social_Network;Trusted_Connection=True;TrustServerCertificate=True";
        [Fact]
        public async Task AddTest()
        {
            // Arrange
            var Context = new SocialNetworkContext(connectionString);
            var Repo = new AccountRepository(Context);

            // Act
            await Repo.AddAsync(new Account() { Username = "Ngoctrang", Password = "trang1999898abcxyz", DisplayName = "Trang Ngô" });

            // Assert
            Assert.True(Repo.CheckAccountLogin("Ngoctrang", "trang1999898abcxyz"));
        }

        [Fact]
        public async Task DeleteTest()
        {
            // Arrange
            var Context = new SocialNetworkContext(connectionString);
            var Repo = new AccountRepository(Context);

            // Act
            await Repo.DeleteAsync(new Account() { Username = "Ngoctrang", Password = "trang1999898abcxyz", DisplayName = "Trang Ngô" });

            // Assert
            Assert.False(Repo.CheckAccountLogin("Ngoctrang", "trang1999898abcxyzest"));
        }

        [Fact]
        public async Task GetAccountByUsernameTest()
        {
            // Arrange
            var Context = new SocialNetworkContext(connectionString);
            var Repo = new AccountRepository(Context);

            // Act
            var account = await Repo.GetAccountByUsernameAsync("truongdz");

            // Assert
            Assert.Equal("truongdz", account.Username);
            Assert.Equal("324242", account.Password);
            Assert.Equal("Lương Nhật Trường", account.DisplayName);
        }
    }
}
