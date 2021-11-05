using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionVirtual.Models.evaluaciones
{
    public class Preguntas
    {
        public int  Id { get; set; }
        [ForeignKey("Actividades")]
        [Required(ErrorMessage = "Debe darle un nombre a la actividad")]
        [DisplayName("Nombre de Actividad")]
        public int? ActividadID { get; set; }
        public Actividades Actividades { get; set; }
        [Required(ErrorMessage ="Debe ingresar una pregunta")]
        [DisplayName("Ingrese Pregunta")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage ="Debe ingresar una opcion")]
        [DisplayName("Opcion 1")]
        public string Opcion1 { get; set; }
        [Required(ErrorMessage = "Debe ingresar una opcion")]
        [DisplayName("Opcion 2")]
        public string Opcion2 { get; set; }
        [Required(ErrorMessage = "Debe ingresar una opcion")]
        [DisplayName("Opcion 3")]
        public string Opcion3 { get; set; }
        [Required(ErrorMessage = "Debe ingresar una opcion")]
        [DisplayName("Opcion 4")]
        public string Opcion4 { get; set; }
        [Required(ErrorMessage = "Debe ingresar una Solucion")]
        [DisplayName("Solucion")]
        public string Solucion { get; set; }
            
    }
}
