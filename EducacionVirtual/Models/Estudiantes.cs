using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducaEnCasa.Models
{
    public class Estudiantes
    {
        public int id { get; set; }        
        [Required(ErrorMessage ="Ingrese un nombre")]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Ingrese un apellido")]
        [DisplayName("Apellido")]
        public string apellido { get; set; }
        [DisplayName("Telefono")]
        public string telefono { get; set; }
        [DisplayName("Direccion")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "Ingrese Documento del estudiante")]
        [DisplayName("Documento")]
        public string tarjetaIdentidad { get; set; }
        [DisplayName("Edad")]
        public int edad { get; set; }
        [DisplayName("Grado")]
        public int grado { get; set; }
        [DisplayName("Acudiente")]
        public int? AcudienteID { get; set; }//requerimiento id acudiente
        public Acudientes Acudiente { get; set; }//nos trae todo el objeto acudiente
        [DisplayName("Docente Asignado")]
        public int? DocenteID { get; set; }//requerimiento id docente
        public Docentes Docente { get; set; }//trae el objeto 
        //aqui unimos nombre y apellido para mostrarlos 1 solo string
        public string NombreCompletoE
        {
            get { return nombre + " " + apellido; }
        }

    }

}
