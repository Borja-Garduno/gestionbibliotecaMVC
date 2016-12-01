using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfBiblioteca {
    public class LibroWS {
        string titulo;

        public string Titulo {
            get {
                return titulo;
            }

            set {
                titulo = value;
            }
        }
    }
}