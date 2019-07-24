using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutDenData.Models;

namespace DonutDenData.Validators
{
    public class OrdersRequestValidator
    {
        public bool Validate(CreateOrderRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.FirstName)
                || string.IsNullOrEmpty(requestToValidate.LastName)
                || string.IsNullOrEmpty(requestToValidate.Email)
                || string.IsNullOrEmpty(requestToValidate.PhoneNumber)
                || string.IsNullOrEmpty(requestToValidate.PickupDate.ToString())
                || string.IsNullOrEmpty(requestToValidate.PickupTime.ToString()));
        }
    }
}
