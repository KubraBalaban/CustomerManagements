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
            var appSettingsStub = new Dictionary<string, string> {
                    {"CustomerManagement:UserName", "CustomerUserTest"},
                    {"CustomerManagement:Password", "123456"}
            };
            var configuration = new ConfigurationBuilder()
                                    .AddInMemoryCollection(appSettingsStub)
                                    .Build();
            #region Act
            var response = new JwtTokenHandler(configuration).GenerateJwtToken(new JWTAuthenticationManager.Models.Request.AuthRequest { UserName = "User", Password = "123" });
            #endregion

            #region Assert
            Assert.Null(response);
            #endregion
        }
    }
}
