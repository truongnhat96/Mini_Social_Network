using Entities;

namespace UseCases
{
    public interface IFriendRepository
    {
        Task AddAsync(Friend friend);
        Task DeleteAsync(Friend friend);
        Task<Friend> GetFriendByFullNameAsync(string fullName);
        IEnumerable<Friend> GetAllFriends();
    }
}
