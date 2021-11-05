using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducacionVirtual.Data;

namespace EducacionVirtual.Models.evaluaciones
{
    public class ActividadesController : Controller
    {
        private readonly EducacionVirtualContext _context;

        public ActividadesController(EducacionVirtualContext context)
        {
            _context = context;
        }

        // GET: Actividades
        public async Task<IActionResult> Index()
        {
            var educacionVirtualContext = _context.Actividades.Include(a => a.Docente);
            return View(await educacionVirtualContext.ToListAsync());
        }

        // GET: Actividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades
                .Include(a => a.Docente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actividades == null)
            {
                return NotFound();
            }

            return View(actividades);
        }

        // GET: Actividades/Create
        public IActionResult Create()
        {
            ViewData["DocenteId"] = new SelectList(_context.Docentes, "id", "NombreCompletoD");
            return View();
        }

        // POST: Actividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoEvaluacion,NombreActividad,DocenteId")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocenteId"] = new SelectList(_context.Docentes, "id", "NombreCompletoD", actividades.DocenteId);
            return View(actividades);
        }

        // GET: Actividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades.FindAsync(id);
            if (actividades == null)
            {
                return NotFound();
            }
            ViewData["DocenteId"] = new SelectList(_context.Docentes, "id", "NombreCompletoD", actividades.DocenteId);
            return View(actividades);
        }

        // POST: Actividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoEvaluacion,NombreActividad,DocenteId")] Actividades actividades)
        {
            if (id != actividades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadesExists(actividades.Id))
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
            ViewData["DocenteId"] = new SelectList(_context.Docentes, "id", "apellido", actividades.DocenteId);
            return View(actividades);
        }

        // GET: Actividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividades
                .Include(a => a.Docente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actividades == null)
            {
                return NotFound();
            }

            return View(actividades);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividades = await _context.Actividades.FindAsync(id);
            _context.Actividades.Remove(actividades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadesExists(int id)
        {
            return _context.Actividades.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> Resolver(int? id)
        {
            var Cuestionario = await (from p in _context.Preguntas
                                      join a in _context.Actividades on p.ActividadID equals a.Id
                                      where p.ActividadID == id
                                      select new Preguntas
                                      {
                                          Id = p.Id,
                                          ActividadID = a.Id,
                                          Descripcion = p.Descripcion,
                                          Opcion1 = p.Opcion1,
                                          Opcion2 = p.Opcion2,
                                          Opcion3 = p.Opcion3,
                                          Opcion4 = p.Opcion4,
                                          Solucion = p.Solucion,
                                          Actividades = a
                                      }).ToListAsync();
            ViewBag.ListaPreguntas = Cuestionario;
            return View(ViewBag.ListaPreguntas);
        }

        [HttpPost]
        public async Task<IActionResult> Resolver(Preguntas pregunta)
        {
            await (ViewBag.mensaje = "ya paso por el post");
            return View();
        }

    }
}
