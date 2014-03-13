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
            var companyName =  CompanyNameTextBox.Text;
            var companyID = Service.GetCompanyIDByCompanyName(companyName);

            if (companyID != 0)
            {
                var businessCards = Service.GetBusinessCardsByCompanyID(companyID);

                // Print out on listview!
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Company does not exist!");
            }

        }
    }
}