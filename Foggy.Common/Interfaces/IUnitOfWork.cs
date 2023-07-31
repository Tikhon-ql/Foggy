using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
