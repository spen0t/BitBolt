#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BitBolt.Data;
using BitBolt.Models;
using Microsoft.AspNetCore.Authorization;

namespace BitBolt.Controllers
{
    public class TermekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TermekController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Termek
        public async Task<IActionResult> Index()
        {
            return View(await _context.Termekek.ToListAsync());
        }

        //POST:Kereses
        public async Task<IActionResult> KeresesEredmeny(String KeresettSzo)
        {
            //ApplicationDbContext context = _context;
            //DbSet<BitBolt.Models.Termekek> keresetttermek = context.Kereses(KeresettSzo);
            //return View(keresetttermek);    
            return View("Index" , await _context.Termekek.Where(j => j.Megnevezés.Contains(KeresettSzo) || j.Típus.Contains(KeresettSzo)).ToListAsync());
        }

        // GET: Termek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termekek = await _context.Termekek
                .FirstOrDefaultAsync(m => m.Id == id);
            if (termekek == null)
            {
                return NotFound();
            }

            return View(termekek);
        }

        // GET: Termek/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Termek/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Megnevezés,Gyáró,Típus,BeszerzésiÁr")] Termekek termekek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(termekek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(termekek);
        }

        // GET: Termek/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termekek = await _context.Termekek.FindAsync(id);
            if (termekek == null)
            {
                return NotFound();
            }
            return View(termekek);
        }

        // POST: Termek/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,Megnevezés,Gyáró,Típus,BeszerzésiÁr")] Termekek termekek)
        {
            if (id != termekek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termekek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermekekExists(termekek.Id))
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
            return View(termekek);
        }

        // GET: Termek/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termekek = await _context.Termekek
                .FirstOrDefaultAsync(m => m.Id == id);
            if (termekek == null)
            {
                return NotFound();
            }

            return View(termekek);
        }

        // POST: Termek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var termekek = await _context.Termekek.FindAsync(id);
            _context.Termekek.Remove(termekek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermekekExists(int id)
        {
            return _context.Termekek.Any(e => e.Id == id);
        }
    }
}
