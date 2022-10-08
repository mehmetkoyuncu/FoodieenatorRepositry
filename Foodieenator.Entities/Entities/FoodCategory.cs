using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Entities.Entities
{
   public class FoodCategory:BaseEntity
    {
        public FoodCategory()
        {
            Foods = new List<Food>();
        }
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
