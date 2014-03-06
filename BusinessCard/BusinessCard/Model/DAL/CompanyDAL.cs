using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;

namespace BusinessCard.Model.DAL
{
    public class CompanyDAL : DALBase
    {
        private SqlCommand _cmd;

        [WebMethod]
        public List<string> GetCompanyNames(string companyName)
        {
            List<string> companyNames = new List<string>();
            using (var connection = CreateConnection())
            {
                _cmd = new SqlCommand("uspGetMatchingCompanyNames", connection);
                _cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CompanyName", companyName);
                _cmd.Parameters.Add(param);

                connection.Open();
                SqlDataReader reader = _cmd.ExecuteReader();
                while(reader.Read())
                {
                    
                }
            }
            
            throw new NotImplementedException();
        }
    }
}