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
    public class NWC_Default_Slice_ValuesController : Controller
    {
        private readonly NWC_Context _context;

        public NWC_Default_Slice_ValuesController(NWC_Context context)
        {
            _context = context;
        }

        // GET: NWC_Default_Slice_Values
        public async Task<IActionResult> Index()
        {
              return View(await _context.NWC_Default_Slice_Values.ToListAsync());
        }

        // GET: NWC_Default_Slice_Values/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NWC_Default_Slice_Values == null)
            {
                return NotFound();
            }

            var nWC_Default_Slice_Values = await _context.NWC_Default_Slice_Values
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nWC_Default_Slice_Values == null)
            {
                return NotFound();
            }

            return View(nWC_Default_Slice_Values);
        }

        // GET: NWC_Default_Slice_Values/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NWC_Default_Slice_Values/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NWC_Default_Slice_Values_Code,NWC_Default_Slice_Values_Name,NWC_Default_Slice_Values_Condtion,NWC_Default_Slice_Values_Water_Price,NWC_Default_Slice_Values_Sanitation_Price,NWC_Default_Slice_Values_Reasons")] NWC_Default_Slice_Values nWC_Default_Slice_Values)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nWC_Default_Slice_Values);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nWC_Default_Slice_Values);
        }

        // GET: NWC_Default_Slice_Values/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NWC_Default_Slice_Values == null)
            {
                return NotFound();
            }

            var nWC_Default_Slice_Values = await _context.NWC_Default_Slice_Values.FindAsync(id);
            if (nWC_Default_Slice_Values == null)
            {
                return NotFound();
            }
            return View(nWC_Default_Slice_Values);
        }

        // POST: NWC_Default_Slice_Values/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NWC_Default_Slice_Values_Code,NWC_Default_Slice_Values_Name,NWC_Default_Slice_Values_Condtion,NWC_Default_Slice_Values_Water_Price,NWC_Default_Slice_Values_Sanitation_Price,NWC_Default_Slice_Values_Reasons")] NWC_Default_Slice_Values nWC_Default_Slice_Values)
        {
            if (id != nWC_Default_Slice_Values.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nWC_Default_Slice_Values);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NWC_Default_Slice_ValuesExists(nWC_Default_Slice_Values.Id))
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
            return View(nWC_Default_Slice_Values);
        }

        // GET: NWC_Default_Slice_Values/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NWC_Default_Slice_Values == null)
            {
                return NotFound();
            }

            var nWC_Default_Slice_Values = await _context.NWC_Default_Slice_Values
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nWC_Default_Slice_Values == null)
            {
                return NotFound();
            }

            return View(nWC_Default_Slice_Values);
        }

        // POST: NWC_Default_Slice_Values/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NWC_Default_Slice_Values == null)
            {
                return Problem("Entity set 'NWC_Context.NWC_Default_Slice_Values'  is null.");
            }
            var nWC_Default_Slice_Values = await _context.NWC_Default_Slice_Values.FindAsync(id);
            if (nWC_Default_Slice_Values != null)
            {
                _context.NWC_Default_Slice_Values.Remove(nWC_Default_Slice_Values);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_Default_Slice_ValuesExists(int id)
        {
          return _context.NWC_Default_Slice_Values.Any(e => e.Id == id);
        }
    }
}
