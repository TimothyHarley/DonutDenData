using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutDenData.Models;

namespace DonutDenData.Validators
{
    public class CookTypeRequestValidator
    {
        public bool Validate(CreateCookTypeRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.UserId.ToString())
                    || string.IsNullOrEmpty(requestToValidate.CategoryId.ToString()));
        }
    }
}
