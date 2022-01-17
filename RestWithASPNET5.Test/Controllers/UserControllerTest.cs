using Microsoft.AspNetCore.Mvc;
using Moq;
using RestWithASPNET5.Business;
using RestWithASPNET5.Controllers;
using RestWithASPNET5.Data.VO;
using System;
using Xunit;

namespace RestWithASPNET5.Test.Controllers
{
    public class UserControllerTest
    {
        private MockRepository mockRepository;
        Mock<IUserBusiness> _mockUserBusiness;

        public UserControllerTest()
        {
            mockRepository = new MockRepository(MockBehavior.Default);
            _mockUserBusiness = mockRepository.Create<IUserBusiness>();
        }

        private UserController UserController()
        {
            return new UserController(_mockUserBusiness.Object);
        }

        [Fact]
        public void CreateUser()
        {
            //Arrange
            var user = new UserVO()
            {
                Login = "Maria",
                Password = "12356"
            };

            var userController = UserController();

            //Action

            _mockUserBusiness.Setup(x => x.Create(user)).Returns(true).Verifiable();

            ActionResult<UserVO> response = userController.Create(user);
            OkResult result = (OkResult)response.Result;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void CreateErroUser()
        {
            UserVO user = null;

            var userController = UserController();

            ActionResult<UserVO> response = userController.Create(user);
            BadRequestObjectResult result = (BadRequestObjectResult) response.Result;

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void FailCreateUser()
        {
            var user = new UserVO()
            {
                Login = "Maria",
                Password = "12356"
            };

            var userController = UserController();

            _mockUserBusiness.Setup(x => x.Create(user)).Returns(false).Verifiable();

            ActionResult<UserVO> response = userController.Create(user);
            BadRequestObjectResult result = (BadRequestObjectResult)response.Result;

            Assert.Equal("Failed to register the user", result.Value);

        }
    }
}
