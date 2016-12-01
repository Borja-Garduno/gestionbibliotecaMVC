using gestionbibliotecaMVC.BBLL;
using gestionbibliotecaMVC.BBLL.interfaces;
using gestionbibliotecaMVC.Models;
using gestionbibliotecaMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace gestionbibliotecaMVC.Controllers {
    [Authorize(Roles = "Admin")]
    public class AutorController : Controller {
        private AutorService aS;
        private LibroService lS;
        private EjemplarService eS;

        public AutorController() {
            aS=new AutorServiceImp();
            lS = new LibroServiceImp();
            eS=new EjemplarServiceImp();
        }

        // CARGA DE TEXTOS BASICOS
        // LISTADO COMPLETO
        // VIEW DETAILS
        // SAVE
        // DELETE

        // CARGA DE TEXTOS BASICOS y Nulificador de navegacion
        protected void CargaTextosBasicos() {
            ViewBag.Title = MyResources.AutorResources.ElementoTituloPagina;
            ViewBag.Message = MyResources.AutorResources.ElementoListadoCabecera;
            @ViewBag.navAut="active";

        }

        // LISTADO COMPLETO
        public ActionResult Index() {

            CargaTextosBasicos();
            IList<Autor> autores = aS.getAllNoBorrados();
            return View(autores);
        }

        // VIEW DETAILS
        public ActionResult ViewDetails(int codAutor = -1,Boolean editar=false) {
            AutorViewModel autorModel = new AutorViewModel();
            autorModel.Autor = aS.getById(codAutor);
            autorModel.Libros = lS.getAllLibrosByAutor(codAutor);

            if (codAutor>0 && editar==true) {
                ViewBag.Title = MyResources.AutorResources.AccionEditar;
            } else if (autorModel.Autor!=null) {
                ViewBag.Title=MyResources.AutorResources.ElementoToken + autorModel.Autor.Nombre + " " + autorModel.Autor.Apellidos;
            } else {
                ViewBag.Title = MyResources.AutorResources.AccionCrear;
                autorModel.Autor = new Autor();
            }

            

            return View("Autor", autorModel);
        }

            //LLEVA A LIBRO
        public ActionResult Libro(int codLibro) {
            LibroViewModel lvm = new LibroViewModel();
            lvm.libro = lS.getById(codLibro);
            lvm.ejemplares = eS.getEjemplaresByLibro(codLibro);
            // return RedirectToRoute("Libro/Libro",lvm);
             ViewBag.Title = MyResources.LibroResources.ElementoTituloPagina+" - "+lvm.libro.Titulo;
            return View("~/Views/Libro/Libro.cshtml",lvm);
        }

        // SAVE
        public ActionResult Save(AutorViewModel avm) {
            ActionResult resultado = null;

            //ViewBag.infoController = "Controller Save";
            try {
                if (avm.Autor.CodAutor > -1) {
                    try {
                        aS.update(avm.Autor);
                        
                        resultado = View("Autor", avm);
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.AutorResources.ErrorEditar + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                } else {
                    try {
                        aS.create(avm.Autor);
                        resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.AutorResources.ErrorCrear + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                }
            } catch (Exception ex) {
                ViewBag.ErrorMessage = MyResources.AutorResources.ErrorVistaDetalle + ex.Message;
                resultado = RedirectToAction("Index");
            }

            return resultado;
        }
        // DELETE
        public ActionResult Delete(int codAutor) {
            ViewBag.infoController = "Controller Delete";
            if (aS.getById(codAutor) != null) {
                try {
                    aS.delete(codAutor);
                    ViewBag.Message = MyResources.AutorResources.ExitoDelete;
                } catch (Exception ex) {
                    ViewBag.ErrorMessage = MyResources.AutorResources.ErrorDelete + ex.Message;
                }
            } else {
                ViewBag.ErrorMessage = MyResources.AutorResources.ErrorItemNoExiste;
            }
            return RedirectToAction("Index");
        }
    }
}
