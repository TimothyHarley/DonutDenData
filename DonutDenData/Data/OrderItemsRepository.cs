using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using DonutDenData.Models;

namespace DonutDenData.Data
{
    public class OrderItemsRepository
    {
        const string ConnectionString = "Server=localhost; Database=PartingPets; Trusted_Connection=True;";

        public OrderItem AddOrderItem(CreateOrderItemRequest newOrderItemObj)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newOrderItemQuery = db.QueryFirstOrDefault<OrderItem>(
                    @"Insert into OrderItem (orderId, itemId, quantity, unitPrice, specialRequest)
                    Output inserted.*
                    Values(@orderId,@itemId,@quantity,@unitPrice,@specialRequest)",
                    new
                    {
                        newOrderItemObj.OrderId,
                        newOrderItemObj.ItemId,
                        newOrderItemObj.Quantity,
                        newOrderItemObj.UnitPrice,
                        newOrderItemObj.SpecialRequest
                    });
                if (newOrderItemQuery != null)
                {
                    return newOrderItemQuery;
                }
                throw new Exception("No OrderItem Found");
            }
        }

        public IEnumerable<OrderItem> GetByOrderId(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var orderIdQuery = "select * from OrderItem where OrderItem.OrderId = @id";

                return db.Query<OrderItem>(orderIdQuery, new { id });
            }
        }

        public OrderItem GetSingleOrderItem(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.QueryFirstOrDefault<OrderItem>("select * from OrderItem where OrderItem.id = @id", new { id });
            }
        }

        public OrderItem UpdateOrderItem(OrderItem OrderItemToUpdate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var updateOrderItemQuery = @"Update OrderItem
                                            Set OrderId = @orderId,
                                            ItemId = @itemId,
                                            Quantity = @quantity,
                                            UnitPrice = @unitPrice,
                                            SpecialRequest = @specialRequest";

                var rowsAffected = db.Execute(updateOrderItemQuery, OrderItemToUpdate);

                if (rowsAffected == 1)
                {
                    return OrderItemToUpdate;
                }
                throw new Exception("Failed to update your Item");
            }
        }

        public void DeleteOrderItem(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var parameter = new { Id = id };
                var deleteQuery = "Delete from OrderItem where Id = @id";
                var rowsAffected = db.Execute(deleteQuery, parameter);

                if (rowsAffected != 1)
                {
                    throw new Exception("Failed to delete your Item.");
                }
            }
        }
    }
}
