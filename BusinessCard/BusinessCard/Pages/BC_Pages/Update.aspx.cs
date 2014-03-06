using BusinessCard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessCard.Pages.BC_Pages
{
    public partial class Update : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FindButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var person = Service.GetPersonByName(FirstNameTextBox.Text);
                var companyID = Service.GetGetCompanyIdByPersonId(person.PersonID);
            }         
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public Person BusinessCardFormView_GetItem(int PersonID)
        //{
        //    var person = Service.GetPerson(PersonID);

        //    return person;
        //}

        //// The id parameter name should match the DataKeyNames value set on the control
        //public void BusinessCardFormView_UpdateItem(int id)
        //{
        //    BusinessCard.Model.Person item = null;
        //    // Load the item here, e.g. item = MyDataLayer.Find(id);
        //    if (item == null)
        //    {
        //        // The item wasn't found
        //        ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
        //        return;
        //    }
        //    TryUpdateModel(item);
        //    if (ModelState.IsValid)
        //    {
        //        // Save changes here, e.g. MyDataLayer.SaveChanges();

        //    }
        //}

        //// The id parameter name should match the DataKeyNames value set on the control
        //public void BusinessCardFormView_DeleteItem(int id)
        //{

        //}
    }
}