using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concesionario.Models
{
    public partial class Vehiculo
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [Required]
        [DisplayName("Matrícula")]
        public string matricula { get; set; }

        [Required]
        [DisplayName("Marca")]
        public string marca { get; set; }

        [Required]
        [DisplayName("Modelo")]
        public string modelo { get; set; }

        [Required]
        [DisplayName("Coste")]
        public decimal coste { get; set; }

        [Required]
        [DisplayName("Tipo")]
        public int tipo { get; set; }
    }
}