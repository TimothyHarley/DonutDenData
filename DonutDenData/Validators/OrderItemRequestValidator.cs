using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutDenData.Models;

namespace DonutDenData.Validators
{
    public class OrderItemRequestValidator
    {
        public bool Validate(CreateOrderItemRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.ItemId.ToString())
                    || string.IsNullOrEmpty(requestToValidate.OrderId.ToString())
                    || string.IsNullOrEmpty(requestToValidate.Quantity.ToString())
                    || string.IsNullOrEmpty(requestToValidate.UnitPrice.ToString()));
        }
    }
}
