using Foodieenator.Data.Repository;
using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity ,new();
        int SaveChanges();
    }
}
