using App.Domain;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    public class SecurityController : Controller
    {
        
        public ActionResult Login()
        {
            if(TempData["loginError"]!=null)
            {
                var loginError = Convert.ToBoolean(TempData["loginError"]);
                if (loginError)
                {
                    ViewBag.LoginFailed = "Error de autenticación";
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string clave, string ReturnUrl)
        {
            //Validando en base de datos
            IUsuarioDomain usuarioDomain = new UsuarioDomain();
            var usuarioChecked = usuarioDomain.ValidateLogin(usuario, clave);
            if(usuarioChecked!=null)
            {
                //Definiendo los claims: son porciones
                //de datos que nos permitir guardar información del
                //usuario en la cookie
                var claims = new List<Claim>();
                claims.Add(
                    new Claim("UsuarioID", usuarioChecked.UsuarioID.ToString())
                    );

                claims.Add(
                    new Claim("NombreCompleto", 
                            $"{usuarioChecked.Nombres} {usuarioChecked.Apellidos}")
                    );

                //Agregando roles
                string[] roles = usuarioChecked.Roles.Split(';');
                foreach(string rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role,rol));
                }


                //Haciendo uso de Owin components
                var owinContext = Request.GetOwinContext();
                var authManager = owinContext.Authentication;

                var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                authManager.SignIn(identity); //Creando la cookie de autenticacion

                return Redirect(ReturnUrl ?? "~/");

            }
            else
            {
                TempData["loginError"] = true;
                return RedirectToAction("Login");
                // return RedirectToAction("Login",new {error=true });
            }
        }

        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}