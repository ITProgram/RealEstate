using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

