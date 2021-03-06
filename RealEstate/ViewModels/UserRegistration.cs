﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModels
{
    /**Model for Registration*/
    public class UserRegistration
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Login")]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter E-mail"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Password"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

