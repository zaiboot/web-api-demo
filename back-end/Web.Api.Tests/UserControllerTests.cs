using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.Moq;
using Web.Api.Models;
using Web.Api.Controllers;
using Xunit;
using UserProjects.DAL.Models;
using System.Threading.Tasks;

namespace Web.Api.Tests
{
    public class UserControllerTests
    {

        //TODO : Convert this to a service / DAL
        private List<User> userList = new List<User>();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public async void GetAllUsers(int userCount)
        {
            using (var mock = AutoMock.GetStrict())
            {
                var system = GivenTheSystemUnderTest(mock);
                WhenIMockUsers(userCount);
                var users = await WhenIGetUsersFromSystemAsync(system);
                Assert.NotNull(users);
                Assert.True(users.Count() == userCount, "User count do not match");
            }

        }

        private Task<IReadOnlyList<UserModel>>  WhenIGetUsersFromSystemAsync(UserController system)
        {
            return system.GetAsync();
        }

        private void WhenIMockUsers(int usersCount)
        {
            for (int i = 0; i < usersCount; i++)
            {
                var user = WhenIGetAUser(i);
            }
        }

        private User WhenIGetAUser(int userId)
        {
            return new User { Id = userId, FirstName = "Test " + userId, LastName = "Test " + userId };
        }

        private UserController GivenTheSystemUnderTest(AutoMock mock)
        {
            return mock.Create<UserController>();
        }
    }
}