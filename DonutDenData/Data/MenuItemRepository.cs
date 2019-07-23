using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using DonutDenData.Models;

namespace DonutDenData.Data
{
    public class MenuItemRepository
    {
        const string ConnectionString = "Server=localhost; Database=PartingPets; Trusted_Connection=True;";

        public IEnumerable<MenuItem> GetMenu()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<MenuItem>("select * from menuItem");
            }
        }

        public IEnumerable<MenuItem> GetMenuByCategory(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<MenuItem>("select * from menuItem where menuItem.category = @id", new { id });
            }
        }

        public MenuItem GetSingleMenuItem(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.QueryFirstOrDefault<MenuItem>("slect * from menuItem where menuItem.id = @id", new { id });
            }
        }
    }
}
