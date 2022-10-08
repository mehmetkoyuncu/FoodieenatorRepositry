using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Entities.Entities
{
    public class IndexPage:BaseEntity
    {
        public string MainImage { get; set; }
        public string SliderText1 { get; set; }
        public string SliderText2 { get; set; }
        public string SliderText3 { get; set; }
    }
}
