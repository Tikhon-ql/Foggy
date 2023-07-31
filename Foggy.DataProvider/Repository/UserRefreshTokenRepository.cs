using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider.Repository
{
    public class UserRefreshTokenRepository : BaseRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<UserRefreshToken?> GetByValue(string refreshToken) => await _context.RefreshTokens.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
    }
}
