using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bolsa_de_empleos.Models
{
    public class Configuracion
    {
        [Key]
        public int id { get; set; }
        public string idioma { get; set; }
        public int diasEmpleos { get; set; }
        public int cantidadEmpleos { get; set; }


    }
}