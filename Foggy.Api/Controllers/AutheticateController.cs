using Foggy.Common.Interfaces;
using Foggy.Logic.Interfaces;
using Foggy.ViewModels;
using Foggy.ViewModels.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Foggy.Api.Controllers
{
    [ApiController]
    [Route("/authenticate")]
    public class AutheticateController: BaseController
    {
        private IUserService _userService;
        private IAuthenticateService _authenticateService;
        private ITokenService _tokenService;
        public AutheticateController(IUserService userService,IAuthenticateService authenticateService, IUnitOfWork unitOfWork, ITokenService tokenService) : base(unitOfWork)
        {
            _userService = userService;
            _authenticateService = authenticateService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var id = await _userService.CreateUser(viewModel);

            return await ReturnSuccess(id);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            var result = await _authenticateService.LoginUser(viewModel);
            return await ReturnSuccess(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenViewModel viewModel)
        {
            var result = await _tokenService.RefreshToken(viewModel);
            return await ReturnSuccess(result);
        }
    }
}
