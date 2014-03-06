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

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void InsertPerson_InsertItem(Person person)
        {
            try
            {
                // TODO: Implement validation and PRG in Create.aspx.cs -> InsertPerson_InsertItem.

                Service.SavePerson(person);


                // ResponseMessage = String.Format("Kontakten {0} {1} har sparats.", contact.FirstName, contact.LastName);
                // Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då en visitkort skulle läggas till.");
            }
            //var item = new Person();
            //TryUpdateModel(item);
            //if (ModelState.IsValid)
            //{
            //    // Save changes here

            //}
        }
    }
}