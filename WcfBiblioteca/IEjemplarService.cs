using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace WcfBiblioteca {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEjemplarService {

        [OperationContract]
        string GetVersion();

        [OperationContract]
        Ejemplar getEjemplarById(int codEjemplar);

        [OperationContract]
        IList<Ejemplar> getAll();

        [OperationContract]
        IList<Ejemplar> getAllNoBorrados();

        [OperationContract]
        IList<Ejemplar> getAllBorrados();

        [OperationContract]
        Ejemplar update(Ejemplar ejemplar);

        [OperationContract]
        void delete(int codEjemplar);

        [OperationContract]
        Ejemplar create(Ejemplar ejemplar);

        [OperationContract]
        IList<Ejemplar> getEjemplaresByLibro(int codLibro);

        [OperationContract]
        IList<Ejemplar> getAllEjemplaresByEditorial(int codEditorial);
    



        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Ejemplar : Libro {
       string titulo="";
       string isbn="";
       int codEjemplar=-1;
       int nPaginas=0;
       DateTime fPublicacion=new DateTime();
       int codEditorial=-1;
       string errorMessage=""; 
       

        [DataMember]
        public string Titulo {
            get {
                return titulo;
            }
            set {
                titulo = value;
            }
        }

        [DataMember]
        public string Isbn {
            get {
                return isbn;
            }
            set {
                isbn = value;
            }
        }

        [DataMember (IsRequired =false)]
        public string ErrorMessage {
            get {
                return errorMessage;
            }
            set {
                errorMessage = value;
            }
        }

         [DataMember]
        public int CodEjemplar {
            get {
                return codEjemplar;
            }

            set {
                codEjemplar = value;
            }
        }

         [DataMember]
        public int NPaginas {
            get {
                return nPaginas;
            }

            set {
                nPaginas = value;
            }
        }

         [DataMember]
        public DateTime FPublicacion {
            get {
                return fPublicacion;
            }

            set {
                fPublicacion = value;
            }
        }

         [DataMember]
        public int CodEditorial {
            get {
                return codEditorial;
            }

            set {
                codEditorial = value;
            }
        }
    }
    [DataContract]
    public class Libro{
        int codLibro=-1;
        int codAutor=-1;

        [DataMember]
        public int CodLibro {
            get {
                return codLibro;
            }

            set {
                codLibro = value;
            }
        }
        [DataMember]
        public int CodAutor {
            get {
                return codAutor;
            }

            set {
                codAutor = value;
            }
        }
    }
}
