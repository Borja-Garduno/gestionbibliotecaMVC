using gestionbibliotecaMVC.BBLL.interfaces;
using System.Collections.Generic;
using gestionbibliotecaMVC.Models;
using gestionbibliotecaMVC.DAL.interfaces;
using gestionbibliotecaMVC.DAL;
using System;

namespace gestionbibliotecaMVC.BBLL {
    public class PrestamoServiceImp : PrestamoService {

        private PrestamoRepository pRepo = new PrestamoRepositoryImp();
        public Prestamo create(Prestamo prestamo) {
            return pRepo.create(prestamo);
        }

        public void delete(int codPrestamo) {
            pRepo.delete(codPrestamo);
        }

        public IList<Prestamo> getAll() {
            return pRepo.getAll();
        }

        public IList<Prestamo> getAllPrestamosByUsuario(int codUsuario) {
            return pRepo.getAllPrestamosByUsuario(codUsuario);
        }

        public IList<Prestamo> getByEjemplarPrestamo(int codEjemplar) {
            return pRepo.getByEjemplarPrestamo(codEjemplar);
        }

        public Prestamo getById(int codPrestamo) {
            return pRepo.getById(codPrestamo);
        }

        public Prestamo update(Prestamo prestamo) {
            return pRepo.update(prestamo);
        }
    }
}