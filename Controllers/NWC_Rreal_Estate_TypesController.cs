using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GhyomAssignment.Models;

namespace GhyomAssignment.Controllers
{
    public class NWC_Rreal_Estate_TypesController : Controller
    {
        private readonly NWC_Context _context;

        public NWC_Rreal_Estate_TypesController(NWC_Context context)
        {
            _context = context;
        }

        // GET: NWC_Rreal_Estate_Types
        public async Task<IActionResult> Index()
        {
              return View(await _context.NWC_Rreal_Estate_Types.ToListAsync());
        }

        // GET: NWC_Rreal_Estate_Types/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }

            var nWC_Rreal_Estate_Types = await _context.NWC_Rreal_Estate_Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }

            return View(nWC_Rreal_Estate_Types);
        }

        // GET: NWC_Rreal_Estate_Types/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NWC_Rreal_Estate_Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NWC_Rreal_Estate_Types_Code,NWC_Rreal_Estate_Types_Name,NWC_Rreal_Estate_Types_Reasons")] NWC_Rreal_Estate_Types nWC_Rreal_Estate_Types)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nWC_Rreal_Estate_Types);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nWC_Rreal_Estate_Types);
        }

        // GET: NWC_Rreal_Estate_Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }

            var nWC_Rreal_Estate_Types = await _context.NWC_Rreal_Estate_Types.FindAsync(id);
            if (nWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }
            return View(nWC_Rreal_Estate_Types);
        }

        // POST: NWC_Rreal_Estate_Types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NWC_Rreal_Estate_Types_Code,NWC_Rreal_Estate_Types_Name,NWC_Rreal_Estate_Types_Reasons")] NWC_Rreal_Estate_Types nWC_Rreal_Estate_Types)
        {
            if (id != nWC_Rreal_Estate_Types.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nWC_Rreal_Estate_Types);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NWC_Rreal_Estate_TypesExists(nWC_Rreal_Estate_Types.Id))
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
            return View(nWC_Rreal_Estate_Types);
        }

        // GET: NWC_Rreal_Estate_Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }

            var nWC_Rreal_Estate_Types = await _context.NWC_Rreal_Estate_Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nWC_Rreal_Estate_Types == null)
            {
                return NotFound();
            }

            return View(nWC_Rreal_Estate_Types);
        }

        // POST: NWC_Rreal_Estate_Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NWC_Rreal_Estate_Types == null)
            {
                return Problem("Entity set 'NWC_Context.NWC_Rreal_Estate_Types'  is null.");
            }
            var nWC_Rreal_Estate_Types = await _context.NWC_Rreal_Estate_Types.FindAsync(id);
            if (nWC_Rreal_Estate_Types != null)
            {
                _context.NWC_Rreal_Estate_Types.Remove(nWC_Rreal_Estate_Types);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_Rreal_Estate_TypesExists(int id)
        {
          return _context.NWC_Rreal_Estate_Types.Any(e => e.Id == id);
        }
    }
}
