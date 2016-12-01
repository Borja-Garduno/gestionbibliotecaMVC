using gestionbibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionbibliotecaMVC.ViewModel {
    public class UsuarioViewModel {
        private Usuario usuario;
        private IList<Prestamo> prestamos;

        public UsuarioViewModel() {
            usuario = new Usuario();
            prestamos = new List<Prestamo>();
        }

        public Usuario Usuario {
            get {
                return usuario;
            }

            set {
                usuario = value;
            }
        }

        public IList<Prestamo> Prestamos {
            get {
                return prestamos;
            }

            set {
                prestamos = value;
            }
        }
    }
}