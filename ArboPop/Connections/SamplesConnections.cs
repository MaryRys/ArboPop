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

        public IEnumerable<Sample> getAllUserSamples(int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"SELECT *
                                FROM [Sample]
                                WHERE userId = @userId";
                var samples = connection.Query<Sample>(queryString, new { userId }).ToList();
                return samples;
            }
        }

        public Sample AddNewSample(AddNewSample newSample)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                newSample.date = DateTime.Now;
                var queryString = @"INSERT into [Sample](userId, numOfSpecies, date, totalNum, zipcode, trapType, lure)
                                    Output inserted.*
                                    Values(@userId, @numOfSpecies, @date, @totalNum, @zipcode, @trapType, @lure)";
                var sample = connection.QueryFirstOrDefault<Sample>(queryString, newSample);
                if (sample != null)
                {
                    return sample;
                }
                throw new Exception("Error, can't add the sample");
            }
        }

        public Sample DeleteSample(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"DELETE 
                                    FROM[Sample]
                                    Output deleted.*
                                    WHERE id = @id";
                var sample = connection.QueryFirstOrDefault<Sample>(queryString, new { id });
                if (sample != null)
                {
                    return sample;
                }
                throw new Exception("Unable to delete that sample");
            }
        }
    }
}
