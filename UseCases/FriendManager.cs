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

        public async Task RemoveFriend(Friend friend) 
        {
            await _friendRepository.DeleteAsync(friend);
        }

        public IEnumerable<Friend> GetAllFriends() 
        {
            return _friendRepository.GetAllFriends();
        }

        public async Task<Friend> GetFriendByFullName(string fullName)
        {
            return await _friendRepository.GetFriendByFullNameAsync(fullName);
        }
    }
}
