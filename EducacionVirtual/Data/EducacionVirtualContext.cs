using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EducaEnCasa.Models;
using EducacionVirtual.Models;
using EducacionVirtual.Models.evaluaciones;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EducacionVitual.ViewsModels;

namespace EducacionVirtual.Data
{
    public class EducacionVirtualContext : IdentityDbContext<ApplicationUser>
    {
        public EducacionVirtualContext (DbContextOptions<EducacionVirtualContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<EducaEnCasa.Models.Acudientes> Acudientes { get; set; }

        public DbSet<EducaEnCasa.Models.Docentes> Docentes { get; set; }

        public DbSet<EducaEnCasa.Models.Estudiantes> Estudiantes { get; set; }

        public DbSet<EducacionVirtual.Models.evaluaciones.Preguntas> Preguntas { get; set; }

        public DbSet<EducacionVirtual.Models.evaluaciones.Actividades> Actividades { get; set; }

        public DbSet<EducacionVirtual.Models.evaluaciones.Notas> Notas { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
