using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required, ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        public ContactType Type { get; set; }
        [Required]
        public string Value { get; set; }

    }
    public enum ContactType
    {
        Email, Phone, Skype, Viber, VK, OK, Facebook, Twitter, Google, Yahoo, WhatApps, Telegram
    }
}
