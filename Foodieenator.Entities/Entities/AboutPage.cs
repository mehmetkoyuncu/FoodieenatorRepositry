using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Entities.Entities
{
    public class AboutPage:BaseEntity
    {
        public string AboutImage { get; set; }
        public string AboutText { get; set; }
    }
}
