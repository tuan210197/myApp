using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myApp.Model;
using myApp.Repository;

namespace myApp.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountRepoitory accRepo;

        public UserController(IAccountRepoitory repoitory) {
        accRepo = repoitory;

        }
        [HttpPost("register")]
        public async Task<IActionResult> regidter(RegisterModel model)
        {
            var result = await accRepo.registerAsync(model);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(UserLogin userLogin)
        {
            var result = await accRepo.userLogin(userLogin);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
