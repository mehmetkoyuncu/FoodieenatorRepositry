using Foodieenator.Data.Context;
using Foodieenator.Data.Repository;
using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EfContext _context;
        public EFUnitOfWork(EfContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context boş olamaz");
            _context = context;
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            this.disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            return new EFRepository<TEntity>(_context);
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
