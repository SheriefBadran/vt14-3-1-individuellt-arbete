using BusinessCard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessCard.Pages.BC_Pages
{
    public partial class PersonList : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Person> BusinessCardFormView_GetData()
        {
            return Service.GetPersons();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Company> CompanyNameListView_GetData()
        {
            return Service.GetCompanies();
        }

        protected void CompanyNameLiteral_DataBinding(object sender, EventArgs e)
        {
            var literal = sender as Literal;
            if (literal != null)
            {
                // Retrieve the binded PersonID from the CompanyNameLiteral
                var PersonID = int.Parse(literal.Text);

                // Retrieve a company object reference containing CompanyID and CompanyName
                var company = Service.GetCompanyIdByPersonId(PersonID);
                if (company != null)
                {
                    
                    literal.Text = company.CompanyName;
                }
                else
                {
                    literal.Text = "***No registered employment***";
                }
                //literal.Text = text + "edit";
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BusinessCardFormView_UpdateItem(int PersonID)
        {
            try
            {
                // 1. ContactID retrieved from form after DataKeyNames is set to ContactID in the ListView control.

                // 2. Retrieve contact from DB to make sure that there is a contact to update on given ContactID.
                var person = Service.GetPerson(PersonID);

                // 3. Check if we got the requested Contact object.
                if (person == null)
                {
                    ModelState.AddModelError(String.Empty, "Kontakten kunde inte hittas.");
                    return;
                }

                // 4. A Contact reference object is created in GetContactById() in ContactDAL class. The Contact object is populated
                // with updated data.

                // 5. TryUpdateModel retrieves data from the form and and inserts data to the object reference.
                // TryUpdateModel also uses framework to validate with ModelState.IsValid().
                // If that is done with success, go on save the contact else Print error message with ModelState error!
                if (TryUpdateModel(person))
                {
                    // 6. When Service.Save(contact), the data is sent to database.
                    Service.SavePerson(person);
                    //Response.Redirect("~/Default.aspx", false);
                    //Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            }
        }
    }
}