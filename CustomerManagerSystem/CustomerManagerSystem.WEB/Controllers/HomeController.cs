using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagerSystem.WEB.Controllers
{
    public class HomeController : BaseMvc
    {
        public ActionResult CustomersList()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

    }
}