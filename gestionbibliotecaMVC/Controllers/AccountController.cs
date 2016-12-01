using gestionbibliotecaMVC.BBLL;
using gestionbibliotecaMVC.BBLL.interfaces;
using gestionbibliotecaMVC.Models;
using gestionbibliotecaMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace gestionbibliotecaMVC.Controllers
{
     [Authorize]
    public class AccountController : Controller
    {
        private readonly UsuarioService  uS; 

        public AccountController()
        {
            uS = new UsuarioServiceImp();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        } 

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Verificar(LogOnModel model) 
        {
            ActionResult resultado = null;
            FormsAuthenticationTicket authTicket;
            Usuario user = null;
            if(ModelState.IsValid) 
            {
                 if(model.Username.Equals("admin") && model.Password.Equals("root")) 
                 {
                    authTicket = new FormsAuthenticationTicket(
                        1,                             // version
                        model.Username,                // user name
                        DateTime.Now,                  // created
                        DateTime.Now.AddMinutes(20),   // expires
                        model.Rememberme,              // persistent?
                        "Admin"                        // can be used to store roles
                    );

                    user = new Usuario();
                    user.Username = model.Username;
                    user.CodUsuario = 0;
                    user.Nombre = model.Username;
                    user.Passwd = model.Password;

                 } 
                 else 
                 {
                    int codUsuario = uS.getByUsernameUsuario(model.Username, model.Password);
                    user = uS.getById(codUsuario);
                    authTicket = new FormsAuthenticationTicket    (                        
                        1,                             // version
                        model.Username,                // user name
                        
                        DateTime.Now,                  // created
                        DateTime.Now.AddMinutes(20),   // expires
                        model.Rememberme,              // persistent?
                        "User"                        // can be used to store roles
                    );
                 }

                if(user!=null) 
                {
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);
                    Session["usuario"] = user;
                    resultado= RedirectToAction("Index","Home");
                } 
                else 
                {
                    ModelState.AddModelError("", "Usuario y/o contraseña incorrectos");
                    resultado = View("Login",model);
                }
            }
            else
            {
                resultado = View("Login",model);
            }

            return resultado;
        }

        [AllowAnonymous]
        public ActionResult Registro()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Registrar(Usuario usuario) 
        {
            ActionResult resultado = null;
            UsuarioService uS = new UsuarioServiceImp();
            //UsuarioController uC = new UsuarioController();
            //UsuarioViewModel model = null;

            try {
                //model.Usuario = usuario;
                //uC.Save(model);

                // TODO: LOGIN DESPUES DE REGISTRARSE

                uS.create(usuario);
                resultado = RedirectToAction("Index", "Home");
            } catch(Exception e) {
                System.Diagnostics.Debug.Write("Error registro usuario: " + e.Message);
                ViewBag.ErrorMessage = MyResources.UsuarioResources.ErrorCrear + e.Message;
            }

            return resultado;
        }

        public ActionResult Perfil()
        {
            return View();
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}