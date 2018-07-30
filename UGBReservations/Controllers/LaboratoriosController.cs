using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProjetor.Models;

namespace UGBReservations
{
    public class LaboratoriosController : Controller
    {
        private readonly MvcProjetorContext _context;

        public LaboratoriosController(MvcProjetorContext context)
        {
            _context = context;
        }

        // GET: Laboratorios
        public async Task<IActionResult> Index(string laboratorioCampus, string searchString)
        {
            // Use LINQ to get list of campi.
            IQueryable<string> campusQuery = from m in _context.Laboratorio
                                             orderby m.Campus
                                             select m.Campus;

            var laboratorios = from m in _context.Laboratorio
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                laboratorios = laboratorios.Where(s => s.Nome == (searchString));
            }

            if (!String.IsNullOrEmpty(laboratorioCampus))
            {
                laboratorios = laboratorios.Where(x => x.Campus == laboratorioCampus);
            }

            var laboratorioCampusVM = new LaboratorioCampusViewModel();
            laboratorioCampusVM.campi = new SelectList(await campusQuery.Distinct().ToListAsync());
            laboratorioCampusVM.laboratorios = await laboratorios.ToListAsync();

            return View(laboratorioCampusVM);
        }

        // GET: Laboratorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorio
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return View(laboratorio);
        }

        // GET: Laboratorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laboratorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Campus,Tipo")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laboratorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laboratorio);
        }

        // GET: Laboratorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorio.FindAsync(id);
            if (laboratorio == null)
            {
                return NotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Campus,Tipo")] Laboratorio laboratorio)
        {
            if (id != laboratorio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratorioExists(laboratorio.ID))
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
            return View(laboratorio);
        }

        // GET: Laboratorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorio
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return View(laboratorio);
        }

        // POST: Laboratorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laboratorio = await _context.Laboratorio.FindAsync(id);
            _context.Laboratorio.Remove(laboratorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratorioExists(int id)
        {
            return _context.Laboratorio.Any(e => e.ID == id);
        }
    }
}
