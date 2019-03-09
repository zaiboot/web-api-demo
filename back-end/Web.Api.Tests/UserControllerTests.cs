using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.Moq;
using Web.Api.Models;
using Web.Api.Controllers;
using Xunit;
using UserProjects.DAL.Models;
using System.Threading.Tasks;
using UserProjects.DAL.Repositories;
using System.Collections.ObjectModel;
using UserProjects.Common.Mapping;
using Moq;

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
                WhenIMockUsers(mock, userCount);                

                var system = GivenTheSystemUnderTest(mock);
                var users = await WhenIGetUsersFromSystemAsync(system);
                Assert.NotNull(users);
                Assert.True(users.Count() == userCount, $"User count do not match");
            }

        }

        private Task<IList<UserModel>>  WhenIGetUsersFromSystemAsync(UserController system)
        {
            return system.GetAsync();
        }

        private void WhenIMockUsers(AutoMock mock, int usersCount)
        {
            var users = new List<User>();
            var usersModel = new List<UserModel>();

            for (int i = 0; i < usersCount; i++)
            {
                var user = WhenIGetAUser(i);
                users.Add(user);
                var userModel = new UserModel { UserId = i};
                usersModel.Add(userModel);
            }
            mock.Mock<IUserRepository>().Setup( ur => ur.Get()
            ).Returns(users.AsQueryable());
            
            AndISetupAMapping<List<User>, List<UserModel>>(mock, usersModel);
        }

        private User WhenIGetAUser(int userId)
        {
            return new User { Id = userId, FirstName = "Test " + userId, LastName = "Test " + userId };
        }

        private UserController GivenTheSystemUnderTest(AutoMock mock)
        {
            return mock.Create<UserController>();
        }

         protected void AndISetupAMapping<TFrom, TDestiny>(AutoMock mock, TDestiny result) where TDestiny : new()
        {
            mock.Mock<IMappingEngine>().Setup(m =>
                m.Map<TFrom, TDestiny>(
                        It.IsAny<TFrom>()
                        )
            ).Returns(result);
        }
    }
}