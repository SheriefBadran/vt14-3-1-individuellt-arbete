using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BusinessCard.Model.DAL
{
    public class EmploymentDAL : DALBase
    {
        private SqlCommand _cmd;

        private const string USP_ADD_PERSON_BUSINESSCARD = "AppSchema.uspAddPersonBusinessCard";
        private const string USP_DELETE_PERSON_EMPLOYMENT = "AppSchema.uspDeletePersonEmployment";

        // USED METHOD!!
        #region CreateEmployments()
        public void CreateEmployments(int PersonID, int[] CompanyIDs)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    _cmd = new SqlCommand(USP_ADD_PERSON_BUSINESSCARD, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameters to feed the stored procedure.
                    _cmd.Parameters.Add("@PersonID_FK", SqlDbType.Int, 4).Value = PersonID;
                    _cmd.Parameters.Add("@ConvenDate", SqlDbType.DateTime).Value = DateTime.Today;

                    for (int i = 0; i < CompanyIDs.Length; i++)
                    {
                        _cmd.Parameters.Add(String.Format("CompanyID{0}", i), SqlDbType.Int, 4).Value = CompanyIDs[i];
                    }

                    // Open database connection
                    connection.Open();

                    // The stored procedure with (INSERT) does not return any posts -> ExecuteNonQuery is used to execute the stored procedure.
                    _cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        #endregion

        // METHOD USED!!
        #region DeletePersonEmployment(int PersonID)
        public void DeletePersonEmployment(int PersonID)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    _cmd = new SqlCommand(USP_DELETE_PERSON_EMPLOYMENT, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameters to feed the stored procedure.
                    _cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = PersonID;

                    // Open database connection
                    connection.Open();

                    // The stored procedure with (DELETE) does not return any posts -> ExecuteNonQuery is used to execute the stored procedure.
                    _cmd.ExecuteNonQuery();
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