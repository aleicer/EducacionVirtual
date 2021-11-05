using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducaEnCasa.Models;
using EducacionVirtual.Data;

namespace EducacionVirtual.Models
{
    public class EstudiantesController : Controller
    {
        private readonly EducacionVirtualContext _context;

        public EstudiantesController(EducacionVirtualContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            var educacionVirtualContext = _context.Estudiantes.Include(e => e.Acudiente).Include(e => e.Docente);
            return View(await educacionVirtualContext.ToListAsync());
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .Include(e => e.Acudiente)
                .Include(e => e.Docente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewData["AcudienteID"] = new SelectList(_context.Acudientes, "id", "NombreCompletoA");
            ViewData["DocenteID"] = new SelectList(_context.Docentes, "id", "NombreCompletoD");
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,apellido,telefono,direccion,tarjetaIdentidad,edad,grado,AcudienteID,DocenteID")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcudienteID"] = new SelectList(_context.Acudientes, "id", "NombreCompletoA", estudiantes.AcudienteID);
            ViewData["DocenteID"] = new SelectList(_context.Docentes, "id", "NombreCompletoD", estudiantes.DocenteID);
            return View(estudiantes);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes == null)
            {
                return NotFound();
            }
            ViewData["AcudienteID"] = new SelectList(_context.Acudientes, "id", "NombreCompletoA", estudiantes.AcudienteID);
            ViewData["DocenteID"] = new SelectList(_context.Docentes, "id", "NombreCompletoD", estudiantes.DocenteID);
            return View(estudiantes);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,apellido,telefono,direccion,tarjetaIdentidad,edad,grado,AcudienteID,DocenteID")] Estudiantes estudiantes)
        {
            if (id != estudiantes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantesExists(estudiantes.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcudienteID"] = new SelectList(_context.Acudientes, "id", "NombreCompletoA", estudiantes.AcudienteID);
            ViewData["DocenteID"] = new SelectList(_context.Docentes, "id", "NombreCompletoD", estudiantes.DocenteID);
            return View(estudiantes);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .Include(e => e.Acudiente)
                .Include(e => e.Docente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiantes = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(estudiantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantesExists(int id)
        {
            return _context.Estudiantes.Any(e => e.id == id);
        }
    }
}
