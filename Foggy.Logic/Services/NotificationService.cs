using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Repository;
using Foggy.Logic.Interfaces;
using Foggy.NotificationSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Services
{
    public class NotificationService : INotificationService
    {
        private ISender _sender;
        private IUserRepository _userRepository;

        public NotificationService(ISender sender, IUserRepository userRepository)
        {
            _sender = sender;
            _userRepository = userRepository;
        }

        public async Task SendMessage(string email, string message)
        {
            var user = await _userRepository.GetByEmail(email);

            await _sender.Send(user, message);
        }
    }
}
