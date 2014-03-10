using BusinessCard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessCard.App_Infrastructure;

namespace BusinessCard.Pages.BC_Pages
{
    public partial class PersonList : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public TextBox CompanyUpdateTextBox { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Success message handling
            LiteralSuccess.Text = Page.GetTempData("SuccessMessage") as string;

            // Set visible to true if LiteralSuccess.Text contains a string.
            ResponsePanel.Visible = !String.IsNullOrWhiteSpace(LiteralSuccess.Text);
        }

        public IEnumerable<Person> BusinessCardFormView_GetData()
        {
            return Service.GetPersons();
        }

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
                var company = Service.GetCompanyByPersonId(PersonID);
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

        // Retrieve CompanyName for each person and add to the view list.
        protected void CompanyNameTextBox_DataBinding(object sender, EventArgs e)
        {
            var CompanyUpdateTextBox = sender as TextBox;
            if (CompanyUpdateTextBox != null)
            {
                // Retrieve the binded PersonID from the CompanyNameLiteral
                var PersonID = int.Parse(CompanyUpdateTextBox.Text);

                // Retrieve a company object reference containing CompanyID and CompanyName
                var company = Service.GetCompanyByPersonId(PersonID);
                if (company != null)
                {

                    CompanyUpdateTextBox.Text = company.CompanyName;
                }
                else
                {
                    CompanyUpdateTextBox.Text = "***No registered employment***";
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BusinessCardFormView_UpdateItem(int PersonID)
        {
            try
            {
                // 1. PersonID retrieved from form after DataKeyNames is set to PersonID in the ListView control.

                // 2. Retrieve person from DB to make sure that there is a person to update on given PersonID.
                // And the same is done for company.
                var person = Service.GetPerson(PersonID);
                var company = Service.GetCompanyByPersonId(PersonID);

                // 3. Check if we got the requested Contact object.
                if (person == null)
                {
                    ModelState.AddModelError(String.Empty, "The name related to the business card was not found!");
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

                    // Set Successmessage in temporary session. Done with static class method App_Infrastructure->PageExtensions.cs
                    // Also redirect to (this page) PersonList.aspx. (PRG pattern)
                    Page.SetTempData("SuccessMessage", "Name was successfully updated.");
                    Response.RedirectToRoute("BusinessCardList");
                    Context.ApplicationInstance.CompleteRequest();
                }

                if (TryUpdateModel(company))
                {
                    CompanyUpdateTextBox.Text = company.CompanyName;
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då visitkortet skulle uppdateras.");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BusinessCardFormView_DeleteItem(int PersonID)
        {
            try
            {
                Service.DeletePersonEmployment(PersonID);

                // Set Successmessage in temporary session. Done with static class method App_Infrastructure->PageExtensions.cs
                // Also redirect to (this page) PersonList.aspx. (PRG pattern)
                Page.SetTempData("SuccessMessage", "The business card was successfully deleted.");
                Response.RedirectToRoute("BusinessCardList");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle tas bort.");
            }
        }
    }
}