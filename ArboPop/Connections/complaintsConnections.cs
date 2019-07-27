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

        public complaint AddNewComplaint(NewComplaint newComplaint)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                newComplaint.creationDate = DateTime.Now;
                var queryString = @"INSERT into [Activity](userId, creationDate, timeOfDay, zipcode, bitingSource, addtlNotes)
                                    Output inserted.*
                                    Values(@userId, @creationDate, @timeOfDay, @zipcode, @bitingSource, @addtlNotes)";
                var complaint = connection.QueryFirstOrDefault<complaint>(queryString, newComplaint);
                if (complaint != null)
                {
                    return complaint;
                }
                throw new Exception("Error, can't add the submission");
            }
        }

        public complaint DeleteComplaint(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"DELETE 
                                    FROM [Activity]
                                    Output deleted.*
                                    WHERE id = @id";
                var order = connection.QueryFirstOrDefault<complaint>(queryString, new { id });
                if (order != null)
                {
                    return order;
                }
                throw new Exception("Unable to delete that submission");
            }
        }
    }
}
