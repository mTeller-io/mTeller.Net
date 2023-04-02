using Autofac.Extras.Moq;
using Business;
using Business.DTO;
using Business.Interface;
using DataAccess.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Service.Test.CodeLibrary.Business
{
    public class AuthBusinessTest
    {
        [Fact]
        public void Validate_ShouldReturnOperationalResultWhenUserSignUp()
        {
            // Arrange

            using var mock = AutoMock.GetLoose();
            var userSignUp = new UserSignUp();

            // Act

            var sut = mock.Create<AddCashIn>();
            var actualResult = sut.Validate(userSignUp);

            //Assert

            Assert.NotNull(actualResult);
            Assert.IsType<OperationalResult<UserDetail>>(actualResult);
            Assert.False(actualResult.Status);
        }

        [Fact]
        public void GetToken_ShouldReturnTokenWhenUserAndRolesGiven()
        {
            // Arrange

            using var mock = AutoMock.GetLoose();
            var user = new User() { Id = 100, UserName = "testuser" };
            var roles = new List<string>() { "Admin", "Frontline" };
            var token = "ZnJhbms6bWVuc2Fo";

            mock.Mock<IJwtTokenBusiness>()
                .Setup(m => m.GenerateJwt(It.IsAny<User>(), It.IsAny<List<string>>()))
                .Returns(token);

            // Act

            var sut = mock.Create<AddCashIn>();
            var actualResult = sut.GetToken(user, roles);

            //Assert

            Assert.NotNull(actualResult);
            Assert.True(actualResult.Status);
            Assert.Equal(token, actualResult.AuthToken);
            Assert.IsType<OperationalResult<UserDetail>>(actualResult);
        }

        [Fact]
        public void GetToken_ShouldReturnTokenWhenUserAndRolesNotGiven()
        {
            // Arrange

            using var mock = AutoMock.GetLoose();
            var roles = new List<string>() { "Admin", "Frontline" };
            var token = "ZnJhbms6bWVuc2Fo";
            var message = "User or roles cannot be null or empty";

            mock.Mock<IJwtTokenBusiness>()
                .Setup(m => m.GenerateJwt(It.IsAny<User>(), It.IsAny<List<string>>()))
                .Returns(token);

            // Act

            var sut = mock.Create<AddCashIn>();
            var actualResult = sut.GetToken(null, roles);

            //Assert

            Assert.NotNull(actualResult);
            Assert.False(actualResult.Status);
            Assert.Equal(message, actualResult.Message);
            Assert.IsType<OperationalResult<UserDetail>>(actualResult);
        }
    }
}