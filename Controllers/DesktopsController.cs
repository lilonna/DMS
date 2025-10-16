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
    public class DesktopsController : Controller
    {
        private readonly DMSContext _context;

        public DesktopsController(DMSContext context)
        {
            _context = context;
        }

        // GET: Desktops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Desktops.ToListAsync());
        }

        // GET: Desktops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desktop = await _context.Desktops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desktop == null)
            {
                return NotFound();
            }

            return View(desktop);
        }

        // GET: Desktops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desktops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SerialNumber,UserId,IssueReport,RoomId")] Desktop desktop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desktop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desktop);
        }

        // GET: Desktops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desktop = await _context.Desktops.FindAsync(id);
            if (desktop == null)
            {
                return NotFound();
            }
            return View(desktop);
        }

        // POST: Desktops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SerialNumber,UserId,IssueReport,RoomId")] Desktop desktop)
        {
            if (id != desktop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desktop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesktopExists(desktop.Id))
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
            return View(desktop);
        }

        // GET: Desktops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desktop = await _context.Desktops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desktop == null)
            {
                return NotFound();
            }

            return View(desktop);
        }

        // POST: Desktops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desktop = await _context.Desktops.FindAsync(id);
            if (desktop != null)
            {
                _context.Desktops.Remove(desktop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesktopExists(int id)
        {
            return _context.Desktops.Any(e => e.Id == id);
        }
    }
}
