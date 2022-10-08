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
    public class DiscountedFoodService:IService<DiscountedFood>
    {
        IUnitOfWork _uow;
        public DiscountedFoodService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }

        public void AddOrUpdate(DiscountedFood entity)
        {
            var discountedFood = GetById(entity.Id);
            if (discountedFood == null)
                _uow.GetRepository<DiscountedFood>().Add(entity);
            else
            {
                discountedFood.DiscountedRate = discountedFood.DiscountedRate;
                discountedFood.FoodId = discountedFood.FoodId;
                _uow.GetRepository<DiscountedFood>().Update(discountedFood);
            }

            _uow.SaveChanges();
        }

        public List<DiscountedFood> GetAll()
        {
            List<DiscountedFood> discountedFood = _uow.GetRepository<DiscountedFood>().GetAll();
            return discountedFood;
        }

        public DiscountedFood GetById(int id)
        {
            DiscountedFood discountedFood = _uow.GetRepository<DiscountedFood>().Get(x => x.Id == id).FirstOrDefault();
            return discountedFood;
        }

        public void HardDelete(DiscountedFood entity)
        {
            var discountedFood = GetById(entity.Id);
            _uow.GetRepository<DiscountedFood>().HardDelete(discountedFood);
            _uow.SaveChanges();
        }
    }
}
