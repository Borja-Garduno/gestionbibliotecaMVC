using System;
using System.Collections.Generic;
using System.Web.Mvc;
using gestionbibliotecaMVC.BBLL.interfaces;
using gestionbibliotecaMVC.Models;
using gestionbibliotecaMVC.BBLL;
using gestionbibliotecaMVC.ViewModel;

namespace gestionbibliotecaMVC.Controllers {
    [Authorize(Roles = "Admin")]
    public class EjemplarController : Controller {
        private EjemplarService eS;
        private LibroService lS;
        private AutorService aS;
        private EditorialService edS;
        private PrestamoService pS;
        private UsuarioService uS;
        
        public EjemplarController() {
            eS = new EjemplarServiceImp();
            lS = new LibroServiceImp();
            aS = new AutorServiceImp();
            edS = new EditorialServiceImp();
            pS = new PrestamoServiceImp();
            uS = new UsuarioServiceImp();
        }

        // CARGA DE TEXTOS BASICOS
        // LISTADO COMPLETO
        // VISTA EN DETALLE
        // LLEVA A LIBRO
        // LLEVA A AUTOR
        // SAVE
        // DELETE

        // CARGA DE TEXTOS BASICOS
        protected void CargaTextosBasicos() {
            ViewBag.Title = MyResources.EjemplarResources.ElementoTituloPagina;
            ViewBag.Message = MyResources.EjemplarResources.ElementoListadoCabecera;
            @ViewBag.navEje="active";

        }

        // LISTADO COMPLETO
        public ActionResult Index() {
            CargaTextosBasicos();
            IList<Ejemplar> ejemplares = eS.getAllNoBorrados();
            return View(ejemplares);
        }

         // VISTA EN DETALLE
        [Authorize(Roles = "Admin")]
        public ActionResult ViewDetails(int codEjemplar = -1, Boolean editar = false) {
            UsuarioEjemplarViewModel usuarioejemplar = new UsuarioEjemplarViewModel();

            //Ejemplar ejemplar = eS.getById(codEjemplar);
            usuarioejemplar.Ejemplar = eS.getById(codEjemplar);

            Libro libro = null;

            if (codEjemplar > 0 && editar == true) {
                ViewBag.Title = MyResources.EjemplarResources.AccionEditar;
                // DESPLEGABLE LIBRO
                ViewBag.LibrosList= new SelectList(lS.getAllNoBorrados() as System.Collections.IEnumerable, "CodLibro", "Titulo");
                // FIN DESPLEGABLE LIBRO

                // DESPLEGABLE EDITORIAL
                  ViewBag.EditorialList = new SelectList(edS.getAllNoBorrados() as System.Collections.IEnumerable, "CodEditorial", "Nombre");
                // FIN DESPLEGABLE EDITORIAL
            } else if (usuarioejemplar.Ejemplar != null) {
                ViewBag.Title = MyResources.EjemplarResources.ElementoToken + usuarioejemplar.Ejemplar.Isbn;

                // DESPLEGABLE USUARIOS PARA RESERVA DE EJEMPLAR
                ViewBag.UsuarioList = new SelectList(uS.getAllNoBorrados() as System.Collections.IEnumerable,"CodUsuario","Nombre");
            } else {
                ViewBag.Title = MyResources.EjemplarResources.AccionCrear;
                libro = new Libro();
            }

            return View("Ejemplar", usuarioejemplar);
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

        // LLEVA A AUTOR
        public ActionResult Autor(int codAutor) {
            AutorViewModel avm=new AutorViewModel();
           avm.Autor=aS.getById(codAutor);
            avm.Libros=lS.getAllLibrosByAutor(codAutor);
            
             ViewBag.Title = MyResources.AutorResources.ElementoTituloPagina+" - "+avm.Autor.Nombre +" "+ avm.Autor.Apellidos;
            return View("~/Views/Autor/Autor.cshtml",avm);
        }

        // SAVE
        [Authorize(Roles = "Admin")]
        public ActionResult Save(UsuarioEjemplarViewModel usuarioejemplar) {
            ActionResult resultado = null;

            try {
                if (usuarioejemplar.Ejemplar.CodEjemplar > -1) {
                    try {
                        eS.update(usuarioejemplar.Ejemplar);
                        resultado = View("Ejemplar", usuarioejemplar.Ejemplar);
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.EjemplarResources.ErrorEditar + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                } else {
                    try {
                        eS.create(usuarioejemplar.Ejemplar);
                        resultado = RedirectToAction("Index");
                    } catch (Exception ex) {
                        ViewBag.ErrorMessage = MyResources.EjemplarResources.ErrorCrear + ex.Message;
                        resultado = RedirectToAction("Index");
                    }
                }
            } catch (Exception ex) {
                ViewBag.ErrorMessage = MyResources.EjemplarResources.ErrorVistaDetalle + ex.Message;
                resultado = RedirectToAction("Index");
            }

            return resultado;
        }

        // DELETE
        public ActionResult Delete(int codEjemplar) {
            if (eS.getById(codEjemplar) != null) {
                try {
                    eS.delete(codEjemplar);
                    ViewBag.Message = MyResources.EjemplarResources.ExitoDelete;
                } catch (Exception ex) {
                    ViewBag.ErrorMessage = MyResources.EjemplarResources.ErrorDelete + ex.Message;
                }
            } else {
                ViewBag.ErrorMessage = MyResources.EjemplarResources.ErrorItemNoExiste;
            }
            return RedirectToAction("Index");
        }

        // RESERVAR
        public ActionResult Reservar(UsuarioEjemplarViewModel usuarioejemplar) {
            ActionResult resultado = null;
            Prestamo prestamo = new Prestamo();

            try {
                prestamo.Ejemplar.CodEjemplar = usuarioejemplar.Ejemplar.CodEjemplar;
                prestamo.Usuario.CodUsuario = usuarioejemplar.Usuario.CodUsuario;
                prestamo.FRecogida = DateTime.Now;
                // SE METE FECHA ACTUAL, PERO EN EL PROCEDIMIENTO ALMACENADO SE GUARDA NULA. LA FECHA DE DEVOLUCION UNICAMENTE SE METE CUANDO SE DEVUELVA
                prestamo.FDevolucion = DateTime.Now;

                pS.create(prestamo);
                resultado = RedirectToAction("Index");
            } catch (Exception ex) {
                ViewBag.ErrorMessage = MyResources.EjemplarResources.ErrorVistaDetalle + ex.Message;
                resultado = RedirectToAction("Prueba");
            }

            return resultado;
        }
    }
}
