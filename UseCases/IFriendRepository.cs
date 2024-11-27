using Entities;

namespace UseCases
{
    public interface IFriendRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Friend> AddAsync(Friend friend);
        Friend Delete(Friend friend);
        Task<Friend> GetFriendByFullNameAsync(string fullName);
        IEnumerable<Friend> GetAllFriendsOfUser();
        IEnumerable<Friend> GetAllFriendsOfUser(string UID);
    }
}
