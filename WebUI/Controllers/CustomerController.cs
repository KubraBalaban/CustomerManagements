using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<List<CustomerResponseModel>>(TempData["customerList"].ToString());
            if (model?.Any() ?? false)
            {
                return View(model);
            }
            return Unauthorized();
        }

    }
}
