using gestionbibliotecaMVC.BBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WcfBiblioteca {
    /// <summary>
    /// Summary description for AutorServiceOld
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AutorServiceOld : System.Web.Services.WebService {

        public string GetVersion() {
            return "v1.0";
        }

        [WebMethod]
        public AutorWS GetAutorById(int codAutor) {
            AutorWS autor = null;
            gestionbibliotecaMVC.BBLL.interfaces.AutorService aS = new AutorServiceImp();
            gestionbibliotecaMVC.Models.Autor aux = aS.getById(codAutor);
            autor = new AutorWS();

            if(aS==null) {
                autor.ErrorMessage = "Autor no encontrado.";
            } else {
                autor.Nombre = aux.Nombre + " " + aux.Apellidos;
            }

            return autor;
        }
    }
}
