using Microsoft.EntityFrameworkCore;
using Soccernation.Models;
using Soccernation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Soccernation.Controllers
{
    public class ApplicationRepository<T> : IApplicationRepository<T> where T : class, IEntity
    {
        public SoccernationContext _context;

        public ApplicationRepository(SoccernationContext context)
        {
            _context = context;
        }

        IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        T Get(Guid id)
        {
            return Get().SingleOrDefault(e => e.Id == id);
        }

        public void Create(T record)
        {
            record.Id = Guid.NewGuid();
            record.CreatedOnUtc = DateTime.UtcNow;
            record.ModifiedOnUtc = record.CreatedOnUtc;
            _context.Add(record);
        }

        public void Update(T record)
        {
            record.ModifiedOnUtc = DateTime.UtcNow;
            //_context.Set<T>().Attach(record);
            _context.Entry(record).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var record = Get(id);

            if (record != null)
            {
                _context.Entry(record).State = EntityState.Deleted;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        #endregion
    }
}
