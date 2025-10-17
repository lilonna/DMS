using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMS.Models;

namespace DMS.Controllers
{
    public class DesktopNamesController : Controller
    {
        private readonly DMSContext _context;

        public DesktopNamesController(DMSContext context)
        {
            _context = context;
        }

        // GET: DesktopNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.DesktopNames.ToListAsync());
        }

        // GET: DesktopNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desktopName = await _context.DesktopNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desktopName == null)
            {
                return NotFound();
            }

            return View(desktopName);
        }

        // GET: DesktopNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DesktopNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DesktopName desktopName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desktopName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desktopName);
        }

        // GET: DesktopNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desktopName = await _context.DesktopNames.FindAsync(id);
            if (desktopName == null)
            {
                return NotFound();
            }
            return View(desktopName);
        }

        // POST: DesktopNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DesktopName desktopName)
        {
            if (id != desktopName.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desktopName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesktopNameExists(desktopName.Id))
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
            return View(desktopName);
        }

        // GET: DesktopNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desktopName = await _context.DesktopNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desktopName == null)
            {
                return NotFound();
            }

            return View(desktopName);
        }

        // POST: DesktopNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desktopName = await _context.DesktopNames.FindAsync(id);
            if (desktopName != null)
            {
                _context.DesktopNames.Remove(desktopName);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesktopNameExists(int id)
        {
            return _context.DesktopNames.Any(e => e.Id == id);
        }
    }
}
