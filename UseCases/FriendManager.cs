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

        public void AddFriend(Friend friend)
        {
            _friendRepository.Add(friend);
        }

        public void RemoveFriend(Friend friend) 
        {
            _friendRepository.Delete(friend);
        }

        public IEnumerable<Friend> GetAllFriends() 
        {
            return _friendRepository.GetAllFriends();
        }

        public Friend GetFriendByFullName(string fullName)
        {
            return _friendRepository.GetFriendByFullName(fullName);
        }
    }
}
