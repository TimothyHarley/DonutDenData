using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutDenData.Models;

namespace DonutDenData.Validators
{
    public class UsersRequestValidator
    {
        public bool Validate(CreateUserRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.FirstName)
                || string.IsNullOrEmpty(requestToValidate.LastName)
                || string.IsNullOrEmpty(requestToValidate.FirebaseUid));
        }
    }
}
