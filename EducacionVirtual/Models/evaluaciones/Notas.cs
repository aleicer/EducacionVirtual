using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EducaEnCasa.Models;

namespace EducacionVirtual.Models.evaluaciones
{
    public class Notas
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Fecha de Presentacion")]
        public DateTime FechaPresentacion { get; set; }
        [ForeignKey("Estudiantes")]
        [Display(Name = "Estudiante")]
        public int? EstudianteID { get; set; }
        public Estudiantes Estudiantes { get; set; }
        [ForeignKey("Docentes")]
        [Display(Name = "Docente Asignado")]
        public int? DocenteID { get; set; }
        public Docentes Docentes { get; set; }
        [ForeignKey("Actividades")]
        [Display(Name = "Actividad Realizada")]
        public int? TipoActividadID { get; set; }
        public Actividades Actividades { get; set; }
        [Display(Name ="Nota")]
        public double Nota { get; set; }
    }
}
