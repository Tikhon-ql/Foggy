using Foggy.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.ViewModels.SocialNetworks
{
    public abstract class SocialNetworkViewModel
    {
        public SocialNetworkType Type { get; set; }
        public SocialNetworkViewModel()
        {

        }
    }
}
