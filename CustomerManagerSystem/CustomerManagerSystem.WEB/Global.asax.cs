using CustomerManagerSystem.WEB.DAL;
using CustomerManagerSystem.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CustomerManagerSystem.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CSMModelContext context = new CSMModelContext();

            var _cities = context.Cities.ToList();
            var _regions = context.Regions.ToList();
            var _users = context.Users.ToList();
            var _customers = context.Customers.ToList();

            foreach (var item in _cities)
                context.Cities.Remove(item);

            foreach (var item in _regions)
                context.Regions.Remove(item);

            foreach (var item in _users)
                context.Users.Remove(item);

            foreach (var item in _customers)
                context.Customers.Remove(item);

            var users = new List<User>
             {
                new User
                {
                    Email = "admin@sellseverything.com",
                    Name = "User1",
                    Password = "admin123",
                    Role = Enum.Enum.Role.Administrator
                },
                new User
                {
                    Email = "seller1@sellseverything.com",
                    Name = "User2",
                    Password = "seller1123",
                    Role = Enum.Enum.Role.Seller
                },
                new User
                {
                    Email = "seller2@sellseverything.com",
                    Name = "User3",
                    Password = "seller2123",
                    Role = Enum.Enum.Role.Seller
                }
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var regions = new List<Region>
            {
                new Region
                {
                    Name = "Rio Grande do Sul"
                },
                new Region
                {
                    Name = "Santa Catarina"
                }
            };

            regions.ForEach(s => context.Regions.Add(s));
            context.SaveChanges();

            var cities = new List<City>
            {
                new City
                {
                    Name = "Porto Alegre",
                    Region = regions.FirstOrDefault(x => x.Name.Equals("Rio Grande do Sul"))
                },
                new City
                {
                    Name = "São Leopoldo",
                    Region = regions.FirstOrDefault(x => x.Name.Equals("Rio Grande do Sul"))
                },
                new City
                {
                    Name = "Florianopolis",
                    Region = regions.FirstOrDefault(x => x.Name.Equals("Santa Catarina"))
                },
                new City
                {
                    Name = "Criciuma",
                    Region = regions.FirstOrDefault(x => x.Name.Equals("Santa Catarina"))
                }
              };

            cities.ForEach(s => context.Cities.Add(s));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer
                {
                    Name = "Customer1",
                    City = cities.FirstOrDefault(x => x.Name.Equals("Porto Alegre")),
                    Classification = Enum.Enum.Classification.Classification1,
                    Gender = Enum.Enum.Gender.Female,
                    LastPurchase = DateTime.Now.AddMonths(-3),
                    Phone = "99999999",
                    Seller = users.Single(x => x.Name.Equals("User1"))
                },
                new Customer
                {
                    Name = "Customer2",
                    City = cities.FirstOrDefault(x => x.Name.Equals("Florianopolis")),
                    Classification = Enum.Enum.Classification.Classification2,
                    Gender = Enum.Enum.Gender.Male,
                    LastPurchase = DateTime.Now.AddMonths(-2),
                    Phone = "88888888",
                    Seller = users.Single(x => x.Name.Equals("User2"))
                },
                new Customer
                {
                    Name = "Customer3",
                    City = cities.FirstOrDefault(x => x.Name.Equals("Criciuma")),
                    Classification = Enum.Enum.Classification.Classification3,
                    Gender = Enum.Enum.Gender.Female,
                    LastPurchase = DateTime.Now.AddMonths(-1),
                    Phone = "77777777",
                    Seller = users.Single(x => x.Name.Equals("User3"))
                }
                };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

        }
    }
}
