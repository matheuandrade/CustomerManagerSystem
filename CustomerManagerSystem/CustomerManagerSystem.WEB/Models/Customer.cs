using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CustomerManagerSystem.WEB.Enum.Enum;

namespace CustomerManagerSystem.WEB.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public DateTime LastPurchase { get; set; }
        public virtual User User { get; set; }
        public string Phone { get; set; }
        public Classification Classification { get; set; }
    }
}