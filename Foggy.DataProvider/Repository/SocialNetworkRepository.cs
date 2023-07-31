using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider.Repository
{
    internal class SocialNetworkRepository : BaseRepository<SocialNetwork>, ISocialNetworkRepository
    {
        public SocialNetworkRepository(AppDbContext context) : base(context)
        {
        }
    }
}
