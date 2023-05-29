using CustomerManagementAPI.App.Helper.Interface;
using CustomerManagementAPI.Application.Constant;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace CustomerManagementAPI.App.Helper
{
    public class SecurityTokenHandler : ISecurityTokenHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecurityTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetToken()
        {
            var token = string.Empty;

            var principal = _httpContextAccessor.HttpContext.User;
            if (null != principal)
            {
                foreach (var claim in principal.Claims)
                {
                    if (claim.Type == "Token")
                    {
                        token = claim.Value;
                    }
                }
            }

            return token;
        }



        public async Task<int> CheckTokenExpTime(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            if (handler.ReadToken(token) is JwtSecurityToken jwtToken)
            {
                var tokenExpDate = jwtToken.Claims.First(claim => claim.Type == "exp").Value;
                var dateTimetokenExp = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(tokenExpDate));

                var differenceTimeSpan = dateTimetokenExp - DateTime.Now;
                if (0 < differenceTimeSpan.TotalMinutes && differenceTimeSpan.TotalMinutes < 20)
                {
                    return TokenStatus.RefreshToken;
                }
            }

            return TokenStatus.ActiveToken;
        }

        public async Task CheckUnauthorizeStatus(HttpStatusCode httpStatusCode)
        {
            if (httpStatusCode == HttpStatusCode.Unauthorized)
                await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(
                    _httpContextAccessor.HttpContext, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<string> GenerateToken(string username, int expireMinutes = 20)
        {
            string key = ApiConstants.TOKEN_KEY;
            var symmetricKey = Encoding.UTF8.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor(

            );
            tokenDescriptor.Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

            tokenDescriptor.Expires = now.AddMinutes(Convert.ToInt32(expireMinutes));

            tokenDescriptor.SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature);

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

    }
}
