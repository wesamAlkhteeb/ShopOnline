using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Application.Services.interfaces;
using ShopOnline.API.Domain.Models.Account;

namespace ShopOnline.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            return Ok(await accountService.Login(loginModel));   
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            return Ok(await accountService.Register(registerModel));
        }

    }
}
