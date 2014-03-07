using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessCard.Model
{
    public class BusinessCard
    {
        #region Auto implemented properties for Person

        // ContactID is not set, ContactID has value 0. 0-value indicates insert new contact.

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20)]
        public string LastName { get; set; }

        #endregion

        #region Auto implemented properties
        //TODO: Implement validation for Employment table class

        public int EmploymentID { get; set; }

        public DateTime ConvenDate { get; set; }

        #endregion

        #region Auto implemented properties for Company

        // ContactID is not set, ContactID has value 0. 0-value indicates insert new contact.

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(40)]
        public string CompanyName { get; set; }

        #endregion


    }
}