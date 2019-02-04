using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CustomerManagerSystem.WEB.Enum.Enum;

namespace CustomerManagerSystem.WEB.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}