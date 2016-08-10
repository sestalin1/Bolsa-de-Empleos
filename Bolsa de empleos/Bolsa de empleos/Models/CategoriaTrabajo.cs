using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bolsa_de_empleos.Models
{
    [Table(name: "CategoriasTrabajo")]
    public class CategoriaTrabajo
    {

        [Key]
        public string Nombre { get; set; }
       
        public string Descripcion { get; set; }

        public ICollection<Vacante> vacantes { get; set; }
    }
}