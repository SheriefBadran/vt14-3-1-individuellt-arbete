using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace BusinessCard.Model.DAL
{
    public class PersonDAL : DALBase
    {
        private SqlCommand _cmd;

        // Private constant fields for stored procedures.
        private const string USP_GET_PERSON = "AppSchema.uspGetPerson";
        private const string USP_GET_PERSONS = "AppSchema.uspGetPersons";
        private const string USP_UPDATE_PERSON = "AppSchema.uspUpdatePerson";
        private const string USP_ADD_PERSON = "AppSchema.uspAddPerson";

        // Person Methods

        // METHOD USED!!
        #region CreatePerson()
        public void CreatePerson(Person person)
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

                    // Get primary key value for the new table post and assign the Contact object the value.
                    person.PersonID = (int)_cmd.Parameters["@PersonID"].Value;


                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        #endregion

        // METHOD USED
        #region GetPersons()
        public IEnumerable<Person> GetPersons()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    // Create a list object for 100 Person references.
                    var persons = new List<Person>(100);

                    // Create SqlCommand object to execute stored procedure.
                    _cmd = new SqlCommand(USP_GET_PERSONS, connection);
                    _cmd.CommandType = CommandType.StoredProcedure;

                    // Open database connection
                    connection.Open();

                    // The stored procedure returns a set of persons.
                    // The Sql reader object holds the set of persons and the method ExecuteReader creates an SqlDataReader-object and
                    // returns a reference to the object.
                    using (var reader = _cmd.ExecuteReader())
                    {
                        // Retrieve the index corresponding all the collumns.
                        var personIdIndex = reader.GetOrdinal("PersonID");
                        var firstNameIndex = reader.GetOrdinal("FirstName");
                        var lastNameIndex = reader.GetOrdinal("LastName");

                        // reader.Read returns a boolean.
                        while (reader.Read())
                        {
                            // Eeach iteration retrieves data for one db table row.
                            persons.Add(new Person
                            {
                                PersonID = reader.GetInt32(personIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex)
                            });
                        }
                    }

                    // Set List capasity to actual number of elements
                    persons.TrimExcess();

                    // Return the the List containing Person objects.
                    return persons;
                }
                catch
                {
                    throw new ApplicationException("Error! Unable to get persons from the database.");
                }
            }            
        }
        #endregion

        // METHOD USED!!
        #region GetPersonById(int personID)
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
        #endregion

        // METHOD USED!!
        #region UpdatePerson(Person person)
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
        #endregion
    }
}