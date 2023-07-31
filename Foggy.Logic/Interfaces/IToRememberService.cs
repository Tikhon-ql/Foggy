using Foggy.Logic.Models;
using Foggy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Interfaces
{
    public interface IToRememberService
    {
        Task AddToRemember(ToRememberDto toRemember);
    }
}
