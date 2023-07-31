using Foggy.Common.Enums;
using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Models.Identity;
using Foggy.DataProvider.Models.SocialNetworks;
using Foggy.Logic.Interfaces;
using Foggy.Logic.Models;
using Foggy.ViewModels.Identity;
using Foggy.ViewModels.SocialNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ISocialNetworkRepository _socialNetworkRepository;
        public UserService(IUserRepository userRepository, ISocialNetworkRepository socialNetworkRepository)
        {
            _userRepository = userRepository;
            _socialNetworkRepository = socialNetworkRepository;
        }

        public async Task<Guid> CreateUser(RegisterViewModel viewModel)
        {
            var user = await _userRepository.GetByEmail(viewModel.Email);
            if (user == null)
            {
                var newUser = new User
                {
                    Id = Guid.NewGuid(),
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    Salt = "salt1"
                };
                switch (viewModel.SocialNetwork.Type)
                {
                    case SocialNetworkType.Telegram:
                        {
                            var tg = new TelegramSN { ChatId = ((TelegramViewModel)viewModel.SocialNetwork).ChatId };
                            tg.UserId = newUser.Id;
                            await _socialNetworkRepository.Create(tg);
                            newUser.SocialNetworkToNotify = tg;
                            break;
                        }
                }
                await _userRepository.Create(newUser);
                return newUser.Id;
            }
            //TODO:AAAAAAAAAAAA
            throw new Exception();
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null || user.Password != password)
                return false;
            return true;
        }
    }
}
