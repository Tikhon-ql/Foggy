using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get;set; }
        public SocialNetworkToNotifyDto SocialNetworkToNotify { get; set; }  

        public List<ToRememberDto>? ToRemembers { get; set; }
    }
}
