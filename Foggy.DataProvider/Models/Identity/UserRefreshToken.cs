using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider.Models.Identity
{
    public class UserRefreshToken : BaseEntity
    {     
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public DateTime Expiration { get; set; }


        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
