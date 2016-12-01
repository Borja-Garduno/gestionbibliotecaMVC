using gestionbibliotecaMVC.BBLL;
using gestionbibliotecaMVC.BBLL.interfaces;
using gestionbibliotecaMVC.Models;
using gestionbibliotecaMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace gestionbibliotecaMVC.Controllers {
    public class UsuarioController : Controller {

        private UsuarioService uS;
        private PrestamoService pS;

        public UsuarioController() {
            uS = new UsuarioServiceImp();
            pS = new PrestamoServiceImp();
        }

        // CARGA DE TEXTOS BASICOS
        // LISTADO COMPLETO
        // VISTA EN DETALLE
        // SAVE
        // DELETE



        // CARGA DE TEXTOS BASICOS
        [Authorize(Roles = "Admin")]
        protected void CargaTextosBasicos() {
            ViewBag.Title = MyResources.UsuarioResources.ElementoTituloPagina;
            ViewBag.Message = MyResources.UsuarioResources.ElementoListadoCabecera;

            @ViewBag.navUsu = "active";
        }

        // LISTADO COMPLETO
        [Authorize(Roles = "Admin")]
        public ActionResult Index() {
            CargaTextosBasicos();
            IList<Usuario> users = uS.getAllNoBorrados();

            /*
                using gestionbibliotecaMVC.SOAPService;
                SOAPService.UsuarioService service = new SOAPService.UsuarioService();
                SOAPService.Usuario usuario = service.getUsuarioById(2, true);
            */

            return View(users);
        }

        // VIEWDETAILS
        [Authorize(Roles = "Admin")]
        public ActionResult ViewDetails(int codUsuario = -1, Boolean editar = false) {
            UsuarioViewModel usuarioModel = new UsuarioViewModel();
            usuarioModel.Usuario = uS.getById(codUsuario);
            usuarioModel.Prestamos = pS.getAllPrestamosByUsuario(codUsuario);

            if (codUsuario > 0 && editar == true) {
                ViewBag.Title = MyResources.UsuarioResources.AccionEditar;
            } else if(usuarioModel.Usuario != null) {
                ViewBag.Title = MyResources.UsuarioResources.ElementoToken + usuarioModel.Usuario.Nombre + " " + usuarioModel.Usuario.Apellidos;
            } else {
                ViewBag.Title = MyResources.UsuarioResources.AccionCrear;
                usuarioModel.Usuario = new Usuario();
            }

            return View("Usuario", usuarioModel);
        }

        // SAVE
        [Authorize(Roles = "Admin")]
        public ActionResult Save(UsuarioViewModel model) {
            ActionResult resultado = null;

            try {
                if (model.Usuario.CodUsuario > -1) {
                    try {
                        uS.update(model.Usuario);
                      resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.UsuarioResources.ErrorEditar + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                } else {
                    try {
                        //Usuario usuario = new Usuario();
                        uS.create(model.Usuario);

                        /*
                        if (usuario.CodUsuario < 0) {
                            ViewBag.ErrorMessage = "Error 2 al crear el usuario : ";
                        }
                        */

                        resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.UsuarioResources.ErrorCrear + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                }
            } catch (Exception ex) {
                ViewBag.ErrorMessage = MyResources.UsuarioResources.ErrorVistaDetalle + ex.Message;
                resultado = RedirectToAction("Index");
            }

            return resultado;
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int codUsuario) {
            if (uS.getById(codUsuario) != null) {
                try {
                    uS.delete(codUsuario);
                    ViewBag.Message = MyResources.UsuarioResources.ExitoDelete;
                } catch (Exception ex) {
                    ViewBag.ErrorMessage = MyResources.UsuarioResources.ErrorDelete + ex.Message;
                }
            } else {
                ViewBag.ErrorMessage = MyResources.UsuarioResources.ErrorItemNoEncontrado;
            }
            return RedirectToAction("Index");
        }
    }
}