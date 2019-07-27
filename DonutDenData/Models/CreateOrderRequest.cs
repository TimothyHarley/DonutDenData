using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutDenData.Models
{
    public class CreateOrderRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PickupDate { get; set; }
        public string PickupTime { get; set; }
        public bool IsApproved { get; set; }
        public int ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
