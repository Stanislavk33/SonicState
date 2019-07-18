using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SonicState.Contracts.Services;
using SonicState.Models.BindingModels;

namespace SonicState.Web.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class AuthenticationController : ControllerBase
    {

        private readonly AuthenticateService authenticateService;

        public AuthenticationController(AuthenticateService authenticateService) : base()
        {
            this.authenticateService = authenticateService;
        }


        [AllowAnonymous]
        [HttpPost("requesttoken")]
        public ActionResult RequestToken([FromBody] LoginUser user) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            string token;

            if (authenticateService.IsAuthenticated(user, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }
        }
}