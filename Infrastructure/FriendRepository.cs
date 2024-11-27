using Entities;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
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

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Friend> AddAsync(Friend friend)
        {
            await _context.Friends.AddAsync(new Friends()
            {
                FullName = friend.FullName,
                Status = friend.Status,
                AccountID = friend.AccountID
            });
            return friend;
        }

        public Friend Delete(Friend friend)
        {
            _context.Friends.Remove(new Friends()
            {
                FullName = friend.FullName,
                Status = friend.Status,
                AccountID = friend.AccountID
            });
            return friend;
        }

        public IEnumerable<Friend> GetAllFriendsOfUser()
        {
            var query = from f in _context.Friends
                        where f.Account != null && f.AccountID == f.Account.Username
                        select f;
            return query.Select(f => new Friend()
            {
                FullName = f.FullName,
                Status = f.Status,
                AccountID = f.AccountID
            });
        }

        public IEnumerable<Friend> GetAllFriendsOfUser(string UID)
        {
            return _context.Friends.Where(f => f.AccountID == UID).Select(f => new Friend()
            {
                FullName = f.FullName,
                Status = f.Status,
                AccountID = f.AccountID
            });
        }

        public async Task<Friend> GetFriendByFullNameAsync(string fullName)
        {
            var friend = await _context.Friends.FirstOrDefaultAsync(f => f.FullName == fullName) ?? new Friends() { FullName = "Unknow", Status = "???", AccountID = "" };
            return new Friend()
            {
                FullName = friend.FullName,
                Status = friend.Status,
                AccountID = friend.AccountID
            };
        }
    }
}
