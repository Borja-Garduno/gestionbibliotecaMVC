using gestionbibliotecaMVC.Models;
using System.Collections.Generic;

namespace gestionbibliotecaMVC.ViewModel {
    public class EditorialViewModel {
        private Editorial editorial;
         private IList<Ejemplar> ejemplares;

        public EditorialViewModel() {
            editorial = new Editorial();
            ejemplares = new List<Ejemplar>();
        }

        public Editorial Editorial {
            get {
                return editorial;
            }

            set {
                editorial = value;
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