using Foggy.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.NotificationSystem.Interfaces
{
    public interface ISender 
    {
        Task Send(User user, string message);
    }
}
