using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.CheckSystem.Interfaces
{
    public interface IChecker
    {
        Task<bool> IsCompleted(string name);
    }
}
