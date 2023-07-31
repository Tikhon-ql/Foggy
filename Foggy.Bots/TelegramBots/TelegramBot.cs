using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Models.SocialNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Foggy.Bots.TelegramBots
{
    public class TelegramBot
    {
        public ITelegramBotClient botClient { get; }
        private IUserRepository _userRepository;
        private static Tuple<long, bool> _emailWaiting = new Tuple<long, bool>(0,false);

        public TelegramBot(ITelegramBotClient botClient, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this.botClient = botClient;

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };

            botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Enter your email: ");
                    _emailWaiting = new Tuple<long, bool>(message.Chat.Id, true);
                    return;
                }
                if (_emailWaiting.Item2 && _emailWaiting.Item1 == message.Chat.Id)
                {
                    _emailWaiting = new Tuple<long, bool>(message.Chat.Id, false);
                    string email = message.Text;
                    //var user = await _userRepository.GetByEmail(email);
                    //if(user != null && ((TelegramSN)user.SocialNetworkToNotify).ChatId == 0)
                    //{
                    //    ((TelegramSN)user.SocialNetworkToNotify).ChatId = message.Chat.Id;
                    //}
                    Console.WriteLine("Hello world");
                }
                await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
