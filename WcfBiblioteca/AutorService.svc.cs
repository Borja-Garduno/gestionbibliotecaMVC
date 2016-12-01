using gestionbibliotecaMVC.BBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AutorService : IAutorService {
        public Autor getAutorById(int codAutor) {
            Autor autor = null;

            gestionbibliotecaMVC.BBLL.interfaces.AutorService aS = new AutorServiceImp();
            gestionbibliotecaMVC.Models.Autor aux = aS.getById(codAutor);

            if(aux==null) {
                autor.ErrorMessage = "El autor no se ha encontrado";
                throw new Exception();
            } else {
                autor.Nombre = aux.Nombre;
                autor.Apellidos = aux.Apellidos;
            }

            return autor;
        }

        public string GetVersion() {
            return "v1.0";
        }
    }
}
