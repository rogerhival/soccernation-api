using Microsoft.EntityFrameworkCore;
using Soccernation.Models;
using Soccernation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<T> Get()
        {
            return _context.Set<T>().Where(e => e.Status != EntityStatus.Deleted);
        }

        public T Get(Guid id)
        {
            return Get().SingleOrDefault(e => e.Id == id);
        }

        public void Create(T record)
        {
            record.Id = Guid.NewGuid();
            record.CreatedOnUtc = DateTime.UtcNow;
            record.ModifiedOnUtc = record.CreatedOnUtc;
            record.Status = EntityStatus.Active;
            _context.Add(record);
        }

        public void Update(T record)
        {
            record.ModifiedOnUtc = DateTime.UtcNow;
            _context.Set<T>().Attach(record);
            _context.Entry(record).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var record = Get(id);

            if (record != null)
            {
                record.ModifiedOnUtc = DateTime.UtcNow;
                record.Status = EntityStatus.Deleted;
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
