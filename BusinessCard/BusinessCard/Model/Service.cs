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
        private CompanyDAL _company;

        // Properties
        private PersonDAL PersonDAL
        {
            get { return _personDal ?? (_personDal = new PersonDAL()); }
        }

        private EmploymentDAL EmploymentDAL
        {
            get { return _employmentDal ?? (_employmentDal = new EmploymentDAL()); }
        }

        private CompanyDAL CompanyDAL
        {
            get { return _company ?? (_company = new CompanyDAL()); }
        }


        // PERSON METHODS
        public Person GetPerson(int personID)
        {
            return PersonDAL.GetPersonById(personID);
        }

        public Person GetPersonByName(string firstName)
        {
            return PersonDAL.GetPersonByName(firstName);
        }

        public IEnumerable<Person> GetPersons()
        {
            return PersonDAL.GetPersons();
        }

        public void SavePerson(Person person)
        {
            // TODO: Implement validation in Service SavePerson.
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
                // TODO: Call UpdatePerson from Service -> SavePerson()
                // PersonDAL.UpdatePerson(person);
                throw new NotImplementedException();
            }
        }

        // EMPLOYMENT METHODS
        public Employment GetGetCompanyIdByPersonId(int personID)
        {
            return PersonDAL.GetCompanyIdByPersonId(personID);
        }

        public void SaveDate(Employment employment)
        {
            if (employment.EmploymentID == 0)
            {
                EmploymentDAL.CreateDate(employment);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        // COMPANY METHODS
        public void SaveCompany(Company company)
        {
            // TODO: Implement validation in Service SaveCompany()
            if (company.CompanyID == 0)
            {
                CompanyDAL.CreateCompany(company);
            }
            else
            {
                // TODO: Call UpdatePerson from Service -> SaveCompany()
                throw new NotImplementedException();
            }
        }
    }
}