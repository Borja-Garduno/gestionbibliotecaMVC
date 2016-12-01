using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfBiblioteca {
    public class AutorWS {
        string nombre;
        string errorMessage;

        public string Nombre {
            get {
                return nombre;
            }

            set {
                nombre = value;
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
    }
}