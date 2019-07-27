using Microsoft.Extensions.Options;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArboPop.Models.User;
using ArboPop.Interface;
using System.Data.SqlClient;

namespace ArboPop.Connections
{
    public class UserRepo
    {
        //readonly string _connectionString;
        const string _connectionString = "Server=localhost;Database=ArboPop;Trusted_Connection=True;";

        //public UserRepo(IOptions<DbConfiguration> dbConfig)
        //{
        //    _connectionString = dbConfig.Value.ConnectionString;
        //}

        public ISingleUser GetUser(string uid)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                string selectQuery = @"SELECT *
                                       FROM User
                                       WHERE uid = @uid";
                var parameters = new { uid = uid };

                var user = db.QuerySingleOrDefault<User>(selectQuery, parameters);

                if (user != null)
                {
                    return user;
                }
            }
            throw new Exception("We could not retreive that User from the database");
        }
    }
}
