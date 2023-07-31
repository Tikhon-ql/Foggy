using Foggy.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foggy.Api.Controllers
{
    public abstract class BaseController: ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async Task<IActionResult> ReturnSuccess()
        {
            await _unitOfWork.Commit();
            return Ok();
        }
        protected async Task<IActionResult> ReturnSuccess<T>(T data)
        {
            await _unitOfWork.Commit();
            return Ok(data);
        }
    }
}
