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

        List<Person> BusinessCards = new List<Person>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void FindButton_Click(object sender, EventArgs e)
        {
            var companyName =  CompanyNameTextBox.Text;
            var companyID = Service.GetCompanyIDByCompanyName(companyName);

            if (companyID != 0)
            {
                BusinessCards = Service.GetBusinessCardsByCompanyID(companyID);
                // Print out on listview!
            }

            else
            {
                ModelState.AddModelError(String.Empty, "Company does not exist!");
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public List<Person> BusinessCardList_GetData()
        {
            return BusinessCards;
        }
    }
}