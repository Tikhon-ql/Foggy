using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Models.Identity;
using Foggy.DataProvider.Repository;
using Foggy.Logic.Interfaces;
using Foggy.Logic.Models;
using Foggy.ViewModels;
using Foggy.ViewModels.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Services
{
    public class TokenService : ITokenService
    {
        private IUserRefreshTokenRepository _tokenRepository;
        private IUserRepository _userRepository;
        private IConfiguration _configuration;
        private IUserRefreshTokenRepository _userRefreshTokenRepository;
        public TokenService(IUserRefreshTokenRepository tokenRepository,IUserRepository userRepository, IConfiguration configuration,IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<Token> GenerateToken(UserDto user)
        {
            var apiUser = await _userRepository.GetByEmail(user.Email);

            var refreshToken = GenerateRefreshToken();
            var accessToken = GenerateAccessToken(apiUser);

            var userRefreshToken = new UserRefreshToken { RefreshToken = refreshToken, Expiration = DateTime.UtcNow.AddDays(2), UserId = apiUser.Id };
            await _tokenRepository.Create(userRefreshToken);

            return new Token
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private string GenerateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            //Add token settings to work with config.

            int accessTokenExpirationTimeInMinutes = int.Parse(_configuration["AccessTokenSettings:ExpirationTimeMin"]);

            var accessToken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(accessTokenExpirationTimeInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<Token> RefreshToken(RefreshTokenViewModel viewModel)
        {
            //TODO:BAD
            var refreshToken = await _userRefreshTokenRepository.GetByValue(viewModel.RefreshToken);
            if (!(await ValidateRefreshToken(viewModel)))
            {
                //TODO:AAAAAA
                throw new Exception();
            }

            var isRefreshTokenExpired = await IsRefreshTokenExpired(refreshToken);
            if (isRefreshTokenExpired)
            {
                return await GenerateToken(new UserDto { Email = refreshToken.User.Email });
            }
            else
            {
                return new Token
                {
                    RefreshToken = viewModel.RefreshToken,
                    AccessToken = GenerateAccessToken(refreshToken.User)
                };
            }
        }

        private async Task<bool> ValidateRefreshToken(RefreshTokenViewModel viewModel)
        {
            //TODO:BAD
            var refreshToken = await _userRefreshTokenRepository.GetByValue(viewModel.RefreshToken);
            if (refreshToken == null || await IsRefreshTokenExpired(refreshToken))
            {
                return false;
            }
            var userId = GetIdFromAccessToken(viewModel.AccessToken);

            if (userId != refreshToken.UserId)
                return false;
            return true;
        }

        private Guid GetIdFromAccessToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken;
            jwtSecurityToken = handler.ReadJwtToken(accessToken);

            var claim = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "sid");

            if (!Guid.TryParse(claim.Value, out Guid userId))
            {
                //TODO:AAAAAAAAAAAA
                throw new Exception();
            }
            return userId;
        }

        private async Task<bool> IsRefreshTokenExpired(UserRefreshToken userRefreshToken)
        {
            int beforeMinutes = int.Parse(_configuration["RefreshTokenSettings:TimeToCheckBeforeRefreshTokenExpiredMin"]);
            var isRefreshTokenExpired = DateTime.UtcNow.AddMinutes(beforeMinutes) >= userRefreshToken.Expiration;
            return isRefreshTokenExpired;
        }
    }
}
