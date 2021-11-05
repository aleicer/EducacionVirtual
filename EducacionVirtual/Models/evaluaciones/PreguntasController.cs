using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducaEnCasa.Models;
using EducacionVirtual.Data;
using EducacionVirtual.Models.evaluaciones;

namespace EducacionVirtual.Models.evaluaciones
{
    public class PreguntasController : Controller
    {
        private readonly EducacionVirtualContext _context;

        public PreguntasController(EducacionVirtualContext context)
        {
            _context = context;
        }

        // GET: Preguntas
        public async Task<IActionResult> Index()
        {
            var educacionVirtualContext = _context.Preguntas.Include(e => e.Actividades);
            ViewData["Actividad"] = new SelectList(_context.Actividades, "Id", "DetalleActividad");
            return View(await educacionVirtualContext.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas = await _context.Preguntas
                .Include(e => e.Actividades)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preguntas == null)
            {
                return NotFound();
            }

            return View(preguntas);
        }

        // GET: Preguntas/Create
        public IActionResult Create()
        {
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "Id", "DetalleActividad");
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActividadID,Descripcion,Opcion1,Opcion2,Opcion3,Opcion4,Solucion")] Preguntas preguntas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preguntas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "Id", "DetalleActividad", preguntas.ActividadID);
            return View(preguntas);
        }

        // GET: Preguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas = await _context.Preguntas.FindAsync(id);
            if (preguntas == null)
            {
                return NotFound();
            }
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "Id", "DetalleActividad", preguntas.ActividadID);
            return View(preguntas);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActividadID,Descripcion,Opcion1,Opcion2,Opcion3,Opcion4,Solucion")] Preguntas preguntas)
        {
            if (id != preguntas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preguntas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntasExists(preguntas.Id))
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
            ViewData["ActividadesID"] = new SelectList(_context.Actividades, "Id", "DetalleActividad", preguntas.ActividadID);
            return View(preguntas);
        }

        // GET: Preguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas = await _context.Preguntas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preguntas == null)
            {
                return NotFound();
            }

            return View(preguntas);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preguntas = await _context.Preguntas.FindAsync(id);
            _context.Preguntas.Remove(preguntas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreguntasExists(int id)
        {
            return _context.Preguntas.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Resolver(int actividadID)
        {
            var Cuestionario = await(from p in _context.Preguntas
                                join a in _context.Actividades on p.ActividadID equals a.Id
                                where p.ActividadID == actividadID
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
            return View();
        }
    }
}
