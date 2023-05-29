using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using WebUI.Constants;
using WebUI.Helper;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ExternalLogin(ExternalLoginType externalLoginType = ExternalLoginType.Google)
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("ExternalLoginResponse") };
            var authenticationSchema = externalLoginType switch
            {
                ExternalLoginType.Google => GoogleDefaults.AuthenticationScheme,
            };
            return new ChallengeResult(authenticationSchema, properties);
        }

        public async Task<IActionResult> ExternalLoginResponse()
        {
            var authenticate = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (authenticate?.Principal?.Identities.Any() ?? false)
            {
                var identity = authenticate.Principal.Identities.First();
                var email = identity.FindFirst(ClaimTypes.Email)?.Value;
                var username = identity.FindFirst(ClaimTypes.Name)?.Value;

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(username))
                {

                    var authRequestModel = new AuthRequestModel(_configuration.GetSection("authUserName").Value, _configuration.GetSection("authPassword").Value);
                    var authResponseModel = ApiHelper.Request<AuthResponseModel>(_configuration.GetSection("authUrl").Value, WebRequestMethods.Http.Post,null, authRequestModel, false);

                    if (authResponseModel is not null)
                    {
                        var header = new NameValueCollection() { { "Authorization", $"Bearer {authResponseModel.Data.Token}" } };
                        var response = ApiHelper.Request<List<CustomerResponseModel>>(_configuration.GetSection("getAllCustomerUrl").Value, WebRequestMethods.Http.Get, header,null);
                        if (response?.Data?.Any()?? false)
                        {
                            TempData["customerList"] = JsonConvert.SerializeObject(response.Data);
                            return RedirectToAction("Index", "Customer");
                        }
                    }
                }
            }
            return Unauthorized();

        }

     
    }
}