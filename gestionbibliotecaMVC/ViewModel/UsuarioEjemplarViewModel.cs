using gestionbibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionbibliotecaMVC.ViewModel {
    public class UsuarioEjemplarViewModel {

        private Usuario usuario;
        private Ejemplar ejemplar;

        public UsuarioEjemplarViewModel() {
            Usuario = new Usuario();
            Ejemplar = new Ejemplar();
        }

        public Usuario Usuario {
            get {
                return usuario;
            }

            set {
                usuario = value;
            }
        }

        public Ejemplar Ejemplar {
            get {
                return ejemplar;
            }

            set {
                ejemplar = value;
            }
        }

    }
}