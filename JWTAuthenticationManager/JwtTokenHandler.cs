using JWTAuthenticationManager.Models;
using JWTAuthenticationManager.Models.Request;
using JWTAuthenticationManager.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "PR2MkuemfpwödşQ14olFA!T5Remf?2kfjhesklfjlkEiotmf&lkgdl&45P1289ABCD!%4AG";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccountModel> _userAccounts;
        private readonly IConfiguration _configuration;
        public JwtTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _userAccounts = new List<UserAccountModel>
            {
                new UserAccountModel {
                    UserName = _configuration.GetSection("CustomerManagement").GetSection("UserName").Value ,
                    Password = _configuration.GetSection("CustomerManagement").GetSection("Password").Value
                }
            };

        }

        public AuthResponse? GenerateJwtToken(AuthRequest authRequest)
        {
            if (string.IsNullOrWhiteSpace(authRequest.UserName) || string.IsNullOrWhiteSpace(authRequest.Password))
            {
                return null;
            }

            var userAccount = _userAccounts.Where(u => u.UserName.Equals(authRequest.UserName) && u.Password.Equals(authRequest.Password));
            if (!userAccount.Any())
            {
                return null;
            }

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Name, authRequest.UserName),

            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha512Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthResponse
            {
                UserName = authRequest.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                Token = token

            };
        }
    }
}

