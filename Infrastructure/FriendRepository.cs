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

        public async Task AddAsync(Friend friend)
        {
            await _context.Friends.AddAsync(new Friends()
            {
                FullName = friend.FullName,
                Status = friend.Status
            });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Friend friend)
        {
            _context.Friends.Remove(new Friends()
            {
                FullName = friend.FullName,
                Status = friend.Status
            });
            await _context.SaveChangesAsync();
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

        public async Task<Friend> GetFriendByFullNameAsync(string fullName)
        {
            var friend = await _context.Friends.FindAsync() ?? new Friends() { FullName = "Unknow", Status = "???" };
            return new Friend()
            {
                FullName = friend.FullName,
                Status = friend.Status
            };
        }
    }
}
