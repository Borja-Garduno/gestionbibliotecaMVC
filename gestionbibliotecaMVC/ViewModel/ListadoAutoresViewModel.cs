using gestionbibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionbibliotecaMVC.ViewModel {
    public class ListadoAutoresViewModel {
        private Autor autor;
        private int NLibros;

        public Autor Autor {
            get {
                return autor;
            }

            set {
                autor = value;
            }
        }

        public int NLibros1 {
            get {
                return NLibros;
            }

            set {
                NLibros = value;
            }
        }
    }
}