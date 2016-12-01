using gestionbibliotecaMVC.BBLL;
using gestionbibliotecaMVC.BBLL.interfaces;
using gestionbibliotecaMVC.Models;
using MyResources;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace gestionbibliotecaMVC.Controllers {
    public class HomeController : Controller {
        private UsuarioService uS;

        public HomeController() {
            uS = new UsuarioServiceImp();

        }

        // CARGA DE TEXTOS BASICOS
        public void CargaTextosBasicos() {
            ViewBag.Title = MyResources.Resources.MensajeTituloPagina;
            ViewBag.Message = MyResources.Resources.MensajeBienvenida;
        }


        // GET: Home
        public ActionResult Index() {
            CargaTextosBasicos();
            IList<Usuario> users = uS.getAll();
             List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem());
            foreach (var user in users) {
                li.Add(new SelectListItem { Text = user.Nombre, Value = user.CodUsuario.ToString() });
            }
            ViewData["users"]=li;
            return View();

        }

        public ActionResult SetCulture(string culture) {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

    }
}