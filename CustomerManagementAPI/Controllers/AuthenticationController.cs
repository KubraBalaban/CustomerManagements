using JWTAuthenticationManager;
using JWTAuthenticationManager.Models.Request;
using JWTAuthenticationManager.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AuthenticationController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }


        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<AuthResponse> Authenticate([FromBody] AuthRequest authenticationRequest)
        {
            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
            if (authenticationResponse == null)
            {
                return Unauthorized();
            }
            return Ok(authenticationResponse);
        }
    }
}
