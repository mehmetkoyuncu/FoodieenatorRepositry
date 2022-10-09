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

	public class FoodService : IService<Food>
	{
		IUnitOfWork _uow;
		public FoodService()
		{
			_uow = new EFUnitOfWork(new EfContext());
		}

		public void AddOrUpdate(Food entity)
		{
			var food = GetById(entity.Id);
			if (food == null)
				_uow.GetRepository<Food>().Add(entity);
			else
			{
				if (string.IsNullOrEmpty(entity.Image) == false)
				{
					food.Image = entity.Image;
				}
				food.Name = entity.Name;
				food.Price = entity.Price;
				food.FoodCategoryId = entity.FoodCategoryId;
				food.Description = entity.Description;
				food.IsPublish = entity.IsPublish;
				_uow.GetRepository<Food>().Update(food);
			}

			_uow.SaveChanges();
		}

		public List<Food> GetAll()
		{
			List<Food> foods = _uow.GetRepository<Food>().GetAll();
			return foods;
		}

		public Food GetById(int id)
		{
			Food food = _uow.GetRepository<Food>().Get(x => x.Id == id).FirstOrDefault();
			return food;
		}

		public void HardDelete(Food entity)
		{
			var food = GetById(entity.Id);
			_uow.GetRepository<Food>().HardDelete(food);
			_uow.SaveChanges();
		}
	}
}
