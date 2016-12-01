using gestionbibliotecaMVC.BBLL;
using gestionbibliotecaMVC.BBLL.interfaces;
using gestionbibliotecaMVC.Models;
using gestionbibliotecaMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace gestionbibliotecaMVC.Controllers {
    [Authorize(Roles = "Admin")]
    public class LibroController : Controller {

        private LibroService lS;
        private EjemplarService eS;
        private PrestamoService pS;
        private UsuarioService uS;
        private AutorService aS;
        private EditorialService edS;

        public LibroController() {
            lS = new LibroServiceImp();
            eS = new EjemplarServiceImp();
            pS = new PrestamoServiceImp();
            uS = new UsuarioServiceImp();
            aS = new AutorServiceImp();
            edS = new EditorialServiceImp();
        }

        // CARGA DE TEXTOS BASICOS
        // LISTADO COMPLETO
        // LLEVA A AUTOR
        // LLEVA A EJEMPLAR
        // LLEVA A EDITORIAL
        // VISTA EN DETALLE
        // SAVE
        // DELETE
        // AQUI RECIBIRE EL CODuSUARIO DE LA SESSION



        // CARGA DE TEXTOS BASICOS
        protected void CargaTextosBasicos() {
            ViewBag.Title = MyResources.LibroResources.ElementoTituloPagina;
            ViewBag.Message = MyResources.LibroResources.ElementoListadoCabecera;
            @ViewBag.navLib = "active";

        }

        // LISTADO COMPLETO
        [Authorize(Roles = "Admin")]
        public ActionResult Index() {
            CargaTextosBasicos();
            IList<Libro> books = lS.getAll();

            return View(books);
        }

        // LLEVA A AUTOR
        public ActionResult Autor(int codAutor) {
            AutorViewModel avm = new AutorViewModel();
            avm.Autor = aS.getById(codAutor);
            avm.Libros = lS.getAllLibrosByAutor(codAutor);

            ViewBag.Title = MyResources.AutorResources.ElementoTituloPagina + " - " + avm.Autor.Nombre + " " + avm.Autor.Apellidos;
            return View("~/Views/Autor/Autor.cshtml", avm);
        }
        // LLEVA A EJEMPLAR
        public ActionResult Ejemplar(int codEjemplar) {
            Ejemplar ejemplar = new Ejemplar();
            ejemplar = eS.getById(codEjemplar);
            ViewBag.Title = MyResources.EjemplarResources.ElementoTituloPagina + " - " + ejemplar.Isbn;
            return View("~/Views/Ejemplar/Ejemplar.cshtml", ejemplar);
        }

        // LLEVA A EDITORIAL
        public ActionResult Editorial(int codEditorial) {
            EditorialViewModel evm = new EditorialViewModel();
            evm.Editorial = edS.getById(codEditorial);
            evm.Ejemplares = eS.getAllEjemplaresByEditorial(codEditorial);
            ViewBag.Title = MyResources.AutorResources.ElementoTituloPagina + " - " + evm.Editorial.Nombre;
            return View("~/Views/Editorial/Editorial.cshtml", evm);
        }

        // VISTA EN DETALLE
        [Authorize(Roles = "Admin")]
        public ActionResult ViewDetails(int codLibro = -1, Boolean editar = false) {
            LibroViewModel libroModel = new LibroViewModel();
            libroModel.libro = lS.getById(codLibro);
            libroModel.ejemplares = eS.getEjemplaresByLibro(codLibro);



            if (codLibro > 0 && editar == true) { // UPDATE
                ViewBag.Title = MyResources.LibroResources.AccionEditar;
                // DESPLEGABLE
                ViewBag.AutorList = new SelectList(aS.getAllNoBorrados() as System.Collections.IEnumerable,"CodAutor","Nombre");
                //IList<Autor> autores = aS.getAll();
                //List<SelectListItem> DesplegableAutores = new List<SelectListItem>();
                //foreach (var autor in autores) {
                //    if (autor.CodAutor == libroModel.Libro.Autor.CodAutor) {
                //        DesplegableAutores.Add(new SelectListItem { Text = autor.Nombre+" "+autor.Apellidos, Value = autor.CodAutor.ToString(), Selected = true });
                //    } else {
                //        DesplegableAutores.Add(new SelectListItem { Text = autor.Nombre+" "+autor.Apellidos, Value = autor.CodAutor.ToString() });
                //    }
                //}
                //ViewData["autores"] = DesplegableAutores;
                // FIN DESPLEGABLE
            } else if (libroModel.Libro != null) {
                ViewBag.Title = MyResources.LibroResources.ElementoToken + libroModel.Libro.Titulo;

            } else { // CREATE
                ViewBag.Title = MyResources.LibroResources.AccionCrear;
                libroModel.Libro = new Libro();
            }

            return View("Libro", libroModel);
        }

        // SAVE
        [Authorize(Roles = "Admin")]
        public ActionResult Save(LibroViewModel model) {
            ActionResult resultado = null;

            try {
                if (model.Libro.CodLibro > -1) {// UPDATE
                    try {
                        lS.update(model.Libro); 
                        resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.infoController = MyResources.LibroResources.ErrorEditar + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                } else {// CREATE
                    try {
                        lS.create(model.Libro);

                        resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.LibroResources.ErrorCrear + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                }
            } catch (Exception ex) {
                ViewBag.ErrorMessage = MyResources.LibroResources.ErrorVistaDetalle + ex.Message;
                resultado = RedirectToAction("Index");
            }
            return resultado;
        }


        // DELETE
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int codLibro) {
            IList<Ejemplar> ejemplares = eS.getEjemplaresByLibro(codLibro);

            if (ejemplares.Count != 0) {
                if (lS.getById(codLibro) != null) {
                    try {
                        lS.delete(codLibro);
                        ViewBag.Message = MyResources.LibroResources.ExitoDelete;
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.LibroResources.ErrorDelete + ex.Message;
                    }
                } else {
                    ViewBag.ErrorMessage = MyResources.LibroResources.ErrorItemNoEncontrado;
                }
            } else {
                ViewBag.ErrorMessage = MyResources.LibroResources.ErrorBorrarTieneEjemplares;


            }


            return RedirectToAction("Index");
        }

        public ActionResult Prestamo(int codEjemplar) {

            // AQUI RECIBIRE EL CODuSUARIO DE LA SESSION
            int codUsuario = 2;
            Prestamo prestamo = new Prestamo();
            prestamo.Usuario = uS.getById(codUsuario);
            prestamo.Ejemplar = eS.getById(codEjemplar);
            prestamo.FRecogida = DateTime.Today;
            try {
                pS.create(prestamo);
                ViewBag.Message = MyResources.PrestamoResources.ExitoCrear;
            } catch (Exception ex) {
                ViewBag.ErrorMessage = MyResources.PrestamoResources.ErrorCrear + ex.Message;

            }






            return RedirectToAction("Index");
        }



    }
}