using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Entities.Entities
{
    public class DiscountedFood:BaseEntity
    {
        public virtual int FoodId { get; set; }
        public int DiscountedRate { get; set; }
        public Food Food { get; set; }
    }
}
