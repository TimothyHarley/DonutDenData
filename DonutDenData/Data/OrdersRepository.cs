using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using DonutDenData.Models;

namespace DonutDenData.Data
{
    public class OrdersRepository
    {
        const string ConnectionString = "Server=localhost; Database=PartingPets; Trusted_Connection=True;";

        public Orders AddOrder(CreateOrderRequest newOrderObj)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newOrderQuery = db.QueryFirstOrDefault<Orders>(@"
                    Insert into Orders (firstName, lastName, email, phoneNumber, pickupDate, pickupTime, isApproved, approvedBy, isDeleted)
                    Output inserted.*
                    Values()")
            }
        }
    }
}
