using Foodieenator.Data.Context;
using Foodieenator.Data.UnitOfWork;
using Foodieenator.Entities.Entities;
using Foodieenator.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Service.Concrete
{
    public class FoodCategoryService : IService<FoodCategory>
    {
        IUnitOfWork _uow;
        public FoodCategoryService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }
        public void AddOrUpdate(FoodCategory entity)
        {
            var foodCategory = GetById(entity.Id);
            if (foodCategory == null)
                _uow.GetRepository<FoodCategory>().Add(entity);
            else
            {
                foodCategory.Name = entity.Name;
                _uow.GetRepository<FoodCategory>().Update(foodCategory);
            }

            _uow.SaveChanges();
        }

        public List<FoodCategory> GetAll()
        {
            List<FoodCategory> foodCategorys = _uow.GetRepository<FoodCategory>().GetAll();
            return foodCategorys;
        }

        public FoodCategory GetById(int id)
        {
            FoodCategory foodCategory = _uow.GetRepository<FoodCategory>().Get(x => x.Id == id).FirstOrDefault();
            return foodCategory;
        }

        public void HardDelete(FoodCategory entity)
        {
            var foodCategory = GetById(entity.Id);
            _uow.GetRepository<FoodCategory>().HardDelete(foodCategory);
            _uow.SaveChanges();
        }
    }
}
