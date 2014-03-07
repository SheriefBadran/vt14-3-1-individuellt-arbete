using BusinessCard.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessCard.Model
{
    public class Company
    {
        #region Auto implemented properties

        // ContactID is not set, ContactID has value 0. 0-value indicates insert new contact.

        public int CompanyID { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(40)]
        public string CompanyName { get; set; }

        #endregion
    }
}