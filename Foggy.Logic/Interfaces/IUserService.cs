using Foggy.Logic.Models;
using Foggy.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.Logic.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUser(RegisterViewModel viewModel);
        Task<bool> ValidateUser(string email, string password);
    }
}
