using Entities;
using Infrastructure;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using UseCases;

namespace WebTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            // Arrange
            var friendRepositoryMock = new Mock<IFriendRepository>();
            var friendManager = new FriendManager(friendRepositoryMock.Object);
            var friend = new Friend { FullName = "John Doe" };

            // Act
            friendManager.AddFriend(friend);

            // Assert
            friendRepositoryMock.Verify(repo => repo.Add(friend), Times.Once);
        }

        [Fact]
        public void TestRemove()
        {
            // Arrange
            var friendRepositoryMock = new Mock<IFriendRepository>();
            var friendManager = new FriendManager(friendRepositoryMock.Object);
            var friend = new Friend { FullName = "John Doe" };

            // Act
            friendManager.RemoveFriend(friend);

            // Assert
            friendRepositoryMock.Verify(repo => repo.Delete(friend), Times.Once);
        }

        [Fact]
        public void TestGetAllFriends()
        {
            // Arrange
            var friendRepositoryMock = new Mock<IFriendRepository>();
            var friendManager = new FriendManager(friendRepositoryMock.Object);
            var friends = new List<Friend>
                {
                    new Friend { FullName = "John Doe" },
                    new Friend { FullName = "Jane Smith" }
                };
            friendRepositoryMock.Setup(repo => repo.GetAllFriends()).Returns(friends);

            // Act
            var result = friendManager.GetAllFriends();

            // Assert
            Assert.Equal(friends, result);
        }

        [Fact]
        public void TestGetFriendByFullName()
        {
            // Arrange
            var friendRepositoryMock = new Mock<IFriendRepository>();
            var friendManager = new FriendManager(friendRepositoryMock.Object);
            var friend = new Friend { FullName = "John Doe" };
            friendRepositoryMock.Setup(repo => repo.GetFriendByFullName("John Doe")).Returns(friend);

            // Act
            var result = friendManager.GetFriendByFullName("John Doe");

            // Assert
            Assert.Equal(friend, result);
        }
    }

}