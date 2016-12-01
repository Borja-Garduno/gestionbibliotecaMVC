using gestionbibliotecaMVC.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace gestionbibliotecaMVC.DAL.interfaces
    {
    interface EditorialRepository
        {

        IList<Editorial> getAll();
        IList<Editorial> getAllNoBorrados();
        IList<Editorial> getAllBorrados();
        Editorial getById( int codEditorial );
        Editorial update( Editorial editorial );
        void delete( int codEditorial );
        Editorial create( Editorial editorial );
        }
    }