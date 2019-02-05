using CustomerManagerSystem.WEB.DAL;
using CustomerManagerSystem.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagerSystem.WEB.Controllers
{
    public class HomeController : BaseMvc
    {
        private readonly CSMModelContext db = new CSMModelContext();

        public ActionResult CustomersList()
        {
            if (Security != null)
            {
                List<Customer> customerList;
                if (Security.Role.Equals(Enum.Enum.Role.Seller))
                    customerList = db.Customers.Where(x => x.Seller.Email.ToUpper().Equals(Security.Email.ToUpper())).ToList();
                else
                    customerList = db.Customers.ToList();

                return View(customerList);
            }
            else
                return RedirectToAction("Login");
        }

        public ActionResult CustomersList(Customer model)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                if (Security == null)
                {
                    var user = db.Users.FirstOrDefault(x =>
                            x.Email.ToUpper().Equals(model.Email.ToUpper())
                            && x.Password.Equals(model.Password));                    

                    if (user != null)
                    {
                        Session.Add("UserData", user);
                        return RedirectToAction("CustomersList");
                    }
                }
                else
                {
                    return RedirectToAction("CustomersList");
                }

                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            Security = null;
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(model);
                db.SaveChanges();
            }

            return View(model);
        }

    }
}