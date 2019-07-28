using ArboPop.Models.Sample;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArboPop.Connections
{
    public class SamplesConnections
    {
        readonly string ConnectionString;

        public SamplesConnections(IOptions<DbConfiguration> dbConfig)
        {
            ConnectionString = dbConfig.Value.ConnectionString;
        }

        public IEnumerable<Sample> getAllSamples()
        {
            var connection = new SqlConnection(ConnectionString);
            var queryString = @"SELECT *
                                FROM [Sample]";
            var samples = connection.Query<Sample>(queryString).ToList();
            return samples;
        }

        public Sample getSingleSample(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"SELECT *
                                    FROM [Sample]
                                    WHERE Id = @Id";
                var sample = connection.QueryFirstOrDefault<Sample>(queryString, new { id });
                if (sample != null)
                {
                    return sample;
                }
                throw new Exception("Can't find the sample you are looking for");
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
