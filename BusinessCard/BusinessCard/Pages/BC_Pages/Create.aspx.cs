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
    public partial class Create : System.Web.UI.Page
    {
        // Private field.
        private Service _service;

        // Private property.
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        // Public properties for holding data from data-binding methods.
        public DropDownList DropDown{ get; set; }

        public CheckBoxList CheckBoxes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Empty
        }


        // Insert data to Person and Employment DB-tables.
        public void BusinessC_InsertItem(Person person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the id's from the companies selected in the company checkboxlist.
                    int[] CompanyIDs = new int[3];
                    CompanyIDs = CheckBoxes.Items.Cast<ListItem>()
                        .Where(li => li.Selected)
                        .Select(li => int.Parse(li.Value))
                        .ToArray();

                    Employment employment = new Employment();
                    employment.CompanyIDs = CompanyIDs;

                    // Check that no more than three companies is chosen for each business card.
                    if (CompanyIDs.Length <= 3)
                    {
                        Service.SavePersonEmployments(person, employment);

                        // Save persons name data into the Person DB-table
                        //Service.SavePerson(PersonID, CompanyIDs);

                        // Only save employment if employment exists!
                        //if (CompanyIDs.Length > 0)
                        //{
                        //    // Save minimum one employment and maximum three employments.
                        //    Service.SaveEmployments(person.PersonID, CompanyIDs); 
                        //}

                        // Set Successmessage in temporary session. Done with static class method App_Infrastructure->PageExtensions.cs
                        // Also redirect to PersonList.aspx (PRG pattern).
                        Page.SetTempData("SuccessMessage", String.Format("Saving {0} {1} succeeded!", person.FirstName, person.LastName));
                        Response.RedirectToRoute("BusinessCardList");
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "Error! Maximum three companies can be selected on one business card.");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Unexpected error! Upload business card failed!");
                } 
            }
        }

        public IEnumerable<Company> CompanyDropDown_GetData()
        {
            return Service.GetCompanies();
        }

        public IEnumerable<Company> CompanyCheckBox_GetData()
        {
            return Service.GetCompanies();
        }

        protected void CompanyCheckBoxList_DataBinding(object sender, EventArgs e)
        {
            var checkBoxes = sender as CheckBoxList;
            if (checkBoxes != null)
            {
                CheckBoxes = checkBoxes;
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Unexpected error! Company selection failed!");
            }
        }
    }
}