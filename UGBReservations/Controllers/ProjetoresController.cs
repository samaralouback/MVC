using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MvcProjetor.Models
{
    public class ProjetoresController : Controller
    {
        private readonly MvcProjetorContext _context;

        public ProjetoresController(MvcProjetorContext context)
        {
            _context = context;
        }

        // GET: Projetores
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string projetorCampus, string searchString)
        {
            // Use LINQ to get list of campi.
            IQueryable<string> campusQuery = from m in _context.Projetor
                                            orderby m.Campus
                                            select m.Campus;

            var projetores = from m in _context.Projetor
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                projetores = projetores.Where(s => s.Numero == Int32.Parse(searchString));
            }

            if (!String.IsNullOrEmpty(projetorCampus))
            {
                projetores = projetores.Where(x => x.Campus == projetorCampus);
            }

            var projetorCampusVM = new ProjetorCampusViewModel();
            projetorCampusVM.campi = new SelectList(await campusQuery.Distinct().ToListAsync());
            projetorCampusVM.projetores = await projetores.ToListAsync();

            return View(projetorCampusVM);
        }

        // GET: Projetores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetor = await _context.Projetor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projetor == null)
            {
                return NotFound();
            }

            return View(projetor);
        }

        // GET: Projetores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projetores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Campus,PossuiComputador")] Projetor projetor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projetor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projetor);
        }

        // GET: Projetores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetor = await _context.Projetor.FindAsync(id);
            if (projetor == null)
            {
                return NotFound();
            }
            return View(projetor);
        }

        // POST: Projetores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, Numero, Campus, PossuiComputador")] Projetor projetor)
        {
            if (id != projetor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projetor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetorExists(projetor.ID))
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
            return View(projetor);
        }

        // GET: Projetores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetor = await _context.Projetor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projetor == null)
            {
                return NotFound();
            }

            return View(projetor);
        }

        // POST: Projetores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projetor = await _context.Projetor.FindAsync(id);
            _context.Projetor.Remove(projetor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetorExists(int id)
        {
            return _context.Projetor.Any(e => e.ID == id);
        }
    }
}
