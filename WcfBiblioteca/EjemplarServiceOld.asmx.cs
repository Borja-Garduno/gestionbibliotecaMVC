using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//using WsSOAP.BBLL;

namespace WcfBiblioteca {
    /// <summary>
    /// Summary description for EjemplarServiceOld
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EjemplarServiceOld : System.Web.Services.WebService {

        public string GetVersion() {
            return "v1.0";
        }

        [WebMethod]
        public EjemplarWS GetEjemplarById(int codEjemplar) {
            EjemplarWS ejemplar=null;
            //WsSOAP.BBLL.interfaces.EjemplarService eS=new EjemplarServiceImp();
           // WsSOAP.Models.Ejemplar aux=eS.getById(codEjemplar);
            ejemplar=new EjemplarWS();

            if (eS==null) {
                ejemplar.ErrorMessage="Ejemplar No Encontrado";
            } else {
                ejemplar.Titulo=aux.Titulo;
                ejemplar.Isbn=aux.Isbn;
                ejemplar.CodEditorial=aux.CodEditorial;
                ejemplar.CodEjemplar=aux.CodEjemplar;
                ejemplar.CodLibro=aux.CodLibro;
            }
            return ejemplar;
        }

        [WebMethod]
        public List<EjemplarWS> GetAll() {
            EjemplarWS ejemplar=null;
            List<EjemplarWS> ejemplares=null;

            WsSOAP.BBLL.interfaces.EjemplarService eS=new EjemplarServiceImp();

            IList< WsSOAP.Models.Ejemplar> aux=eS.getAll();

            ejemplares=new List<EjemplarWS>();
            ejemplar=new EjemplarWS();

            if (eS==null) {
                ejemplar.ErrorMessage="Ejemplar No Encontrado";
            } else {
                 foreach (var item in aux) {
                    ejemplar=new EjemplarWS();
                    ejemplar.Titulo=item.Titulo;
                    ejemplar.Isbn=item.Isbn;
                    ejemplar.CodEjemplar=item.CodEjemplar;
                    ejemplar.CodEditorial=item.CodEditorial;
                    ejemplar.NPaginas=item.NPaginas;
                    ejemplar.FPublicacion=item.FPublicacion;
                    ejemplar.CodLibro=item.CodLibro;
                   
                    ejemplares.Add(ejemplar);
                    
                }
            }
            return ejemplares;
        }

        [WebMethod]
        public List<EjemplarWS> GetAllNoBorrados() {
            EjemplarWS ejemplar = null;
            List<EjemplarWS> ejemplares = null;
            WsSOAP.BBLL.interfaces.EjemplarService eS = new EjemplarServiceImp();
            IList<WsSOAP.Models.Ejemplar> aux = eS.getAllNoBorrados();
            ejemplares = new List<EjemplarWS>();
            ejemplar = new EjemplarWS();

            if (eS == null) {
                ejemplar.ErrorMessage = "Ejemplar No Encontrado";
            } else {
                foreach (var item in aux) {
                    ejemplar = new EjemplarWS();
                    ejemplar.Titulo = item.Titulo;
                    ejemplar.Isbn = item.Isbn;
                    ejemplar.CodEjemplar = item.CodEjemplar;
                    ejemplar.CodEditorial = item.CodEditorial;
                    ejemplar.NPaginas = item.NPaginas;
                    ejemplar.FPublicacion = item.FPublicacion;
                    ejemplar.CodLibro = item.CodLibro;

                    ejemplares.Add(ejemplar);

                }
            }
            return ejemplares;
        }

        [WebMethod]
        public List<EjemplarWS> GetAllBorrados() {
            EjemplarWS ejemplar = null;
            List<EjemplarWS> ejemplares = null;
            WsSOAP.BBLL.interfaces.EjemplarService eS = new EjemplarServiceImp();
            IList<WsSOAP.Models.Ejemplar> aux = eS.getAllBorrados();
            ejemplares = new List<EjemplarWS>();
            ejemplar = new EjemplarWS();

            if (eS == null) {
                ejemplar.ErrorMessage = "Ejemplar No Encontrado";
            } else {
                foreach (var item in aux) {
                    ejemplar = new EjemplarWS();
                    ejemplar.Titulo = item.Titulo;
                    ejemplar.Isbn = item.Isbn;
                    ejemplar.CodEjemplar = item.CodEjemplar;
                    ejemplar.CodEditorial = item.CodEditorial;
                    ejemplar.NPaginas = item.NPaginas;
                    ejemplar.FPublicacion = item.FPublicacion;
                    ejemplar.CodLibro = item.CodLibro;

                    ejemplares.Add(ejemplar);

                }
            }
            return ejemplares;
        }

        [WebMethod]
        public EjemplarWS update(EjemplarWS ejemplar) {
             WsSOAP.BBLL.interfaces.EjemplarService eS = new EjemplarServiceImp();
            WsSOAP.Models.Ejemplar aux=new WsSOAP.Models.Ejemplar();
            
            aux.CodEjemplar=ejemplar.CodEjemplar;
            aux.Isbn=ejemplar.Isbn;
            aux.CodEditorial=ejemplar.CodEditorial;
            aux.NPaginas=ejemplar.NPaginas;
            aux.FPublicacion=ejemplar.FPublicacion;
            aux.CodLibro=ejemplar.CodLibro;

            try {
                aux = eS.update(aux);
            } catch (Exception) {

               ejemplar.ErrorMessage="No se ha podido actualizar el ejemplar";
            }

            
            return ejemplar;
        }

        [WebMethod]
        public EjemplarWS Delete(int codEjemplar) {
           WsSOAP.BBLL.interfaces.EjemplarService eS = new EjemplarServiceImp();
           WsSOAP.Models.Ejemplar aux=eS.getById(codEjemplar);
            EjemplarWS e=null;
            if (aux.CodEditorial==-1) {
                e = new EjemplarWS();
                e.ErrorMessage="El Ejemplar que se ha tratado de borrar no figura en la base de datos";
            } else {
                //e = new EjemplarWS();
                //e.Titulo = aux.Titulo;
                //e.Isbn = aux.Isbn;
                //e.CodEjemplar = aux.CodEjemplar;
                //e.CodEditorial = aux.CodEditorial;
                //e.NPaginas = aux.NPaginas;
                //e.FPublicacion = aux.FPublicacion;
                //e.CodLibro = aux.CodLibro;
                eS.delete(codEjemplar);    
            }

            

            return e;
        }

        [WebMethod]
        public EjemplarWS Create(EjemplarWS ejemplar) {
            
            WsSOAP.BBLL.interfaces.EjemplarService eS = new EjemplarServiceImp();
            WsSOAP.Models.Ejemplar aux=new WsSOAP.Models.Ejemplar();
            
            aux.Isbn=ejemplar.Isbn;
            aux.CodEditorial=ejemplar.CodEditorial;
            aux.NPaginas=ejemplar.NPaginas;
            aux.FPublicacion=ejemplar.FPublicacion;
            aux.CodLibro=ejemplar.CodLibro;

            try {
                aux = eS.create(aux);
                ejemplar.CodEjemplar=aux.CodEjemplar;
            } catch (Exception) {

                ejemplar.ErrorMessage="No se ha podido crear el ejemplar";
            }

            
            return ejemplar;
        }

        [WebMethod]
        public List<EjemplarWS> GetEjemplaresByLibro(int codLibro) {
           EjemplarWS ejemplar=null;
            List<EjemplarWS> ejemplares=null;
            WsSOAP.BBLL.interfaces.EjemplarService eS=new EjemplarServiceImp();
            IList< WsSOAP.Models.Ejemplar> aux=eS.getEjemplaresByLibro(codLibro);
            ejemplares=new List<EjemplarWS>();
            ejemplar=new EjemplarWS();

            if (eS==null) {
                ejemplar.ErrorMessage="Ejemplar No Encontrado";
            } else {
                 foreach (var item in aux) {
                    ejemplar=new EjemplarWS();
                    ejemplar.Titulo=item.Titulo;
                    ejemplar.Isbn=item.Isbn;
                    ejemplar.CodEjemplar=item.CodEjemplar;
                    ejemplar.CodEditorial=item.CodEditorial;
                    ejemplar.NPaginas=item.NPaginas;
                    ejemplar.FPublicacion=item.FPublicacion;
                    ejemplar.CodLibro=item.CodLibro;
                   
                    ejemplares.Add(ejemplar);
                    
                }
            }
            return ejemplares;
        }

        [WebMethod]
        public List<EjemplarWS> GetEjemplaresByEditorial(int codEditorial) {
            EjemplarWS ejemplar=null;
            List<EjemplarWS> ejemplares=null;
            WsSOAP.BBLL.interfaces.EjemplarService eS=new EjemplarServiceImp();
            IList< WsSOAP.Models.Ejemplar> aux=eS.getAllEjemplaresByEditorial(codEditorial);
            ejemplares=new List<EjemplarWS>();
            ejemplar=new EjemplarWS();

            if (eS==null) {
                ejemplar.ErrorMessage="Ejemplar No Encontrado";
            } else {
                 foreach (var item in aux) {
                    ejemplar=new EjemplarWS();
                    ejemplar.Titulo=item.Titulo;
                    ejemplar.Isbn=item.Isbn;
                    ejemplar.CodEjemplar=item.CodEjemplar;
                    ejemplar.CodEditorial=item.CodEditorial;
                    ejemplar.NPaginas=item.NPaginas;
                    ejemplar.FPublicacion=item.FPublicacion;
                    ejemplar.CodLibro=item.CodLibro;
                   
                    ejemplares.Add(ejemplar);
                    
                }
            }
            return ejemplares;
        }


    }
}
