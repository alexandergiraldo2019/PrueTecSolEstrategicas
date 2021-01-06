using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppComprimir.ViewModel
{
    public class VMConsulta
    {
        [Display(Name = "Cadena:")]
        [Required(ErrorMessage = "Debe ingresar una cadena")]
        [StringLength(30, ErrorMessage = "Longitud entre {2} y {1} caracteres", MinimumLength = 2)]
        public string CadenaInicial { get; set; }

        [Display(Name = "Cadena compresion Basica:")]
        public string CadenaComprimida { get; set; }
    }
}