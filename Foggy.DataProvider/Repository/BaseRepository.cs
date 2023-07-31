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
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DbSet<T> _set;
        protected AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _set = _context.Set<T>(); ;
        }

        public virtual async Task Create(T entity)
        {
            await _context.AddAsync(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception();
            _context.Remove(entity);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            var entity = await _set.FirstOrDefaultAsync(e=>e.Id == id);
            return entity;
        }
    }
}
