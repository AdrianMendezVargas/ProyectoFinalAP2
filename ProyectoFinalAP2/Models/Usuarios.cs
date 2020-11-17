using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAP2.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "El Nombre es muy corto, favor introduzca de nuevo.")]
        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }
          [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "El apellido es muy corto")]
        [Required(ErrorMessage = "Es obligatorio introducir el apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Introduzca una direccion valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir su nombre de usuario")]
        public string NombreUsuario { get; set; }



    }
}
