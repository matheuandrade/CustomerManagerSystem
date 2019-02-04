using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagerSystem.WEB.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //public int RegionID { get; set; }
        public virtual Region Region { get; set; }
    }
}