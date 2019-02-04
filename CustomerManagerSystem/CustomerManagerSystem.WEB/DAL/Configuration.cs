using CustomerManagerSystem.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CustomerManagerSystem.WEB.DAL
{
    internal sealed class Configuration : DbMigrationsConfiguration<CSMModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CSMModelContext context)
        {
            var users = new List<User>
            {
                new User { Email = "admin@sellseverything.com",   Password = "admin123",
                    Role = Enum.Enum.Role.Administrator },
                new User { Email = "seller1@sellseverything.com",   Password = "seller1123",
                    Role = Enum.Enum.Role.Seller },
                new User { Email = "seller2@sellseverything.com",   Password = "seller2123",
                    Role = Enum.Enum.Role.Seller }
            };

            foreach(var usr in users)
            {
                if(!context.Users.Any(x => x.Email.ToUpper().Equals(usr.Email.ToUpper())))
                {
                    context.Users.Add(usr);
                    context.SaveChanges();
                }
            }

            
        }
    }
}