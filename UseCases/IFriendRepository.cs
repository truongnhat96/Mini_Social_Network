using Entities;

namespace UseCases
{
    public interface IFriendRepository
    {
        void Add(Friend friend);
        void Delete(Friend friend);
        Friend GetFriendByFullName(string fullName);
        IEnumerable<Friend> GetAllFriends();
    }
}
