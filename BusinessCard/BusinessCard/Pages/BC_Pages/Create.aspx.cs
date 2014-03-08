using BusinessCard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessCard.Pages.BC_Pages
{
    public partial class Create : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public DropDownList DropDown{ get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //var CompanyID = int.Parse(DropDown.SelectedValue);
        }

        public void BusinessC_InsertItem(Person person)
        {
            try
            {
                // Retrive the CompanyID selected from the dropdown list.
                var CompanyID = int.Parse(DropDown.SelectedValue);

                // Save persons name data into the Person DB-table
                Service.SavePerson(person);

                // Save the Persons Employment data into the Employment DB-relational-table.
                Service.SaveEmployment(person.PersonID, CompanyID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Company> CompanyDropDown_GetData()
        {
            return Service.GetCompanies();
        }

        // retrieve the dropdown object and initialize it to the DropDown property in this class
        protected void DropDownList1_DataBinding(object sender, EventArgs e)
        {
            var dropDown = sender as DropDownList;

            if (dropDown != null)
            {
                DropDown = dropDown;
            }
            else
            {
                // TODO: Implement correct exception handling on Create.aspx.cs -> DropDownList DataBinding
                throw new NotImplementedException();
            }
        }
    }
}