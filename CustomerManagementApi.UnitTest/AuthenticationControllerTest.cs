using JWTAuthenticationManager;
using Microsoft.Extensions.Configuration;

namespace CustomerManagementApi.UnitTest
{
    public class AuthenticationControllerTest
    {
        public AuthenticationControllerTest()
        {
           
        }
        [Fact]
        public void CreateTokenTest()
        {
            #region Arrange
            var appSettingsStub = new Dictionary<string, string> {
                    {"CustomerUser:UserName", "CustomerUserTest"},
                    {"CustomerUser:Password", "123456"}
            };
            var configuration = new ConfigurationBuilder()
                                    .AddInMemoryCollection(appSettingsStub)
                                    .Build();
            #endregion

            #region Act
            var response = new JwtTokenHandler(configuration).GenerateJwtToken(
                new JWTAuthenticationManager.Models.Request.AuthRequest { UserName = "User", Password = "123" });
            #endregion

            #region Assert
            Assert.Null(response);
            #endregion
        }
    }
}