using gestionbibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionbibliotecaMVC.ViewModel {
    public class LibroViewModel {
        public Libro libro;
        public IList<Ejemplar> ejemplares;

        public LibroViewModel() {
            libro = new Libro();
            ejemplares = new List<Ejemplar>();
        }
        public Libro Libro {
            get {
                return libro;
            }

            set {
                libro = value;
            }
        }
        public IList<Ejemplar> Ejemplares {
            get {
                return ejemplares;
            }

            set {
                ejemplares = value;
            }
        }
    }
}