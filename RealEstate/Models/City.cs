using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }    //район
        public string Region { get; set; }//область

    }
}
