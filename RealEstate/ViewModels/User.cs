using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModels
{
    public class User//User without Password
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
    }
}

