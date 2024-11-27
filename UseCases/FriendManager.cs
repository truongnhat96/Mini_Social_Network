using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class FriendManager(IFriendRepository friendRepository)
    {
        private readonly IFriendRepository _friendRepository = friendRepository;

        public async Task AddFriend(Friend friend)
        {
            await _friendRepository.AddAsync(friend);
        }

        public void RemoveFriend(Friend friend)
        {
            _friendRepository.Delete(friend);
        }

        public IEnumerable<Friend> GetAllFriendsOfUser()
        {
            return _friendRepository.GetAllFriendsOfUser();
        }

        public IEnumerable<Friend> GetAllFriendsOfUser(string username)
        {
            return _friendRepository.GetAllFriendsOfUser(username);
        }

        public async Task<Friend> GetFriendByFullName(string fullName)
        {
            return await _friendRepository.GetFriendByFullNameAsync(fullName);
        }

        public async Task<bool> Commit()
        {
            await _friendRepository.UnitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
