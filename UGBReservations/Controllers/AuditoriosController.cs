﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProjetor.Models;

namespace MvcResource.Controllers
{
    public class AuditoriosController : Controller
    {
        private readonly MvcProjetorContext _context;

        public AuditoriosController(MvcProjetorContext context)
        {
            _context = context;
        }

        // GET: Auditorios
        public async Task<IActionResult> Index(string auditorioCampus, string searchString)
        {
            // Use LINQ to get list of campi.
            IQueryable<string> campusQuery = from m in _context.Auditorio
                                             orderby m.Campus
                                             select m.Campus;

            var auditorios = from m in _context.Auditorio
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                auditorios = auditorios.Where(s => s.Nome == (searchString));
            }

            if (!String.IsNullOrEmpty(auditorioCampus))
            {
                auditorios = auditorios.Where(x => x.Campus == auditorioCampus);
            }

            var auditorioCampusVM = new AuditorioCampusViewModel();
            auditorioCampusVM.campi = new SelectList(await campusQuery.Distinct().ToListAsync());
            auditorioCampusVM.auditorios = await auditorios.ToListAsync();

            return View(auditorioCampusVM);
        }

        // GET: Auditorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditorio = await _context.Auditorio
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auditorio == null)
            {
                return NotFound();
            }

            return View(auditorio);
        }

        // GET: Auditorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auditorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Campus,Bloco")] Auditorio auditorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auditorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auditorio);
        }

        // GET: Auditorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditorio = await _context.Auditorio.FindAsync(id);
            if (auditorio == null)
            {
                return NotFound();
            }
            return View(auditorio);
        }

        // POST: Auditorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Campus,Bloco")] Auditorio auditorio)
        {
            if (id != auditorio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditorioExists(auditorio.ID))
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
            return View(auditorio);
        }

        // GET: Auditorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditorio = await _context.Auditorio
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auditorio == null)
            {
                return NotFound();
            }

            return View(auditorio);
        }

        // POST: Auditorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auditorio = await _context.Auditorio.FindAsync(id);
            _context.Auditorio.Remove(auditorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditorioExists(int id)
        {
            return _context.Auditorio.Any(e => e.ID == id);
        }
    }
}
