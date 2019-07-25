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
            var queryString = @"Select *
                                    From [Activity]";
            var products = connection.Query<complaint>(queryString).ToList();
            return products;
        }


    }
}
