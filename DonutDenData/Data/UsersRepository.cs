using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using DonutDenData.Models;

namespace DonutDenData.Data
{
    public class UsersRepository
    {
        const string ConnectionString = "Server=localhost; Database=DonutDen; Trusted_Connection=True;";

        public Users AddUser(CreateUserRequest newUserObj)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newUserQuery = db.QueryFirstOrDefault<Users>(@"
                    Insert into users (firebaseuid, firstname, lastname, email, phonenumber, isadmin, isdeleted
                    Output inserted.*
                    Values(@firebaseuid, @firstname, @lastname, @email, @phonenumber, @isadmin, @isdeleted",
                    new
                    {
                        newUserObj.FirebaseUid,
                        newUserObj.FirstName,
                        newUserObj.LastName,
                        newUserObj.Email,
                        newUserObj.PhoneNumber,
                        newUserObj.IsAdmin,
                        newUserObj.isDeleted
                    });
                if(newUserQuery != null)
                {
                    return newUserQuery;
                }

                throw new Exception("No User Found");
            }
        }

        public IEnumerable<Users> GetAllUsers()
        {

        }
    }
}
