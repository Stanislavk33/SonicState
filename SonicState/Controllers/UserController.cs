using Microsoft.AspNetCore.Mvc;
using SonicState.Contracts.Services;
using SonicState.Models.BindingModels;
using System.Threading.Tasks;

namespace SonicState.Web.Controllers
{
    
    [Controller]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly AuthenticateService authenticateService;

        public UserController(IUserService userService, AuthenticateService authenticateService) :base()
        {
            this.userService = userService;
            this.authenticateService = authenticateService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser user) 
        {
            await userService.Add(user);

            return Ok();
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginUser user)
        {
            if(userService.ValidateUserData(user)){
               var token = authenticateService.Authenticate(user);
                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid Request");
            }
        }
    }

}
