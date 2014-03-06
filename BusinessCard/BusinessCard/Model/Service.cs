using BusinessCard.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessCard.Model
{
    public class Service
    {
        // Private field
        private PersonDAL _personDal;

        // Properties
        private PersonDAL PersonDAL
        {
            get { return _personDal ?? (_personDal = new PersonDAL()); }
        }

        public Person GetPerson(int personID)
        {
            return PersonDAL.GetPersonById(personID);
        }

        public Person GetPersonByName(string firstName)
        {
            return PersonDAL.GetPersonByName(firstName);
        }

        public Employment GetGetCompanyIdByPersonId(int personID)
        {
            return PersonDAL.GetCompanyIdByPersonId(personID);
        }

        public IEnumerable<Person> GetPersons()
        {
            return PersonDAL.GetPersons();
        }
    }
}