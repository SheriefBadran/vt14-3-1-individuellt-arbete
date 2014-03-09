﻿using System;
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

        private const string USP_ADD_EMPLOYMENT = "AppSchema.AddEmployment";
        private const string USP_ADD_PERSON_BUSINESSCARD = "AppSchema.uspAddPersonBusinessCard";

        #region CreateDate
        public void CreateDate(Employment employment)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    _cmd = new SqlCommand(USP_ADD_EMPLOYMENT, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameters to feed the stored procedure. 
                    _cmd.Parameters.Add("@CompanyID", SqlDbType.Int, 4).Value = employment.CompanyID;
                    _cmd.Parameters.Add("@EmploymentID", SqlDbType.Int, 4).Value = employment.EmploymentID;
                    _cmd.Parameters.Add("@ConvenDate", SqlDbType.DateTime).Value = employment.ConvenDate;
                    _cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = employment.PersonID;

                    // Parameter to get the primary key value. Value is set after the stored procedure is executed.
                    _cmd.Parameters.Add("@EmploymentID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Open database connection
                    connection.Open();

                    // The stored procedure with (INSERT) does not return any posts -> ExecuteNonQuery is used to execute the stored procedure.
                    _cmd.ExecuteNonQuery();

                    // Get primary key value for the new table post and assign the Contact object the value.
                    employment.PersonID = (int)_cmd.Parameters["@PersonID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        #endregion

        #region CreateEmployment
        public void CreateEmployment(int PersonID, int CompanyID)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    _cmd = new SqlCommand(USP_ADD_EMPLOYMENT, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameters to feed the stored procedure. 
                    _cmd.Parameters.Add("@CompanyID", SqlDbType.Int, 4).Value = CompanyID;
                    //_cmd.Parameters.Add("@EmploymentID", SqlDbType.Int, 4).Value = 0;
                    _cmd.Parameters.Add("@ConvenDate", SqlDbType.DateTime).Value = DateTime.Today;
                    _cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = PersonID;

                    // Parameter to get the primary key value. Value is set after the stored procedure is executed.
                    //_cmd.Parameters.Add("@EmploymentID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Open database connection
                    connection.Open();

                    // The stored procedure with (INSERT) does not return any posts -> ExecuteNonQuery is used to execute the stored procedure.
                    _cmd.ExecuteNonQuery();

                    // Get primary key value for the new table post and assign the Contact object the value.
                    //employment.PersonID = (int)_cmd.Parameters["@PersonID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        #endregion

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

                    // Parameter to get the primary key value. Value is set after the stored procedure is executed.
                    //_cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Open database connection
                    connection.Open();

                    // The stored procedure with (INSERT) does not return any posts -> ExecuteNonQuery is used to execute the stored procedure.
                    _cmd.ExecuteNonQuery();

                    // Get primary key value for the new table post and assign the Contact object the value.
                    //person.PersonID = (int)_cmd.Parameters["@PersonID"].Value;


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