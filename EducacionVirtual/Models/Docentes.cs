using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducaEnCasa.Models
{
    public class Docentes
    {
        public int id { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage ="Ingrese el nombre")]
        public string nombre { get; set; }
        [DisplayName("Apellido")]
        [Required(ErrorMessage = "Ingrese el apellido")]
        public string apellido { get; set; }
        [DisplayName("Telefono")]
        [Required(ErrorMessage = "Ingrese el telefono")]
        public string telefono { get; set; }
        [DisplayName("Direccion")]
        public string direccion { get; set; }
        [DisplayName("Nivel Educativo")]
        public string nivel_educativo { get; set; }
        public string NombreCompletoD
        {
            get { return nombre + " " + apellido; }
        }
    }
}
