using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EducaEnCasa.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EducacionVirtual.Models.evaluaciones
{
    public class Actividades
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Seleccione el tipo de Actividad")]
        [DisplayName("Tipo De Actividad")]
        public string TipoEvaluacion { get; set; }
        [Required(ErrorMessage ="Agregale un nombre a la actividad")]
        [DisplayName("Nombre de Actividad")]
        public string NombreActividad { get; set; }
        [DisplayName("Docente a cargo")]
        [ForeignKey("Docente")]
        public  int? DocenteId { get; set; }
        public Docentes Docente { get; set; }
        public string DetalleActividad
        {
            get { return TipoEvaluacion + " - " + NombreActividad; }
        }
    }
    
}
