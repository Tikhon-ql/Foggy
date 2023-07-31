using Foggy.Common.Enums;
using Foggy.ViewModels.SocialNetworks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public TelegramViewModel SocialNetwork { get; set; }
    }
}
