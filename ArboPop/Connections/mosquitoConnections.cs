using ArboPop.Models.Mosquito;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArboPop.Connections
{
    public class mosquitoConnections
    {
        readonly string ConnectionString;

        public mosquitoConnections(IOptions<DbConfiguration> dbConfig)
        {
            ConnectionString = dbConfig.Value.ConnectionString;
        }

        public IEnumerable<Mosquito> getAllMosquitoes()
        {
            var connection = new SqlConnection(ConnectionString);
            var queryString = @"SELECT *
                                FROM [Species]";
            var mosquito = connection.Query<Mosquito>(queryString).ToList();
            return mosquito;
        }

        public Mosquito getSingleMosquito(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"SELECT *
                                    FROM [Species]
                                    WHERE Id = @Id";
                var mosquito = connection.QueryFirstOrDefault<Mosquito>(queryString, new { id });
                if (mosquito != null)
                {
                    return mosquito;
                }
                throw new Exception("Can't find the species you are looking for");
            }
        }

        //public IEnumerable<complaint> getAllUserComplaints(int userId)
        //{
        //    using (var connection = new SqlConnection(ConnectionString))
        //    {
        //        var queryString = @"SELECT *
        //                        FROM [Activity]
        //                        WHERE userId = @userId";
        //        var products = connection.Query<complaint>(queryString, new { userId }).ToList();
        //        return products;
        //    }
        //}

        //public complaint AddNewComplaint(NewComplaint newComplaint)
        //{
        //    using (var connection = new SqlConnection(ConnectionString))
        //    {
        //        newComplaint.creationDate = DateTime.Now;
        //        var queryString = @"INSERT into [Activity](userId, creationDate, timeOfDay, zipcode, bitingSource, addtlNotes)
        //                            Output inserted.*
        //                            Values(@userId, @creationDate, @timeOfDay, @zipcode, @bitingSource, @addtlNotes)";
        //        var complaint = connection.QueryFirstOrDefault<complaint>(queryString, newComplaint);
        //        if (complaint != null)
        //        {
        //            return complaint;
        //        }
        //        throw new Exception("Error, can't add the submission");
        //    }
        //}

        //public complaint DeleteComplaint(int id)
        //{
        //    using (var connection = new SqlConnection(ConnectionString))
        //    {
        //        var queryString = @"DELETE 
        //                            FROM [Activity]
        //                            Output deleted.*
        //                            WHERE id = @id";
        //        var order = connection.QueryFirstOrDefault<complaint>(queryString, new { id });
        //        if (order != null)
        //        {
        //            return order;
        //        }
        //        throw new Exception("Unable to delete that submission");
        //    }
        //}
    }
}
