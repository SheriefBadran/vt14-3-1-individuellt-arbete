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
        private const string USP_ADD_COMPANY = "AppSchema.uspAddCompany";

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

        #region CreatePerson()
        public void CreateCompany(Company company)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    _cmd = new SqlCommand(USP_ADD_COMPANY, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameters to feed the stored procedure. 
                    _cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar, 20).Value = company.CompanyName;

                    // Parameter to get the primary key value. Value is set after the stored procedure is executed.
                    _cmd.Parameters.Add("@CompanyID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Open database connection
                    connection.Open();

                    // The stored procedure with (INSERT) does not return any posts -> ExecuteNonQuery is used to execute the stored procedure.
                    _cmd.ExecuteNonQuery();

                    // Get primary key value for the new table post and assign the Contact object the value.
                    company.CompanyID = (int)_cmd.Parameters["@CompanyID"].Value;

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        #endregion
    }
}