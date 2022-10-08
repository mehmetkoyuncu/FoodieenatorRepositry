using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Service.Abstract
{
    public interface IService<TEntity>
    {
        void AddOrUpdate(TEntity entity);
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void HardDelete(TEntity entity);
    }
}
