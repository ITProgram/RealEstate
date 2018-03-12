using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModels
{
    public class UserPublicInfo
    {   [Required]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Login")]
        public string Login { get; set; }
        
    }
}

