using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider.Models.Identity
{
    public class User : BaseEntity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public virtual SocialNetwork SocialNetworkToNotify { get; set;}
        [Required]
        public virtual UserRefreshToken RefreshToken { get; set; }
        public virtual List<ToRemember>? ToRemembers { get; set; }
    }
}
