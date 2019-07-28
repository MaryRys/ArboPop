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

        //Send post request as the following json in the body
         //   {
	        //"breedingHabitat" : "",
	        //"scientificName" : "",
	        //"commonName" : "",
	        //"confirmed" : int 1 or 0
         //    }
    public Mosquito AddNewMosquito(AddNewMosquito newMosquito)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"INSERT into [Species](breedingHabitat, scientificName, commonName, confirmed)
                                    Output inserted.*
                                    Values(@breedingHabitat, @scientificName, @commonName, @confirmed)";
                var mosquito = connection.QueryFirstOrDefault<Mosquito>(queryString, newMosquito);
                if (mosquito != null)
                {
                    return mosquito;
                }
                throw new Exception("Error, can't add the submission");
            }
        }

        public Mosquito DeleteMosquito(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var queryString = @"DELETE 
                                    FROM [Species]
                                    Output deleted.*
                                    WHERE id = @id";
                var mosquito = connection.QueryFirstOrDefault<Mosquito>(queryString, new { id });
                if (mosquito != null)
                {
                    return mosquito;
                }
                throw new Exception("Unable to delete that mosquito");
            }
        }
    }
}
