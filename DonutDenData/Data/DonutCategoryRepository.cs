using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using DonutDenData.Models;

namespace DonutDenData.Data
{
    public class DonutCategoryRepository
    {
        const string ConnectionString = "Server=localhost; Database=DonutDen; Trusted_Connection=True;";

        public IEnumerable<DonutCategory> GetAllDonutCategories()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<DonutCategory>("select * from donutCategory");
            }
        }

        public DonutCategory GetDonutCategoryById(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.QueryFirstOrDefault<DonutCategory>("select * from donutCategory where id = @id", new { id });
            }
        }
    }
}
