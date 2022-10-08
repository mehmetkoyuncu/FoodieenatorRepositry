using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Entities.Entities
{
    public class ProjectSettings:BaseEntity
    {
        public string Name { get; set; }
        public string InfoText { get; set; }
    }
}
