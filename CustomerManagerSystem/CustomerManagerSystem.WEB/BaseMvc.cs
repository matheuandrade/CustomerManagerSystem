using CustomerManagerSystem.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagerSystem.WEB
{
    public class BaseMvc : Controller
    {
        private User _user;

        public User Security
        {
            get
            {
                if (Session["UserData"] != null)
                {
                    _user = (User)Session["UserData"];
                }

                return _user;
            }
            set
            {
                if (Session["UserData"] != null)
                {
                    Session.Remove("UserData");
                }
                Session.Add("UserData", value);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Security == null)
                filterContext.Result = new RedirectResult(Url.Action("Login","Home"));
        }
    }
}