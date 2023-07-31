using Foggy.CheckSystem.Interfaces;
using Foggy.Common.Interfaces;
using Foggy.Logic.Interfaces;
using Foggy.Logic.Models;
using Foggy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Foggy.Api.Controllers
{
    [ApiController]
    [Route("/toRemember")]
    public class ToRememberController : BaseController
    {
        private IToRememberService _toRememberService;
        private INotificationService _notificationService;
        private IChecker _checker;
        public ToRememberController(IToRememberService toRememberService, IUnitOfWork unitOfWork, INotificationService notificationService, IChecker checker) : base(unitOfWork)
        {
            _toRememberService = toRememberService;
            _notificationService = notificationService;
            _checker = checker;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddToRemember(ToRememberAddingViewModel viewModel)
        {
            var userId = Guid.Parse(User.Claims.First(u=>u.Type == JwtRegisteredClaimNames.Sid).Value);
            await _toRememberService.AddToRemember(new ToRememberDto { UserId = userId, Name = viewModel.Name});
            return await ReturnSuccess();
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessageToTg(string email ,string message)
        {
            await _notificationService.SendMessage(email, message);
            return Ok();
        }
        [HttpPost("check")]
        public async Task<IActionResult> SendMessageToTg(string name)
        {
            await _checker.IsCompleted(name);
            return Ok();
        }
    }
}
