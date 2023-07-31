using Foggy.ToRememberChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.ToRememberChecker
{
    public interface IToRememberChecker
    {
        Task IsCountinue(ToRememberCheckModel model);
    }
}
