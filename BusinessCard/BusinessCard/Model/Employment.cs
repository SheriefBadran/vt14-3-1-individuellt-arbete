﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessCard.Model
{
    public class Employment
    {
        #region Auto implemented properties
        //TODO: Implement validation for Employment table class

        public int CompanyID { get; set; }

        public int EmploymentID { get; set; }

        public DateTime ConvenDate { get; set; }

        public int PersonID { get; set; }

        #endregion
    }
}