using Foggy.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Models
{
    public class SocialNetworkToNotifyDto
    {
        public string Url { get; set; }
        public SocialNetworkType SocialNetwork { get; set; }
    }
}
