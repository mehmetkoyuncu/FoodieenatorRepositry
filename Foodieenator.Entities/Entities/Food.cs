using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Entities.Entities
{
    public class Food:BaseEntity
    {
        public Food()
        {
            DiscountedFoods = new List<DiscountedFood>();
        }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public ICollection<DiscountedFood> DiscountedFoods { get; set; }
    }
}
