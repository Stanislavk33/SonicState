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
        public UserController(IUserService userService) :base()
        {
            this.userService = userService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser user) 
        {
            await userService.Add(user);
            return Ok();
        }
    }
}