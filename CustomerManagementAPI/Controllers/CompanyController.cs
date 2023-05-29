using CustomerManagementAPI.Application.Models;
using CustomerManagementAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompanyController : ControllerBase
    {

        #region Fields
        private readonly IMediator _mediator;
        private readonly ICustomerQueries _customerQueries;
        #endregion

        #region Ctor
        public CompanyController(ICustomerQueries customerQueries, IMediator mediator)
        {
            _customerQueries = customerQueries;
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [Route("GetAllCompanies")]
        [HttpGet]
        [ProducesResponseType(typeof(CompanyResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllCompanies()
        {
            var result = _customerQueries.GetAllCompanies();
            return Ok(result);
        }
        #endregion
    }
}
