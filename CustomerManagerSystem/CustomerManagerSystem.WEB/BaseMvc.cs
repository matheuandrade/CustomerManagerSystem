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
        private UserModel _user;

        public UserModel Security
        {
            get
            {
                if (Session["UserData"] != null)
                {
                    _user = (UserModel)Session["UserData"];
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
            {
                //UsuarioModel user = new UsuarioModel();
                //var autenticacaoSso = new AutenticacaoSSO();

                //if (autenticacaoSso.VerificarAutenticacao())
                //{
                //    //return Redirect(autenticacaoSso.GetUrlRedirect());
                //    string codigo = AutenticacaoSSO.UsuarioCookieAtual();

                //    user.Login = codigo; //AutenticacaoSSO.UsuarioCookieAtual();
                //    Session.Add("UserData", user);
                //}
                //else
                //{
                //    filterContext.Result = new RedirectResult(autenticacaoSso.GetUrlRedirect());
                //}
            }
        }
    }
}