using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessCard.Model
{
    public class Employment
    {
        #region Auto implemented properties
        //TODO: Implement validation for Employment table class

        public int[] CompanyIDs { get; set; }

        public int EmploymentID { get; set; }

        public DateTime ConvenDate { get; set; }

        public int PersonID { get; set; }

        // Maybe a temporary solution to handle ConvenDate.
        // TODO: Implement functionality for ConvenDate insert if there is time overleft.
        public Employment()
        {
            ConvenDate = DateTime.Today;
        }

        #endregion
    }
}