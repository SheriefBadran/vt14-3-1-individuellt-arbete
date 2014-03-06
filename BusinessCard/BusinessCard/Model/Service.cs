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
        private EmploymentDAL _employmentDal;

        // Properties
        private PersonDAL PersonDAL
        {
            get { return _personDal ?? (_personDal = new PersonDAL()); }
        }

        private EmploymentDAL EmploymentDAL
        {
            get { return _employmentDal ?? (_employmentDal = new EmploymentDAL()); }
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

        public void SavePerson(Person person)
        {
            // TODO: Implement validation in Service Save method.
            //ICollection<ValidationResult> validationResults;

            //if (!person.Validate(out validationResults))
            //{
            //    var ex = new ValidationException("Objektet klarade inte valideringen.");
            //    ex.Data.Add("ValidationResults", validationResults);
            //    throw ex;
            //}

            if (person.PersonID == 0) // New post if ContactID is 0
            {
                PersonDAL.CreatePerson(person);
            }
            else
            {
               // TODO: Call UpdatePerson from Service -> Save()
               // PersonDAL.UpdatePerson(person);
                throw new NotImplementedException();
            }
        }
    }
}