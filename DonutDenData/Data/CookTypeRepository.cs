using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using DonutDenData.Models;

namespace DonutDenData.Data
{
    public class CookTypeRepository
    {
        const string ConnectionString = "Server=localhost; Database=PartingPets; Trusted_Connection=True;";

        public CookType AddCookType(CreateCookTypeRequest newCookTypeObj)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newCookTypeQuery = db.QueryFirstOrDefault<CookType>(@"
                                                                        Insert into CookType (userId, categoryId)
                                                                        Output inserted.*
                                                                        Values(@userId,@categoryId)",
                                                                        new
                                                                        {
                                                                            newCookTypeObj.UserId,
                                                                            newCookTypeObj.CategoryId
                                                                        });
                if (newCookTypeQuery != null)
                {
                    return newCookTypeQuery;
                }

                throw new Exception("No Cook Type Found");
            }
        }

        public IEnumerable<CookType> GetAllCookTypes()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<CookType>("select * from cookType");
            }
        }

        public IEnumerable<CookType> GetCookTypesByUser(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<CookType>("select * from cookType where cooktype.userId = @id", new { id });
            }
        }

        public IEnumerable<CookType> GetCookTypesByCategory(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<CookType>("select * from cookType where cookType.categoryId = @id", new { id });
            }
        }
    }
}
