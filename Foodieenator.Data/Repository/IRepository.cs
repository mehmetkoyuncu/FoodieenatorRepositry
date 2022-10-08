using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetAll();
        void HardDelete(TEntity entity);
    }
}
