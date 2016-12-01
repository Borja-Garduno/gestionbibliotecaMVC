using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfBiblioteca {
    public class EjemplarWS : LibroWS{
        
        string isbn;
        string errorMessage;
        int codEjemplar;
        int codEditorial;
        int codLibro;
        int nPaginas;
        DateTime fPublicacion;

        public string Isbn {
            get {
                return isbn;
            }

            set {
                isbn = value;
            }
        }

        public string ErrorMessage {
            get {
                return errorMessage;
            }

            set {
                errorMessage = value;
            }
        }

        public int CodEjemplar {
            get {
                return codEjemplar;
            }

            set {
                codEjemplar = value;
            }
        }

        public int CodEditorial {
            get {
                return codEditorial;
            }

            set {
                codEditorial = value;
            }
        }

        public int CodLibro {
            get {
                return codLibro;
            }

            set {
                codLibro = value;
            }
        }

        public int NPaginas {
            get {
                return nPaginas;
            }

            set {
                nPaginas = value;
            }
        }

        public DateTime FPublicacion {
            get {
                return fPublicacion;
            }

            set {
                fPublicacion = value;
            }
        }
    }
}