using Entities;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Infrastructure
{
    public class FriendRepository(SocialNetworkContext context) : IFriendRepository
    {
        private readonly SocialNetworkContext _context = context;

        public void Add(Friend friend)
        {
            _context.Friends.Add(new Friends()
            {
                FullName = friend.FullName,
                Status = friend.Status
            });
            _context.SaveChanges();
        }

        public void Delete(Friend friend)
        {
            _context.Friends.Remove(new Friends()
            {
                FullName = friend.FullName,
                Status = friend.Status
            });
            _context.SaveChanges();
        }

        public IEnumerable<Friend> GetAllFriends()
        {
            List<Friend> friends = [];
            foreach (var friend in _context.Friends)
            {
                friends.Add(new Friend()
                {
                    FullName = friend.FullName,
                    Status = friend.Status
                });
            }
            return friends;
        }

        public Friend GetFriendByFullName(string fullName)
        {
            var friend = _context.Friends.FirstOrDefault(fr => fr.FullName == fullName) ?? new Friends() { FullName = "Unknow", Status = "???" };
            return new Friend()
            {
                FullName = friend.FullName,
                Status = friend.Status
            };
        }
    }
}
