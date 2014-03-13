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
        private const string USP_GET_COMPANIES = "AppSchema.uspGetCompanies";
        private const string USP_GET_COMPANY_NAMES_BY_PERSONID = "AppSchema.GetCompanyNamesByPersonID";
        private const string USP_GET_COMPANY_ID_BY_COMPANY_NAME = "AppSchema.uspGetCompanyIDByCompanyName";

        // METHOD USED
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

        // METHOD USED
        #region GetCompanyNamesByPersonId(int personID)
        public List<Company> GetCompanyNamesByPersonId(int personID)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var companies = new List<Company>(3);

                    _cmd = new SqlCommand(USP_GET_COMPANY_NAMES_BY_PERSONID, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter id for stored procedure to return person
                    _cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personID;

                    connection.Open();

                    using (var reader = _cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int companyIdIndex = reader.GetOrdinal("CompanyID");
                            int companyNameIndex = reader.GetOrdinal("CompanyName");

                            companies.Add(new Company
                            {
                                // Sproc doesn't return PersonID
                                CompanyID = reader.GetInt32(companyIdIndex),
                                CompanyName = reader.GetString(companyNameIndex),
                            });
                        }
                    }
                    return companies;
                }
            }
            catch
            {
                throw new ApplicationException("An error occured in the data access layer");
            }
        }
        #endregion

        #region GetCompanyIDByCompanyName()
        public int GetCompanyIDByCompanyName(string companyName)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    
                    _cmd = new SqlCommand(USP_GET_COMPANY_ID_BY_COMPANY_NAME, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter CompanyName for stored procedure to return CompanyID
                    _cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar, 20).Value = companyName;

                    connection.Open();

                    using (var reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int companyIDIndex = reader.GetOrdinal("CompanyID");
                            return reader.GetInt32(companyIDIndex);
                        }
                    }

                    // If given CompanyName doesn't match with existing company names in DB, return CompanyID = 0;
                    return 0;
                }
            }
            catch
            {
                throw new ApplicationException("An error occured in the data access layer");
            }
        }
        #endregion
    }
}