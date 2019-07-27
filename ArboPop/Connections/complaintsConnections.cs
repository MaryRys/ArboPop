using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ArboPop.Models;
using ArboPop.Models.Complaints;
using Dapper;
using Microsoft.Extensions.Options;

namespace ArboPop.Connections
{
    public class ComplaintsConnections
    {
        //const string _connectionString = "Server=localhost;Database=ArboPop;Trusted_Connection=True;";

        readonly string ConnectionString;

        public ComplaintsConnections(IOptions<DbConfiguration> dbConfig)
        {
            ConnectionString = dbConfig.Value.ConnectionString;
        }

        public IEnumerable<complaint> getAllComplaints()
        {
            var connection = new SqlConnection(ConnectionString);
            var queryString = @"SELECT *
                                FROM [Activity]";
            var products = connection.Query<complaint>(queryString).ToList();
            return products;
        }

        public complaint getSingleComplaint(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"SELECT *
                                    FROM [Activity]
                                    WHERE Id = @Id";
                var complaint = connection.QueryFirstOrDefault<complaint>(queryString, new { id });
                if (complaint != null)
                {
                    return complaint;
                }
                throw new Exception("Can't find the submission you are looking for");
            }
        }

        public IEnumerable<complaint> getAllUserComplaints(int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"SELECT *
                                FROM [Activity]
                                WHERE userId = @userId";
                var products = connection.Query<complaint>(queryString, new { userId }).ToList();
                return products;
            }
        }


    }
}
