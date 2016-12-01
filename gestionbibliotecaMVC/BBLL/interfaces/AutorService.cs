using gestionbibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionbibliotecaMVC.BBLL.interfaces
{
    public interface AutorService
    {

        IList<Autor> getAll();
        IList<Autor> getAllNoBorrados();
        IList<Autor> getAllBorradso();
        Autor getById(int codAutor);
        Autor update(Autor autor);
        void delete(int codAutor);
        Autor create(Autor autor);
    }
}
