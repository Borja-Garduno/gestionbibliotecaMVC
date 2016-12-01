using gestionbibliotecaMVC.Models;
using System;
using System.Linq;

using System.Collections.Generic;

namespace gestionbibliotecaMVC.DAL.interfaces
    {
    interface UsuarioRepository
        {

        IList<Usuario> getAll();
        IList<Usuario> getAllNoBorrados();
        IList<Usuario> getAllBorrados();
        Usuario getById( int codUsuario );
        int getByUsernameUsuario(string username, string passwd);
        Usuario update( Usuario usuario );
        void delete( int codUsuario );
        Usuario create( Usuario usuario );
        }
    }
