using Foodieenator.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Entities.Entities
{
    public class Reservation:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsApprove { get; set; }
        public bool IsCancellationReservation{ get; set; }
        public bool IsSeen { get; set; }
    }
}
