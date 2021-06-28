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
    public class RetourenverwaltungsController : Controller
    {
        private readonly MyContext _context;

        public RetourenverwaltungsController(MyContext context)
        {
            _context = context;
        }

        // GET: Retourenverwaltungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Retourenverwaltung.ToListAsync());
        }

        // GET: Retourenverwaltungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retourenverwaltung = await _context.Retourenverwaltung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retourenverwaltung == null)
            {
                return NotFound();
            }

            return View(retourenverwaltung);
        }

        // GET: Retourenverwaltungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retourenverwaltungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Typ,BaustellenID,TypId")] Retourenverwaltung retourenverwaltung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retourenverwaltung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retourenverwaltung);
        }

        // GET: Retourenverwaltungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retourenverwaltung = await _context.Retourenverwaltung.FindAsync(id);
            if (retourenverwaltung == null)
            {
                return NotFound();
            }
            return View(retourenverwaltung);
        }

        // POST: Retourenverwaltungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Typ,BaustellenID,TypId")] Retourenverwaltung retourenverwaltung)
        {
            if (id != retourenverwaltung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retourenverwaltung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetourenverwaltungExists(retourenverwaltung.Id))
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
            return View(retourenverwaltung);
        }

        // GET: Retourenverwaltungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retourenverwaltung = await _context.Retourenverwaltung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retourenverwaltung == null)
            {
                return NotFound();
            }

            return View(retourenverwaltung);
        }

        // POST: Retourenverwaltungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retourenverwaltung = await _context.Retourenverwaltung.FindAsync(id);
            _context.Retourenverwaltung.Remove(retourenverwaltung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetourenverwaltungExists(int id)
        {
            return _context.Retourenverwaltung.Any(e => e.Id == id);
        }
    }
}
