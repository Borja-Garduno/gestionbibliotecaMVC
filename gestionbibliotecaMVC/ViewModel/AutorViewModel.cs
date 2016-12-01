using gestionbibliotecaMVC.Models;
using System.Collections.Generic;

namespace gestionbibliotecaMVC.ViewModel {
    public class AutorViewModel {
        private Autor autor;
         private IList<Libro> libros;

        public AutorViewModel() {
            autor = new Autor();
            libros = new List<Libro>();
        }

        public Autor Autor {
            get {
                return autor;
            }

            set {
                autor = value;
            }
        }
          public IList<Libro> Libros {
            get {
                return libros;
            }

            set {
                libros = value;
            }
        }

    }
}