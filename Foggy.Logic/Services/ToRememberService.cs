using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Models;
using Foggy.Logic.Interfaces;
using Foggy.Logic.Models;
using Foggy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Services
{
    public class ToRememberService : IToRememberService
    {
        private IToRememberRepository _toRememberRepository;
        private IUserRepository _userRepository;
        public ToRememberService(IToRememberRepository toRememberRepository, IUserRepository userRepository)
        {
            _toRememberRepository = toRememberRepository;
            _userRepository = userRepository;
        }

        public async Task AddToRemember(ToRememberDto toRemember)
        {
            var newToRemeber = new ToRemember { Name = toRemember.Name, UserId = toRemember.UserId };
            await _toRememberRepository.Create(newToRemeber);
            var user = await _userRepository.GetById(toRemember.UserId);
            if(user == null)
            {
                //TODO:AAAAAAAAAAAAAA
                throw new Exception();
            }
            user.ToRemembers.Add(newToRemeber);
        }
    }
}
