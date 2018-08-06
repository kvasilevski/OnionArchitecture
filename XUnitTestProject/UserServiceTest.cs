using OA.Repo.Repositories;
using System;
using Xunit;
using Moq;
using OA.Data;
using System.Collections.Generic;
using OA.Service;
using OA.Repo;
using System.Linq;

namespace XUnitTestProject
{
    public class UserServiceTest
    {
        [Fact]
        public void getUsersByAddress_returnResults()
        {
            const string address = "aaa";

            //arrage
            var mockIUserRepository = new Mock<IUserRepository>();
            mockIUserRepository.Setup(x => x.GetUserByAddress(address)).Returns(new List<User> { new User { Email = "user1@email.com" }, new User { Email = "user2@email.com" } });

            var mockIUserProfile = new Mock<IRepository<UserProfile>>();

            //act
            var userService = new UserService(mockIUserRepository.Object, mockIUserProfile.Object);
            var list = userService.getUsersByAddress(address);

            //assert
            Assert.Equal(2, list.ToList().Count);
        }
    }
}
