using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAP2.Models {
    public class Credencial {

        [Required(ErrorMessage = "Ingrese su usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string Contraseña { get; set; }
    }
}
