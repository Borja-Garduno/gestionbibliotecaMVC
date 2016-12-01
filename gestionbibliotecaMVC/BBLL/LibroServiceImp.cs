using gestionbibliotecaMVC.BBLL.interfaces;
using System.Collections.Generic;
using gestionbibliotecaMVC.Models;
using gestionbibliotecaMVC.DAL.interfaces;
using gestionbibliotecaMVC.DAL;
using System;

namespace gestionbibliotecaMVC.BBLL {
    public class LibroServiceImp : LibroService {

        private LibroRepository lRepo = new LibroRepositoryImp();
        public Libro create(Libro libro) {
            return lRepo.create(libro);
        }

        public void delete(int codLibro) {
            lRepo.delete(codLibro);
        }

        public IList<Libro> getAll() {
            return lRepo.getAll();
        }

        public IList<Libro> getAllBorrados() {
            return lRepo.getAllBorrados();
        }

        public IList<Libro> getAllLibrosByAutor(int codAutor) {
             return lRepo.getAllLibrosByAutor(codAutor);
        }

        public IList<Libro> getAllNoBorrados() {
            return lRepo.getAllNoBorrados();
        }

        public Libro getById(int codLibro) {
            return lRepo.getById(codLibro);
        }

        public Libro update(Libro libro) {
            return lRepo.update(libro);
        }
    }
}