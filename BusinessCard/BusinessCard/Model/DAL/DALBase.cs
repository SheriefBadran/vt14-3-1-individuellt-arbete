using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BusinessCard.Model.DAL
{
    public abstract class DALBase
    {
        // Private field
        private static string _connectionString;

        // Methods
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["BusinessCardConnectionString"].ConnectionString;
        }
    }
}