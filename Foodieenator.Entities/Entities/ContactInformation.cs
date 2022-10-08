using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Entities.Entities
{
    public class ContactInformation:BaseEntity
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string WorkPeriod { get; set; }
        public string WorkHour { get; set; }
    }
}
