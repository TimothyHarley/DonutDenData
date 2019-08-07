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
        const string ConnectionString = "Server=localhost; Database=DonutDen; Trusted_Connection=True;";

        public Orders AddOrder(CreateOrderRequest newOrderObj)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newOrderQuery = db.QueryFirstOrDefault<Orders>(@"
                    Insert into Orders (firstName, lastName, email, phoneNumber, pickupDate, pickupTime, isApproved, approvedBy, isDeleted)
                    Output inserted.*
                    Values(@firstName,@lastName,@email,@phoneNumber,@pickupDate,@pickupTime,@isApproved,@approvedBy,0)",
                    new
                    {
                        newOrderObj.FirstName,
                        newOrderObj.LastName,
                        newOrderObj.Email,
                        newOrderObj.PhoneNumber,
                        newOrderObj.PickupDate,
                        newOrderObj.PickupTime,
                        newOrderObj.IsApproved,
                        newOrderObj.ApprovedBy,
                        newOrderObj.IsDeleted
                    });
                if (newOrderQuery != null)
                {
                    return newOrderQuery;
                }

                throw new Exception("No Order Found");
            }
        }

        public IEnumerable<OrdersForDisplay> GetOrdersByDate(DateTime date)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var orderByDateQuery = @"select i.id, o.FirstName, o.LastName, o.PickUpDate, o.PickUpTime, o.PhoneNumber, o.Email, o.isDeleted, o.isApproved, o.ApprovedBy, i.Quantity, m.Name, m.Category from Orders o
                                        left join OrderItem i on o.id = i.OrderId
                                        left join MenuItem m on i.ItemId = m.Id
                                        where o.pickupDate = @date and o.isDeleted = 0";

                return db.Query<OrdersForDisplay>(orderByDateQuery, new { date });
            }
        }

        public Orders GetSingleOrder(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.QueryFirstOrDefault<Orders>("select * from Orders where Orders.Id = @id", new { id });
            }
        }

        public Orders UpdateOrder(Orders OrderToUpdate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var updateOrderQuery = @"Update Orders
                                        Set FirstName = @firstName,
                                        LastName = @lastName,
                                        Email = @email,
                                        PhoneNumber = @phoneNumber,
                                        PickupDate = @pickupDate,
                                        PickupTime = @pickupTime,
                                        IsApproved = @isApproved,
                                        ApprovedBy = @approvedBy,
                                        IsDeleted = @isDeleted";
                var rowsAffected = db.Execute(updateOrderQuery, OrderToUpdate);

                if(rowsAffected == 1)
                {
                    return OrderToUpdate;
                }
                throw new Exception("Failed to update your order");
            }
        }

        public void DeleteOrder(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var updateOrderQuery = @"Update Order
                                        Set isDeleted = 1
                                        Where id = @id";

                var rowsAffected = db.Execute(updateOrderQuery, new { id });

                if(rowsAffected != 1)
                {
                    throw new Exception("Failed to delete your order");
                }
            }

        }
    }
}
