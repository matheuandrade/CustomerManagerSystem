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

        public ActionResult CustomersList(User model)
        {
            if (ModelState.IsValid)
            {
                List<Customer> customerList;
                if (model.Role.Equals(Enum.Enum.Role.Seller))
                    customerList = db.Customers.Where(x => x.User.Email.ToUpper().Equals(model.Email.ToUpper())).ToList();
                else
                    customerList = db.Customers.ToList();

                return View(customerList);
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
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
                        return RedirectToAction("CustomersList", user);
                    }
                }
                else
                {
                    return RedirectToAction("CustomersList", Security);
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