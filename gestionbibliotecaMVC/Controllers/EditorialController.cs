using gestionbibliotecaMVC.BBLL;
using gestionbibliotecaMVC.BBLL.interfaces;
using gestionbibliotecaMVC.Models;
using gestionbibliotecaMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace gestionbibliotecaMVC.Controllers {
    [Authorize(Roles = "Admin")]
    public class EditorialController : Controller {

        private EditorialService edS;
        private EjemplarService eS;
        private LibroService lS;

        public EditorialController() {
            edS = new EditorialServiceImp();
            eS = new EjemplarServiceImp();
            lS=new LibroServiceImp();
        }

        // CARGA DE TEXTOS BASICOS
        // LISTADO COMPLETO
        // VIEW DETAILS
        // LLEVA A EJEMPLAR
        // SAVE
        // DELETE

        // CARGA DE TEXTOS BASICOS
        protected void CargaTextosBasicos() {
            ViewBag.Title = MyResources.EditorialResources.ElementoTituloPagina;
            ViewBag.Message = MyResources.EditorialResources.ElementoListadoCabecera;
            @ViewBag.navEdi="active";

        }

        // LISTADO COMPLETO
        public ActionResult Index() {
            CargaTextosBasicos();
            IList<Editorial> editoriales = edS.getAllNoBorrados();
            return View(editoriales);
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
        // VIEWDETAILS
        [Authorize(Roles = "Admin")]
        public ActionResult ViewDetails(int codEditorial = -1, Boolean editar=false) {
                EditorialViewModel editorialModel = new EditorialViewModel();
                editorialModel.Editorial = edS.getById(codEditorial);
                editorialModel.Ejemplares = eS.getAllEjemplaresByEditorial(codEditorial);

               if (codEditorial > 0 && editar==true) {
                ViewBag.Title = MyResources.EditorialResources.AccionEditar;
            } else if(editorialModel.Editorial != null){
                ViewBag.Title = MyResources.EditorialResources.ElementoToken + editorialModel.Editorial.Nombre;
            } else {
                ViewBag.Title = MyResources.EditorialResources.AccionCrear;
                editorialModel.Editorial = new Editorial();
            }

           
            return View("Editorial", editorialModel);
        }

        // LLEVA A EJEMPLAR
         public ActionResult Ejemplar(int codEjemplar) {
            Ejemplar ejemplar=new Ejemplar();
            ejemplar=eS.getById(codEjemplar);
             ViewBag.Title = MyResources.EjemplarResources.ElementoTituloPagina+" - "+ejemplar.Isbn;
            return View("~/Views/Ejemplar/Ejemplar.cshtml",ejemplar);
        }
        // SAVE
        [Authorize(Roles = "Admin")]
        public ActionResult Save(EditorialViewModel model) {
            ActionResult resultado = null;

            try {
                if (model.Editorial.CodEditorial > -1) {
                    try {
                        edS.update(model.Editorial);
                          resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.EditorialResources.ErrorEditar + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                } else {
                    try {
                        edS.create(model.Editorial);
                        resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.EditorialResources.ErrorCrear + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                }
            } catch (Exception ex) {
                ViewBag.ErrorMessage = MyResources.EditorialResources.ErrorVistaDetalle + ex.Message;
                resultado = RedirectToAction("Index");
            }

            return resultado;
        }
        // DELETE
        public ActionResult Delete(int codEditorial) {
            if (edS.getById(codEditorial) != null) {
                try {
                    edS.delete(codEditorial);
                    ViewBag.Message = MyResources.EditorialResources.ExitoDelete;
                } catch (Exception ex) {
                    ViewBag.ErrorMessage = MyResources.EditorialResources.ErrorDelete + ex.Message;
                }
            } else {
                ViewBag.ErrorMessage = MyResources.EditorialResources.ErrorItemNoExiste;
            }
            return RedirectToAction("Index");
        }
    }
}
