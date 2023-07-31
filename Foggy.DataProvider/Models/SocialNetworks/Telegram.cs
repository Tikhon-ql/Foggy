using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider.Models.SocialNetworks
{
    public class TelegramSN: SocialNetwork
    {
        public TelegramSN()
        {
            Type = Common.Enums.SocialNetworkType.Telegram;
        }
        
        public long ChatId { get;set; }
    }
}
