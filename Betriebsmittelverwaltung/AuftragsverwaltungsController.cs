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
    public class AuftragsverwaltungsController : Controller
    {
        private readonly MyContext _context;

        public AuftragsverwaltungsController(MyContext context)
        {
            _context = context;
        }

        // GET: Auftragsverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auftragsverwaltung.ToListAsync());
        }

        // GET: Auftragsverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftragsverwaltung = await _context.Auftragsverwaltung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auftragsverwaltung == null)
            {
                return NotFound();
            }

            return View(auftragsverwaltung);
        }

        // GET: Auftragsverwaltungs/Create
        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Auftragsverwaltungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Typ,BaustellenID")] Auftragsverwaltung auftragsverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auftragsverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auftragsverwaltung);
        }

        // GET: Auftragsverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftragsverwaltung = await _context.Auftragsverwaltung.FindAsync(id);
            if (auftragsverwaltung == null)
            {
                return NotFound();
            }
            return View(auftragsverwaltung);
        }

        // POST: Auftragsverwaltungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Typ,BaustellenID")] Auftragsverwaltung auftragsverwaltung)
        {
            if (id != auftragsverwaltung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auftragsverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuftragsverwaltungExists(auftragsverwaltung.Id))
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
            return View(auftragsverwaltung);
        }

        // GET: Auftragsverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftragsverwaltung = await _context.Auftragsverwaltung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auftragsverwaltung == null)
            {
                return NotFound();
            }

            return View(auftragsverwaltung);
        }

        // POST: Auftragsverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auftragsverwaltung = await _context.Auftragsverwaltung.FindAsync(id);
            _context.Auftragsverwaltung.Remove(auftragsverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuftragsverwaltungExists(int id)
        {
            return _context.Auftragsverwaltung.Any(e => e.Id == id);
        }
    }
}
