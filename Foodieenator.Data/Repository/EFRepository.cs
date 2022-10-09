using Foodieenator.Data.Context;
using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Data.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbset;

        public EFRepository(EfContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context boş olamaz.");

            _context = context;
            _dbset = context.Set<TEntity>();

        }
        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbset.Where(filter);
        }

        public List<TEntity> GetAll()
        {
            return _dbset.ToList();
        }

        public void HardDelete(TEntity entity)
        {
            _dbset.Remove(entity);
        }


        public void Update(TEntity entity)
        {
            _dbset.AsNoTracking();
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
