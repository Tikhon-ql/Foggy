using Foggy.DataProvider.Interfaces;
using Foggy.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider.Repository
{
    public class ToRememberRepository : BaseRepository<ToRemember>, IToRememberRepository
    {
        public ToRememberRepository(AppDbContext context) : base(context)
        {
        }
    }
}
