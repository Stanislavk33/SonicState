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
        public string Login([FromBody] LoginUser user)
        {
            if(userService.ValidateUserData(user)){
               var token = authenticateService.Authenticate(user);
               return token;
            }
            else
            {
                return null;
            }
        }
    }

}
