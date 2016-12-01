using gestionbibliotecaMVC.Models;
using System;
using System.Linq;

using System.Collections.Generic;

namespace gestionbibliotecaMVC.DAL.interfaces
    {
    interface EjemplarRepository
        {

        IList<Ejemplar> getAll();
        IList<Ejemplar> getAllNoBorrados();
        IList<Ejemplar> getAllBorrados();
        Ejemplar getById( int codEjemplar );
        Ejemplar update( Ejemplar ejemplar );
        void delete( int codEjemplar );
        Ejemplar create( Ejemplar ejemplar );
        IList<Ejemplar> getEjemplaresByLibro(int codLibro);
        IList<Ejemplar> getAllEjemplaresByEditorial(int codEditorial);

    }
    }