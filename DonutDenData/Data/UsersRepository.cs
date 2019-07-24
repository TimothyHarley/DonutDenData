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
                        newUserObj.IsDeleted
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
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Users>("select * from users");
            }
        }

        public IEnumerable<Users> GetSingleUser(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Users>("select * from users where users.Id = @id", new { id });
            }
        }

        public Users UpdateUser(Users userToUpdate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var updateUserQuery = @"update users
                                      Set FirstName = @firstName,
                                      LastName = @lastName,
                                      Email = @email,
                                      IsAdmin = @isAdmin"
                var rowsAffected = db.Execute(updateUserQuery, userToUpdate);

                if (rowsAffected == 1)
                {
                    return userToUpdate;
                }
                throw new Exception("Failed to update user");
            }
        }

        public void DeleteUser(int id)
        {
            using (var db =  new SqlConnection(ConnectionString))
            {
                var deleteUserQuery = @"Update Users
                                        Set isDeleted = 1
                                        Where id = @id";

                var rowsAffected = db.Execute(deleteUserQuery, new { id });
                
                if (rowsAffected != 1)
                {
                    throw new Exception("Failed to delete user");
                }
            }
        }
    }
}
