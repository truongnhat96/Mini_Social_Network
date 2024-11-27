
using Infrastructure;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using UseCases;

namespace WebTest
{
    public class FriendFactory
    {
        public static IFriendRepository CreateFriendRepository()
        {
            var options = new DbContextOptionsBuilder<SocialNetworkContext>()
                .UseInMemoryDatabase(databaseName: "SocialNetwork")
                .Options;
            return new FriendRepository(new SocialNetworkContext(options));
        }
    }
}