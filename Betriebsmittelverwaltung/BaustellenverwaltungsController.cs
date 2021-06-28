using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Betriebsmittelverwaltung.Models;
using Microsoft.AspNetCore.Authorization;

namespace Betriebsmittelverwaltung
{
    public class BaustellenverwaltungsController : Controller
    {
        private readonly MyContext _context;

        public BaustellenverwaltungsController(MyContext context)
        {
            _context = context;
        }
        [Authorize] //Rolle implementieren
        // GET: Baustellenverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Baustellenverwaltung.ToListAsync());
        }

        // GET: Baustellenverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baustellenID = id;

            var baustellenverwaltung = await _context.Baustellenverwaltung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baustellenverwaltung == null)
            {
                return NotFound();
            }

            return View(baustellenverwaltung);
        }

        // GET: Baustellenverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baustellenverwaltungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,kurzname,beschreibung")] Baustellenverwaltung baustellenverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baustellenverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baustellenverwaltung);
        }

        // GET: Baustellenverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baustellenverwaltung = await _context.Baustellenverwaltung.FindAsync(id);
            if (baustellenverwaltung == null)
            {
                return NotFound();
            }
            return View(baustellenverwaltung);
        }

        // POST: Baustellenverwaltungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,kurzname,beschreibung")] Baustellenverwaltung baustellenverwaltung)
        {
            if (id != baustellenverwaltung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baustellenverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaustellenverwaltungExists(baustellenverwaltung.Id))
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
            return View(baustellenverwaltung);
        }

        // GET: Baustellenverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baustellenverwaltung = await _context.Baustellenverwaltung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baustellenverwaltung == null)
            {
                return NotFound();
            }

            return View(baustellenverwaltung);
        }

        // POST: Baustellenverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baustellenverwaltung = await _context.Baustellenverwaltung.FindAsync(id);
            _context.Baustellenverwaltung.Remove(baustellenverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaustellenverwaltungExists(int id)
        {
            return _context.Baustellenverwaltung.Any(e => e.Id == id);
        }
    }
}
