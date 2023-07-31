using Foggy.Bots.TelegramBots;
using Foggy.DataProvider.Models.Identity;
using Foggy.DataProvider.Models.SocialNetworks;
using Foggy.NotificationSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Foggy.NotificationSystem.Senders
{
    public class TelegramSender : ISender
    {
        private ITelegramBotClient _botClient;

        public TelegramSender(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task Send(User user, string message)
        {
            if (user.SocialNetworkToNotify is TelegramSN)
            {
                var tg = user.SocialNetworkToNotify as TelegramSN;
                await _botClient.SendTextMessageAsync(tg.ChatId,message);
            }
        }
    }
}
