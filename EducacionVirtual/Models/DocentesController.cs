﻿using System;
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
    public class DocentesController : Controller
    {
        private readonly EducacionVirtualContext _context;

        public DocentesController(EducacionVirtualContext context)
        {
            _context = context;
        }

        // GET: Docentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Docentes.ToListAsync());
        }

        // GET: Docentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docentes = await _context.Docentes
                .FirstOrDefaultAsync(m => m.id == id);
            if (docentes == null)
            {
                return NotFound();
            }

            return View(docentes);
        }

        // GET: Docentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Docentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,apellido,telefono,direccion,nivel_educativo")] Docentes docentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docentes);
        }

        // GET: Docentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docentes = await _context.Docentes.FindAsync(id);
            if (docentes == null)
            {
                return NotFound();
            }
            return View(docentes);
        }

        // POST: Docentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,apellido,telefono,direccion,nivel_educativo")] Docentes docentes)
        {
            if (id != docentes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocentesExists(docentes.id))
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
            return View(docentes);
        }

        // GET: Docentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docentes = await _context.Docentes
                .FirstOrDefaultAsync(m => m.id == id);
            if (docentes == null)
            {
                return NotFound();
            }

            return View(docentes);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docentes = await _context.Docentes.FindAsync(id);
            _context.Docentes.Remove(docentes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocentesExists(int id)
        {
            return _context.Docentes.Any(e => e.id == id);
        }
    }
}
