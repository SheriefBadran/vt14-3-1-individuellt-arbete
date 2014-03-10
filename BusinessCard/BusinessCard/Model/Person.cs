using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessCard.Model
{
    public class Person
    {
        #region Auto implemented properties

        // ContactID is not set, ContactID has value 0. 0-value indicates insert new contact.
        public int PersonID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(20, ErrorMessage = "First name can contain maximum 20 letters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20, ErrorMessage = "Last name can contain maximum 20 letters.")]
        public string LastName { get; set; }

        #endregion
    }
}