using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bolsa_de_empleos.Models
{
    [Table(name: "Vacantes")]
    public class Vacante
    {
        [Key]
        public int id { get; set; }

        [Display(Name="Titulo")]
        public string titulo { get; set; }

        [ForeignKey("categoriaTrabajo")]
        public string categoriaID { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public bool estatus { get; set; }
        public string ubicacion { get; set; }
        public string posicion { get; set; }
        public string empresa { get; set; }
        public string tipoTrabajo { get; set; }
        public string logo { get; set; }
        public string descripcion { get; set; }
        public string comoAplicar { get; set; }
        public bool accesibilidad { get; set; }//Publico?

        
        public CategoriaTrabajo categoriaTrabajo { get; set; }

    }
}