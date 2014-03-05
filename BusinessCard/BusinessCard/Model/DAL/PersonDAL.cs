using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BusinessCard.Model.DAL
{
    public class PersonDAL: DALBase
    {
        private SqlCommand _cmd;

        // Private constant fields for stored procedures.
        private const string USP_GET_PERSON = "AppSchema.uspGetPerson";
        private const string USP_ADD_PERSON = "AppSchema.uspAddPerson";
        private const string USP_GET_PERSONS = "AppSchema.uspGetPersons";

        private const string USP_UPDATE_PERSON = "AppSchema.uspUpdatePerson";
        private const string USP_REMOVE_PERSON = "AppSchema.uspRemovePerson";


        // Methods
        public void DeletePerson(int personID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var connection = CreateConnection())
            {
                try
                {
                    _cmd = new SqlCommand(USP_REMOVE_PERSON, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter id for stored procedure to delete person
                    _cmd.Parameters.Add("@PersonId", SqlDbType.Int, 4).Value = personID;

                    connection.Open();

                    // The stored procedure with (DELETE) does not return any posts -> ExecuteNonQuery is used to execute the stored procedure.
                    _cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public Person GetPersonById(int personID)
        {
            // Create SqlCommand object to execute stored procedure.
            try
            {
                using (var connection = CreateConnection())
                {
                    _cmd = new SqlCommand(USP_GET_PERSON, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter id for stored procedure to return person
                    _cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personID;

                    connection.Open();

                    using (var reader = _cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            int personIdIndex = reader.GetOrdinal("PersonID");
                            int firstNameIndex = reader.GetOrdinal("FirstName");
                            int lastNameIndex = reader.GetOrdinal("LastName");

                            return new Person
                            {
                                PersonID = reader.GetInt32(personIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex)
                            };
                        }
                    }

                    return null;
                }
            }
            catch
            {
                throw new ApplicationException("An error occured in the data access layer");
            }
        }

        public void InsertPerson(Person person)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    _cmd = new SqlCommand(USP_ADD_PERSON, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameters to feed the stored procedure. 
                    _cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = person.FirstName;
                    _cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = person.LastName;

                    // Parameter to get the primary key value. Value is set after the stored procedure is executed.
                    _cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Open database connection
                    connection.Open();

                    // The stored procedure with (INSERT) does not return any posts -> ExecuteNonQuery is used to execute the stored procedure.
                    _cmd.ExecuteNonQuery();

                    // Get primary key value for the new table post and assign the Person object the value.
                    person.PersonID = (int)_cmd.Parameters["@PersonID"].Value;

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public void UpdatePerson(Person person)
        {
            // Create SqlCommand object to execute stored procedure.
            using (var connection = CreateConnection())
            {
                try
                {
                    var _cmd = new SqlCommand(USP_UPDATE_PERSON, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Add the parameters to feed the stored procedure. 
                    _cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = person.FirstName;
                    _cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = person.LastName;

                    _cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = person.PersonID;

                    connection.Open();

                    _cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}