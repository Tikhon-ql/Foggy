using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Models.Identity;
using Foggy.Logic.Interfaces;
using Foggy.Logic.Models;
using Foggy.ViewModels;
using Foggy.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private ITokenService _tokenService;
        private IUserService _userService;
        private IUserRefreshTokenRepository _userRefreshTokenRepository;
        public AuthenticateService(ITokenService tokenService, IUserService userService, IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            _tokenService = tokenService;
            _userService = userService;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<Token> LoginUser(LoginViewModel viewModel)
        {
            if(await _userService.ValidateUser(viewModel.Email,viewModel.Password))
            {
                var token = await _tokenService.GenerateToken(new UserDto { Email = viewModel.Email });
                return token;
            }
            throw new Exception();
        }
    }
}
