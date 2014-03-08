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
        private const string USP_GET_COMPANIES = "AppSchema.uspGetCompanies";
        private const string USP_GET_COMPANY_NAME_BY_PERSONID = "AppSchema.GetCompanyNameByPersonID";

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

        #region GetCompanies()
        public IEnumerable<Company> GetCompanies()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    // Create a list object for 100 Person references.
                    var companies = new List<Company>(100);

                    // Create SqlCommand object to execute stored procedure.
                    _cmd = new SqlCommand(USP_GET_COMPANIES, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Open database connection
                    connection.Open();

                    // The stored procedure returns a set of persons.
                    // The Sql reader object holds the set of persons and the method ExecuteReader creates an SqlDataReader-object and
                    // returns a reference to the object.
                    using (var reader = _cmd.ExecuteReader())
                    {
                        // Retrieve the index corresponding all the collumns.
                        var companyIdIndex = reader.GetOrdinal("CompanyID");
                        var companyNameIndex = reader.GetOrdinal("CompanyName");

                        // reader.Read returns a boolean.
                        while (reader.Read())
                        {
                            // Eeach iteration retrieves data for one db table row.
                            companies.Add(new Company
                            {
                                CompanyID = reader.GetInt32(companyIdIndex),
                                CompanyName = reader.GetString(companyNameIndex),
                            });
                        }
                    }

                    // Set List capasity to actual number of elements
                    companies.TrimExcess();

                    // Return the the List containing Person objects.
                    return companies;
                }
                catch
                {
                    throw new ApplicationException("Error! Unable to get persons from the database.");
                }
            }
        }
        #endregion

        #region GetCompanyNameByPersonId(int personID)
        public Company GetCompanyNameByPersonId(int personID)
        {
            //try
            //{
                using (var connection = CreateConnection())
                {
                    _cmd = new SqlCommand(USP_GET_COMPANY_NAME_BY_PERSONID, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter id for stored procedure to return person
                    _cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personID;

                    connection.Open();

                    using (var reader = _cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            int companyIdIndex = reader.GetOrdinal("CompanyID");
                            int companyNameIndex = reader.GetOrdinal("CompanyName");

                            return new Company
                            {
                                // Sproc doesn't return PersonID
                                CompanyID = reader.GetInt32(companyIdIndex),
                                CompanyName= reader.GetString(companyNameIndex),
                            };
                        }
                    }
                    return null;
                }
            //}
            //catch
            //{
            //    throw new ApplicationException("An error occured in the data access layer");
            //}
        }
        #endregion
    }
}