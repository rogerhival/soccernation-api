using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation.Controllers
{
    public interface IApplicationRepository<T> : IDisposable
    {
        IQueryable<T> Get();

        T Get(Guid id);

        void Create(T record);

        void Update(T record);

        void Delete(Guid id);

        int Save();

        Task<int> SaveAsync();
    }
}
