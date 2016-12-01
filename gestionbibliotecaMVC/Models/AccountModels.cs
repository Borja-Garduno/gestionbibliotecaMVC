using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionbibliotecaMVC.Models {

    public class LogOnModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        private string username;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        private string password;

        [Display(Name = "Recuerdame")]
        private bool rememberme;

        public string Username {
            get {
                return username;
            }

            set {
                username = value;
            }
        }

        public string Password {
            get {
                return password;
            }

            set {
                password = value;
            }
        }

        public bool Rememberme {
            get {
                return rememberme;
            }

            set {
                rememberme = value;
            }
        }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Nombre del usuario")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos del usuario")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento del usuario")]
        public string FNacimiento { get; set; }

        [Required]
        [Display(Name = "DNI del usuario")]
        public string Dni { get; set; }

        [Required]
        [Display(Name = "Nick del usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe de tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Passwd { get; set; }

        //[NotMapped]
        //[Required(ErrorMessage = "Necesita confirmar la contraseña")]
        //[CompareAttribute("Passwd", ErrorMessage = "Las constraseñas no coinciden.")]   
        [DataType(DataType.Password)]
        [Display(Name = "Confirma contraseña")]
        [Compare("Passwd", ErrorMessage = "Las constraseñas no coinciden.")]
        public string ConfirmPasswd { get; set; }
    }
}