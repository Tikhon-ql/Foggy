using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Interfaces
{
    public interface INotificationService
    {
        Task SendMessage(string email, string message);

    }
}
