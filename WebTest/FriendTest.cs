using Entities;
using Infrastructure;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTest
{
    public class FriendTest
    {

        [Fact]
        public async Task Add_Friend_Success()
        {
            var _friendRepository = FriendFactory.CreateFriendRepository();
            var _accountRepository = AccountFactory.CreateAccountRepository();
            var account = new Account()
            {
                DisplayName = "Tester",
                Password = "123456",
                Username = "tester"
            };
            var account1 = new Account()
            {
                DisplayName = "Tester111",
                Password = "123456",
                Username = "Dev"
            };
            await _accountRepository.AddAsync(account);
            await _accountRepository.AddAsync(account1);
            await _accountRepository.UnitOfWork.SaveChangeAsync();

            var friend = new Friend()
            {
                FullName = "Friend",
                Status = "Active",
                AccountID = account.Username
            };
            var friend1 = new Friend()
            {
                FullName = "Friend1",
                Status = "Active",
                AccountID = account.Username
            };
            var friend2 = new Friend()
            {
                FullName = "Friend2",
                Status = "Active",
                AccountID = account1.Username
            };
            await _friendRepository.AddAsync(friend);
            await _friendRepository.AddAsync(friend1);
            await _friendRepository.AddAsync(friend2);
            await _friendRepository.UnitOfWork.SaveChangeAsync();

            Assert.True(_friendRepository.GetAllFriendsOfUser().Count() > 1);
            Assert.True(_friendRepository.GetAllFriendsOfUser(account1.Username).Count() > 0);
        }

        [Fact]
        public async Task Remove_Friend_Success()
        {
            var _friendRepository = FriendFactory.CreateFriendRepository();
            var _accountRepository = AccountFactory.CreateAccountRepository();
            var account = new Account()
            {
                DisplayName = "Tester",
                Password = "123456",
                Username = "tester"
            };
            var account1 = new Account()
            {
                DisplayName = "Tester111",
                Password = "123456",
                Username = "Dev"
            };
            await _accountRepository.AddAsync(account);
            await _accountRepository.AddAsync(account1);
            await _accountRepository.UnitOfWork.SaveChangeAsync();

            var friend = new Friend()
            {
                FullName = "Friend",
                Status = "Active",
                AccountID = account.Username
            };
            var friend1 = new Friend()
            {
                FullName = "Friend1",
                Status = "Active",
                AccountID = account.Username
            };
            var friend2 = new Friend()
            {
                FullName = "Friend2",
                Status = "Active",
                AccountID = account1.Username
            };
            await _friendRepository.AddAsync(friend);
            await _friendRepository.AddAsync(friend1);
            await _friendRepository.AddAsync(friend2);
            await _friendRepository.UnitOfWork.SaveChangeAsync();

            _friendRepository = FriendFactory.CreateFriendRepository();
            _friendRepository.Delete(friend1);
            _friendRepository.Delete(friend2);
            await _friendRepository.UnitOfWork.SaveChangeAsync();

            Assert.Equal(friend.AccountID, (await _friendRepository.GetFriendByFullNameAsync(friend.FullName)).AccountID);
            Assert.True(_friendRepository.GetAllFriendsOfUser(account1.Username).Count() == 0);
        }
    }
}
