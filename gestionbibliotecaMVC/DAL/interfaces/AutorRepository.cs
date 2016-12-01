using gestionbibliotecaMVC.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace gestionbibliotecaMVC.DAL.interfaces
    {
    interface AutorRepository
        {

        IList<Autor> getAll();
        IList<Autor> getAllNoBorrados();
        IList<Autor> getAllBorrados();
        Autor getById( int codAutor );
        Autor update( Autor autor );
        void delete( int codAutor );
        Autor create( Autor autor );
        }
    }