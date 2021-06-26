using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Betriebsmittelverwaltung.Models;

namespace Betriebsmittelverwaltung
{
    public class BestandsverwaltungsController : Controller
    {
        private readonly MyContext _context;

        public BestandsverwaltungsController(MyContext context)
        {
            _context = context;
        }

        // GET: Bestandsverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bestandsverwaltung.ToListAsync());
        }

        // GET: Bestandsverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestandsverwaltung = await _context.Bestandsverwaltung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bestandsverwaltung == null)
            {
                return NotFound();
            }

            return View(bestandsverwaltung);
        }

        // GET: Bestandsverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bestandsverwaltungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,typ,Kaufdatum,Wartungsintervall")] Bestandsverwaltung bestandsverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bestandsverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bestandsverwaltung);
        }

        // GET: Bestandsverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestandsverwaltung = await _context.Bestandsverwaltung.FindAsync(id);
            if (bestandsverwaltung == null)
            {
                return NotFound();
            }
            return View(bestandsverwaltung);
        }

        // POST: Bestandsverwaltungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,typ,Kaufdatum,Wartungsintervall")] Bestandsverwaltung bestandsverwaltung)
        {
            if (id != bestandsverwaltung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bestandsverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BestandsverwaltungExists(bestandsverwaltung.Id))
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
            return View(bestandsverwaltung);
        }

        // GET: Bestandsverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestandsverwaltung = await _context.Bestandsverwaltung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bestandsverwaltung == null)
            {
                return NotFound();
            }

            return View(bestandsverwaltung);
        }

        // POST: Bestandsverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bestandsverwaltung = await _context.Bestandsverwaltung.FindAsync(id);
            _context.Bestandsverwaltung.Remove(bestandsverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BestandsverwaltungExists(int id)
        {
            return _context.Bestandsverwaltung.Any(e => e.Id == id);
        }
    }
}
