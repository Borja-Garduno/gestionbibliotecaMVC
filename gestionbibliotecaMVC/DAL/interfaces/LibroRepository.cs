using gestionbibliotecaMVC.Models;
using System;
using System.Linq;

using System.Collections.Generic;

namespace gestionbibliotecaMVC.DAL.interfaces
    {
    interface LibroRepository
        {

        IList<Libro> getAll();
        IList<Libro> getAllNoBorrados();
        IList<Libro> getAllBorrados();
        Libro getById( int codLibro );
        Libro update( Libro libro );
        void delete( int codLibro );
        Libro create( Libro libro );
        IList<Libro> getAllLibrosByAutor(int codAutor);
    }
    }