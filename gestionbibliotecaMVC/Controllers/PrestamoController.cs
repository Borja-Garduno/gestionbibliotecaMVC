using gestionbibliotecaMVC.BBLL;
using gestionbibliotecaMVC.BBLL.interfaces;
using gestionbibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace gestionbibliotecaMVC.Controllers {
    [Authorize(Roles = "Admin")]
    public class PrestamoController : Controller {
        private PrestamoService pS;
        private UsuarioService uS;
        private EjemplarService eS;

        public PrestamoController() {
            pS = new PrestamoServiceImp();
            uS = new UsuarioServiceImp();
            eS = new EjemplarServiceImp();
        }

        //CARGA DE TEXTOS BASICOS
        //LISTADO COMPLETO
        //VIEW DETAILS
        //SAVE
        //DELETE

        // CARGA DE TEXTOS BASICOS
        // LISTADO COMPLETO
        // VISTA EN DETALLE
        // SAVE
        // DELETE


        // CARGA DE TEXTOS BASICOS
        protected void CargaTextosBasicos() {
            ViewBag.Title = MyResources.PrestamoResources.ElementoTituloPagina;
            ViewBag.Message = MyResources.PrestamoResources.ElementoListadoCabecera;

            @ViewBag.navPre = "active";
        }


        // LISTADO COMPLETO
        [Authorize(Roles = "Admin")]
        public ActionResult Index() {
            CargaTextosBasicos();
            IList<Prestamo> prestamos = pS.getAll();
            return View(prestamos);
        }
        
        // VIEWDETAILS
        [Authorize(Roles = "Admin")]
        public ActionResult ViewDetails(int codPrestamo = -1, Boolean editar = false) {
            Prestamo prestamo = pS.getById(codPrestamo);

            if (codPrestamo > 0 && editar == true) {
                // EDITAR
                ViewBag.Title = MyResources.PrestamoResources.AccionEditar;

                ViewBag.UsuarioList = new SelectList(uS.getAllNoBorrados() as System.Collections.IEnumerable,"CodUsuario","Nombre");

                // DESPLEGABLE USUARIOS
                //IList<Usuario> usuarios = uS.getAll();
                //List<SelectListItem> DesplegableUsuarios = new List<SelectListItem>();
                //foreach (var usuario in usuarios) {
                //    if (usuario.CodUsuario == prestamo.Usuario.CodUsuario) {
                //        DesplegableUsuarios.Add(new SelectListItem { Text = usuario.Nombre, Value = usuario.CodUsuario.ToString(), Selected = true });
                //    } else {
                //        DesplegableUsuarios.Add(new SelectListItem { Text = usuario.Nombre, Value = usuario.CodUsuario.ToString() });
                //    }
                //}
                //ViewData["usuarios"] = DesplegableUsuarios;
                // FIN DESPLEGABLE USUARIOS
            } else if(prestamo != null) {
                // VISUALIZAR
                ViewBag.Title = MyResources.PrestamoResources.ElementoToken + prestamo.Ejemplar.CodEjemplar+" "+ prestamo.FRecogida;
            } else {
                // CREAR
                ViewBag.Title = MyResources.PrestamoResources.AccionCrear;

                ViewBag.UsuarioList = new SelectList(uS.getAllNoBorrados() as System.Collections.IEnumerable,"CodUsuario","Nombre");
                ViewBag.EjemplarList = new SelectList(eS.getAllNoBorrados() as System.Collections.IEnumerable,"CodEjemplar","Titulo");

                prestamo = new Prestamo();
            }

            return View("Prestamo", prestamo);
        }

          // SAVE
        public ActionResult Save(Prestamo prestamo) {
            ActionResult resultado = null;

            try {
                if (prestamo.CodPrestamo > -1) {
                    try {
                        pS.update(prestamo);
                        resultado = View("Prestamo", prestamo);
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.PrestamoResources.ErrorEditar + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                } else {
                    try {
                        System.Console.WriteLine("Cod Usuario: " + prestamo.Usuario.CodUsuario);
                        System.Console.WriteLine("Cod Ejemplar: " + prestamo.Ejemplar.CodEjemplar);

                        pS.create(prestamo);
                        resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.PrestamoResources.ErrorCrear + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                }
            } catch (Exception ex) {
                ViewBag.ErrorMessage = MyResources.PrestamoResources.ErrorVistaDetalle + ex.Message;
                resultado = RedirectToAction("Index");
            }

            return resultado;
        }
          // DELETE
          // Los prestamos no se borran
        public ActionResult Delete(int codEjemplar) {
            if (pS.getById(codEjemplar) != null) {
                try {
                    pS.delete(codEjemplar);
                    ViewBag.Message = MyResources.PrestamoResources.ExitoDelete;
                } catch (Exception ex) {
                    ViewBag.ErrorMessage = MyResources.PrestamoResources.ErrorDelete + ex.Message;
                }
            } else {
                ViewBag.ErrorMessage = MyResources.PrestamoResources.ErrorItemNoExiste;
            }
            return RedirectToAction("Index");
        }



    }
}

