using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CustomerManagerSystem.WEB.Enum.Enum;

namespace CustomerManagerSystem.WEB.Models
{
    public class SearchViewModel
    {
        public string Name { get; set; }

        public List<Gender>  Genders { get; set; }

        public List<City> Cities { get; set; }

        public List<Region> Regions { get; set; }

        public List<User> Sellers { get; set; }

        public List<Classification> Classifications { get; set; }

        public DateTime FromLastPurchase { get; set; }

        public DateTime UntilLastPurchase { get; set; }
    }
}