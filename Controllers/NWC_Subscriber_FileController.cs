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
    public class NWC_Subscriber_FileController : Controller
    {
        private readonly NWC_Context _context;

        public NWC_Subscriber_FileController(NWC_Context context)
        {
            _context = context;
        }

        // GET: NWC_Subscriber_File
        public async Task<IActionResult> Index()
        {
              return View(await _context.NWC_Subscriber_Files.ToListAsync());
        }

        //Report
        // GET: NWC_Subscriber_File
        public async Task<IActionResult> Report()
        {
            return View(await _context.NWC_Subscriber_Files.ToListAsync());
        }

        // GET: NWC_Subscriber_File/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NWC_Subscriber_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscriber_File = await _context.NWC_Subscriber_Files
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nWC_Subscriber_File == null)
            {
                return NotFound();
            }

            return View(nWC_Subscriber_File);
        }

        // GET: NWC_Subscriber_File/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NWC_Subscriber_File/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NWC_Subscriber_File_Id,NWC_Subscriber_File_Name,NWC_Subscriber_File_City,NWC_Subscriber_File_Area,NWC_Subscriber_File_Mobile,NWC_Subscriber_File_Reasons")] NWC_Subscriber_File nWC_Subscriber_File)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nWC_Subscriber_File);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nWC_Subscriber_File);
        }

        // GET: NWC_Subscriber_File/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NWC_Subscriber_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscriber_File = await _context.NWC_Subscriber_Files.FindAsync(id);
            if (nWC_Subscriber_File == null)
            {
                return NotFound();
            }
            return View(nWC_Subscriber_File);
        }

        // POST: NWC_Subscriber_File/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NWC_Subscriber_File_Id,NWC_Subscriber_File_Name,NWC_Subscriber_File_City,NWC_Subscriber_File_Area,NWC_Subscriber_File_Mobile,NWC_Subscriber_File_Reasons")] NWC_Subscriber_File nWC_Subscriber_File)
        {
            if (id != nWC_Subscriber_File.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nWC_Subscriber_File);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NWC_Subscriber_FileExists(nWC_Subscriber_File.Id))
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
            return View(nWC_Subscriber_File);
        }

        // GET: NWC_Subscriber_File/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NWC_Subscriber_Files == null)
            {
                return NotFound();
            }

            var nWC_Subscriber_File = await _context.NWC_Subscriber_Files
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nWC_Subscriber_File == null)
            {
                return NotFound();
            }

            return View(nWC_Subscriber_File);
        }

        // POST: NWC_Subscriber_File/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NWC_Subscriber_Files == null)
            {
                return Problem("Entity set 'NWC_Context.NWC_Subscriber_Files'  is null.");
            }
            var nWC_Subscriber_File = await _context.NWC_Subscriber_Files.FindAsync(id);
            if (nWC_Subscriber_File != null)
            {
                _context.NWC_Subscriber_Files.Remove(nWC_Subscriber_File);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_Subscriber_FileExists(int id)
        {
          return _context.NWC_Subscriber_Files.Any(e => e.Id == id);
        }
    }
}
