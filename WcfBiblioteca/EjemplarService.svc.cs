using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using gestionbibliotecaMVC.BBLL;

namespace WcfBiblioteca {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EjemplarService : IEjemplarService {
         gestionbibliotecaMVC.BBLL.interfaces.EjemplarService eS;

        public EjemplarService() {
            eS=new EjemplarServiceImp();
        }

         public Ejemplar getEjemplarById(int codEjemplar) {
            Ejemplar ejemplar=new Ejemplar();
            
           
            gestionbibliotecaMVC.Models.Ejemplar aux=eS.getById(codEjemplar);

            if (aux==null) {
                ejemplar.ErrorMessage="El ejemplar no ha sido encontrado";
                throw new Exception();
            } else {
                ejemplar.Titulo=aux.Titulo;
                ejemplar.Isbn=aux.Isbn;
                ejemplar.CodEditorial=aux.Editorial.CodEditorial;
                ejemplar.CodEjemplar=aux.CodEjemplar;
                ejemplar.CodLibro=aux.CodLibro;
                ejemplar.CodAutor=aux.Autor.CodAutor;
            }
            return ejemplar;

        }
        public Ejemplar create(Ejemplar ejemplar) {
            
            gestionbibliotecaMVC.Models.Ejemplar aux=new gestionbibliotecaMVC.Models.Ejemplar();
            
            
            aux.Isbn=ejemplar.Isbn;
            aux.Editorial.CodEditorial=ejemplar.CodEditorial;
            aux.NPaginas=ejemplar.NPaginas;
            aux.FPublicacion=ejemplar.FPublicacion;
            aux.CodLibro=ejemplar.CodLibro;
            aux.Autor.CodAutor=ejemplar.CodAutor;
            try {
                 aux=eS.create(aux);

            ejemplar.CodEjemplar=aux.CodEjemplar;
            } catch (Exception) {

               ejemplar.ErrorMessage="No se ha podido crear el ejemplar";
            }
           
            return ejemplar;
        }

        public void delete(int codEjemplar) {
           gestionbibliotecaMVC.Models.Ejemplar aux=eS.getById(codEjemplar);
           Ejemplar e=null;
            if (aux.Editorial.CodEditorial==-1) {
                e=new Ejemplar();
                e.ErrorMessage="El Ejemplar que se ha tratado de borrar no figura en la base de datos";
            } else {
                eS.delete(codEjemplar);
            }
        }

        public IList<Ejemplar> getAll() {
            IList<Ejemplar>ejemplares=new List<Ejemplar>();
            IList<gestionbibliotecaMVC.Models.Ejemplar> aux=eS.getAll();
            Ejemplar ejemplar;
             if (aux==null) {
               ejemplar=new Ejemplar();
                ejemplar.ErrorMessage="El ejemplar no ha sido encontrado";
                throw new Exception();
            } else {
                foreach (var item in aux) {
                    ejemplar=new Ejemplar();
                    ejemplar.Titulo=item.Titulo;
                    ejemplar.Isbn=item.Isbn;
                    ejemplar.CodEjemplar=item.CodEjemplar;
                    ejemplar.CodEditorial=item.Editorial.CodEditorial;
                    ejemplar.NPaginas=item.NPaginas;
                    ejemplar.FPublicacion=item.FPublicacion;
                    ejemplar.CodLibro=item.CodLibro;
                    ejemplar.CodAutor=item.Autor.CodAutor;
                    ejemplares.Add(ejemplar);
                    
                }
                
            }
            return ejemplares;
        }

        public IList<Ejemplar> getAllBorrados() {
            IList<Ejemplar>ejemplares=new List<Ejemplar>();
            IList<gestionbibliotecaMVC.Models.Ejemplar> aux=eS.getAllBorrados();
            Ejemplar ejemplar;
             if (aux==null) {
                ejemplar=new Ejemplar();
                ejemplar.ErrorMessage="El ejemplar no ha sido encontrado";
                throw new Exception();
            } else {
                foreach (var item in aux) {
                     ejemplar=new Ejemplar();
                    ejemplar.Titulo=item.Titulo;
                    ejemplar.Isbn=item.Isbn;
                    ejemplar.CodEjemplar=item.CodEjemplar;
                    ejemplar.CodEditorial=item.Editorial.CodEditorial;
                    ejemplar.NPaginas=item.NPaginas;
                    ejemplar.FPublicacion=item.FPublicacion;
                     ejemplar.CodLibro=item.CodLibro;
                    ejemplar.CodAutor=item.Autor.CodAutor;
                    ejemplares.Add(ejemplar);
                    
                }
                
            }
            return ejemplares;
        }

        public IList<Ejemplar> getAllEjemplaresByEditorial(int codEditorial) {
            IList<Ejemplar>ejemplares=new List<Ejemplar>();
            IList<gestionbibliotecaMVC.Models.Ejemplar> aux=eS.getAllEjemplaresByEditorial(codEditorial);
            Ejemplar ejemplar;
             if (aux==null) {
                ejemplar=new Ejemplar();
                ejemplar.ErrorMessage="El ejemplar no ha sido encontrado";
                throw new Exception();
            } else {
                foreach (var item in aux) {
                     ejemplar=new Ejemplar();
                    ejemplar.Titulo=item.Titulo;
                    ejemplar.Isbn=item.Isbn;
                    ejemplar.CodEjemplar=item.CodEjemplar;
                    ejemplar.CodEditorial=item.Editorial.CodEditorial;
                    ejemplar.NPaginas=item.NPaginas;
                    ejemplar.CodLibro=item.CodLibro;
                    ejemplar.CodAutor=item.Autor.CodAutor;
                    ejemplar.FPublicacion=item.FPublicacion;
                    ejemplares.Add(ejemplar);
                    
                }
                
            }
            return ejemplares;
        }

        public IList<Ejemplar> getAllNoBorrados() {
            IList<Ejemplar>ejemplares=new List<Ejemplar>();
            IList<gestionbibliotecaMVC.Models.Ejemplar> aux=eS.getAllNoBorrados();
            Ejemplar ejemplar;
             if (aux==null) {
                ejemplar=new Ejemplar();
                ejemplar.ErrorMessage="El ejemplar no ha sido encontrado";
                throw new Exception();
            } else {
                foreach (var item in aux) {
                     ejemplar=new Ejemplar();
                    ejemplar.Titulo=item.Titulo;
                    ejemplar.Isbn=item.Isbn;
                    ejemplar.CodEjemplar=item.CodEjemplar;
                    ejemplar.CodEditorial=item.Editorial.CodEditorial;
                    ejemplar.NPaginas=item.NPaginas;
                    ejemplar.FPublicacion=item.FPublicacion;
                     ejemplar.CodLibro=item.CodLibro;
                    ejemplar.CodAutor=item.Autor.CodAutor;
                    ejemplares.Add(ejemplar);
                    
                }
                
            }
            return ejemplares;
        }

       

        public IList<Ejemplar> getEjemplaresByLibro(int codLibro) {
           IList<Ejemplar>ejemplares=new List<Ejemplar>();
            IList<gestionbibliotecaMVC.Models.Ejemplar> aux=eS.getEjemplaresByLibro(codLibro);
            Ejemplar ejemplar;
             if (aux==null) {
                ejemplar=new Ejemplar();
                ejemplar.ErrorMessage="El ejemplar no ha sido encontrado";
                throw new Exception();
            } else {
                foreach (var item in aux) {
                     ejemplar=new Ejemplar();
                    ejemplar.Titulo=item.Titulo;
                    ejemplar.Isbn=item.Isbn;
                    ejemplar.CodEjemplar=item.CodEjemplar;
                    ejemplar.CodEditorial=item.Editorial.CodEditorial;
                    ejemplar.NPaginas=item.NPaginas;
                    ejemplar.FPublicacion=item.FPublicacion;
                     ejemplar.CodLibro=item.CodLibro;
                    ejemplar.CodAutor=item.Autor.CodAutor;
                    ejemplares.Add(ejemplar);
                    
                }
                
            }
            return ejemplares;
        }

        public string GetVersion() {
            return "v1.0";
        }

        public Ejemplar update(Ejemplar ejemplar) {
             gestionbibliotecaMVC.Models.Ejemplar aux=new gestionbibliotecaMVC.Models.Ejemplar();
            
            aux.CodEjemplar=ejemplar.CodEjemplar;
            aux.Isbn=ejemplar.Isbn;
            aux.Editorial.CodEditorial=ejemplar.CodEditorial;
            aux.NPaginas=ejemplar.NPaginas;
            aux.FPublicacion=ejemplar.FPublicacion;
            aux.CodLibro=ejemplar.CodLibro;

            try {
                  eS.update(aux);
            } catch (Exception) {
                
                ejemplar.ErrorMessage="No se ha podido actualizar el ejemplar";
            }

            
           
            return ejemplar;

           
        }
    }
}
