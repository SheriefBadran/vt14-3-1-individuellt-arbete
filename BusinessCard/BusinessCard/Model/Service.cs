using BusinessCard.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // VALIDATION METHOD
        private void Validate(object instance)
        {
            ICollection<ValidationResult> validationResults;

            if (!instance.Validate(out validationResults))
            {
                var ex = new ValidationException("The object failed validation!");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
        }

        // PERSON METHODS
        // METHOD USED!!
        public Person GetPerson(int personID)
        {
            return PersonDAL.GetPersonById(personID);
        }

        // METHOD USED!!
        public IEnumerable<Person> GetPersons()
        {
            return PersonDAL.GetPersons();
        }

        // METHOD USED
        public void SavePerson(Person person)
        {
            Validate(person);

            if (person.PersonID == 0) // New post if ContactID is 0
            {
                //PersonDAL.CreatePerson(person);
            }
            else
            {
                // TODO: Call UpdatePerson from Service -> SavePerson()
                PersonDAL.UpdatePerson(person);
            }
        }

        // EMPLOYMENT METHODS
        // USED METHOD!! - MAYBE NOT USED
        public void SaveEmployments(int PersonID, int[] CompanyIDs)
        {
            //EmploymentDAL.CreateEmployments(PersonID, CompanyIDs);
        }

        // USED METHOD!
        public void SavePersonEmployments(Person person, Employment employment)
        {
            Validate(person);
            Validate(employment);

            EmploymentDAL.CreateBusinessCard(person, employment);
        }

        // USED METHOD
        public void DeletePersonEmployment(int PersonID)
        {
            EmploymentDAL.DeletePersonEmployment(PersonID);
        }

        // COMPANY METHODS

        // METHOD USED
        public IEnumerable<Company> GetCompanies()
        {
            return CompanyDAL.GetCompanies();
        }

        // METHOD USED
        public List<Company> GetCompaniesByPersonID(int personID)
        {
            return CompanyDAL.GetCompanyNamesByPersonId(personID);
        }

        //METHOD USED
        public int GetCompanyIDByCompanyName(string companyName)
        {
            return CompanyDAL.GetCompanyIDByCompanyName(companyName);
        }

        // METHOD USED
        public List<Person> GetBusinessCardsByCompanyID(int CompanyID)
        {
            return PersonDAL.GetBusinessCardsByCompanyID(CompanyID);
        }
    }
}