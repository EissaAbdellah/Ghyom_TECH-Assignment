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
    public class NWC_InvoicesController : Controller
    {
        private readonly NWC_Context _context;

        public NWC_InvoicesController(NWC_Context context)
        {
            _context = context;
        }

        // GET: NWC_Invoices
        public async Task<IActionResult> Index()
        {
            var nWC_Context = _context.NWC_Invoices.Include(n => n.NWC_Rreal_Estate_Types).Include(n => n.NWC_Subscriber_File).Include(n => n.NWC_Subscription_File);
            return View(await nWC_Context.ToListAsync());
        }


        // GET: NWC_Invoices
        public async Task<IActionResult> Report()
        {
            var nWC_Context = _context.NWC_Invoices.Include(n => n.NWC_Rreal_Estate_Types).Include(n => n.NWC_Subscriber_File).Include(n => n.NWC_Subscription_File);
            return View(await nWC_Context.ToListAsync());
        }

        // GET: NWC_Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NWC_Invoices == null)
            {
                return NotFound();
            }

            var nWC_Invoices = await _context.NWC_Invoices
                .Include(n => n.NWC_Rreal_Estate_Types)
                .Include(n => n.NWC_Subscriber_File)
                .Include(n => n.NWC_Subscription_File)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nWC_Invoices == null)
            {
                return NotFound();
            }

            return View(nWC_Invoices);
        }

        // GET: NWC_Invoices/Create
        public IActionResult Create(int id)
        {

              var NWC_Subscription = 
                _context.NWC_Subscription_Files
                .Include(r=>r.NWC_Subscriber_File)
                .FirstOrDefault(d => d.NWC_Subscription_File_Subscriber_Code == id);

            ViewData["NWC_Invoices_Rreal_Estate_Types_No"] = NWC_Subscription.NWC_Subscription_File_Rreal_Estate_Types_Code;

            ViewData["NWC_Invoices_Subscriber_No"] = NWC_Subscription.NWC_Subscription_File_Subscriber_Code;

            ViewData["NWC_Invoices_Subscription_No"] = NWC_Subscription.Id;

            ViewData["NWC_Last_Reading"] = NWC_Subscription.NWC_Subscription_File_Last_Reading_Meter;

            ViewData["NWC_Number_Of_Units"] = NWC_Subscription.NWC_Subscription_File_Unit_No;

            ViewData["NWC_Is_There_Sanitation"] = NWC_Subscription.NWC_Subscription_File_Is_There_Sanitation;

            ViewData["NWC_Invoices_Subscriber_Name"] = NWC_Subscription.NWC_Subscriber_File.NWC_Subscriber_File_Name;
            ViewData["NWC_Invoices_Subscriber_ID"] = NWC_Subscription.NWC_Subscriber_File.NWC_Subscriber_File_Id;




            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NWC_Invoices nWC_Invoices)
        {
          
            if (ModelState.IsValid)
            {
                nWC_Invoices.Id = 0;
                var subNumber = nWC_Invoices.NWC_Invoices_Subscriber_No;

                var subscirbption= _context.NWC_Subscription_Files.FirstOrDefault(d => d.NWC_Subscription_File_Subscriber_Code == subNumber);

                var NumberOFUnits = subscirbption.NWC_Subscription_File_Unit_No;


                decimal amountConsumed =
                    nWC_Invoices.NWC_Invoices_Current_Consumption_Amount - subscirbption.NWC_Subscription_File_Last_Reading_Meter;

                nWC_Invoices.NWC_Invoices_Amount_Consumption = (int)amountConsumed;
                decimal price = 0;

                decimal wasterWaterPrice = 0;
                decimal totalPriceValue = 0;
                decimal services = nWC_Invoices.NWC_Invoices_Service_Fee;
                decimal taxValue = nWC_Invoices.NWC_Invoices_Tax_Rate;
                decimal Tax = 0;
                decimal total = 0;

                if (NumberOFUnits <= 2)
                {


                    var Slices =
                        _context.NWC_Default_Slice_Values
                        .Where(d => d.NWC_Default_Slice_Values_Code == "1").ToList();


                    if (amountConsumed < 16)
                    {
                        price += amountConsumed * Slices[0].NWC_Default_Slice_Values_Water_Price;
                    }

                    if (amountConsumed >= 16 & amountConsumed <= 30)
                    {
                        price += 15 * Slices[0].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += amountConsumed * Slices[1].NWC_Default_Slice_Values_Water_Price;
                        

                    }

                    if (amountConsumed >=31 && amountConsumed <= 45)
                    {
                        price += 15 * Slices[0].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += 15 * Slices[1].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += amountConsumed * Slices[2].NWC_Default_Slice_Values_Water_Price;

                    }

                    if (amountConsumed >= 46 && amountConsumed <= 60)
                    {
                        price += 15 * Slices[0].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += 15 * Slices[1].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += 15 * Slices[2].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += amountConsumed * Slices[3].NWC_Default_Slice_Values_Water_Price;


                    }

                    if (amountConsumed > 60)
                    {

                        price += 15 * Slices[0].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += 15 * Slices[1].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += 15 * Slices[2].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += 15 * Slices[3].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 15;

                        price += amountConsumed * Slices[4].NWC_Default_Slice_Values_Water_Price;


                    }

                    wasterWaterPrice = (price / 2);

                    totalPriceValue = (price + wasterWaterPrice + services);

                    Tax = (totalPriceValue / 100) * taxValue;

                    total = totalPriceValue + Tax;


                    nWC_Invoices.NWC_Invoices_Tax_Value = Tax;
                    nWC_Invoices.NWC_Invoices_Total_Invoice = totalPriceValue;
                    nWC_Invoices.NWC_Invoices_Total_Bill = total;


                }

                if (NumberOFUnits > 2)
                {
                    var Slices =
                     _context.NWC_Default_Slice_Values
                     .Where(d => d.NWC_Default_Slice_Values_Code == "3").ToList();



                    if (amountConsumed < 46)
                    {
                        price += amountConsumed * Slices[0].NWC_Default_Slice_Values_Water_Price;
                    }

                    if (amountConsumed >= 46 & amountConsumed <= 90)
                    {
                        price += 15 * Slices[0].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += amountConsumed * Slices[1].NWC_Default_Slice_Values_Water_Price;


                    }

                    if (amountConsumed >= 91 && amountConsumed <= 135)
                    {
                        price += 45 * Slices[0].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += 45 * Slices[1].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += amountConsumed * Slices[2].NWC_Default_Slice_Values_Water_Price;

                    }

                    if (amountConsumed >= 136 && amountConsumed <= 180)
                    {
                        price += 15 * Slices[0].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += 15 * Slices[1].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += 15 * Slices[2].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += amountConsumed * Slices[3].NWC_Default_Slice_Values_Water_Price;


                    }

                    if (amountConsumed > 180)
                    {

                        price += 15 * Slices[0].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += 15 * Slices[1].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += 15 * Slices[2].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += 15 * Slices[3].NWC_Default_Slice_Values_Water_Price;
                        amountConsumed -= 45;

                        price += amountConsumed * Slices[4].NWC_Default_Slice_Values_Water_Price;


                    }

                    wasterWaterPrice = (price / 2);

                    totalPriceValue = (price + wasterWaterPrice + services);

                    Tax = (totalPriceValue / 100) * taxValue;

                    total = totalPriceValue + Tax;


                    nWC_Invoices.NWC_Invoices_Tax_Value = Tax;
                    nWC_Invoices.NWC_Invoices_Total_Invoice = totalPriceValue;
                    nWC_Invoices.NWC_Invoices_Total_Bill = total;




                }



                _context.Add(nWC_Invoices);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

           // ViewData["NWC_Invoices_Rreal_Estate_Types_No"] = new SelectList(_context.NWC_Rreal_Estate_Types, "Id", "NWC_Rreal_Estate_Types_Code", nWC_Invoices.NWC_Invoices_Rreal_Estate_Types_No);
            //ViewData["NWC_Invoices_Subscriber_No"] = new SelectList(_context.NWC_Subscriber_Files, "Id", "NWC_Subscriber_File_Area", nWC_Invoices.NWC_Invoices_Subscriber_No);
            //ViewData["NWC_Invoices_Subscription_No"] = new SelectList(_context.NWC_Subscription_Files, "Id", "Id", nWC_Invoices.NWC_Invoices_Subscription_No);
            return View(nWC_Invoices);
        }

        // GET: NWC_Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NWC_Invoices == null)
            {
                return NotFound();
            }

            var nWC_Invoices = await _context.NWC_Invoices.FindAsync(id);
            if (nWC_Invoices == null)
            {
                return NotFound();
            }
            ViewData["NWC_Invoices_Rreal_Estate_Types_No"] = new SelectList(_context.NWC_Rreal_Estate_Types, "Id", "NWC_Rreal_Estate_Types_Code", nWC_Invoices.NWC_Invoices_Rreal_Estate_Types_No);
            ViewData["NWC_Invoices_Subscriber_No"] = new SelectList(_context.NWC_Subscriber_Files, "Id", "NWC_Subscriber_File_Area", nWC_Invoices.NWC_Invoices_Subscriber_No);
            ViewData["NWC_Invoices_Subscription_No"] = new SelectList(_context.NWC_Subscription_Files, "Id", "Id", nWC_Invoices.NWC_Invoices_Subscription_No);
            return View(nWC_Invoices);
        }

        // POST: NWC_Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NWC_Invoices_No,NWC_Invoices_Year,NWC_Invoices_Date,NWC_Invoices_From,NWC_Invoices_To,NWC_Invoices_Previous_Consumption_Amount,NWC_Invoices_Current_Consumption_Amount,NWC_Invoices_Amount_Consumption,NWC_Invoices_Service_Fee,NWC_Invoices_Tax_Rate,NWC_Invoices_Is_There_Sanitation,NWC_Invoices_Wastewater_Consumption_Value,NWC_Invoices_Total_Invoice,NWC_Invoices_Tax_Value,NWC_Invoices_Total_Bill,NWC_Invoices_Total_Reasons,NWC_Invoices_Rreal_Estate_Types_No,NWC_Invoices_Subscription_No,NWC_Invoices_Subscriber_No")] NWC_Invoices nWC_Invoices)
        {
            if (id != nWC_Invoices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nWC_Invoices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NWC_InvoicesExists(nWC_Invoices.Id))
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
            ViewData["NWC_Invoices_Rreal_Estate_Types_No"] = new SelectList(_context.NWC_Rreal_Estate_Types, "Id", "NWC_Rreal_Estate_Types_Code", nWC_Invoices.NWC_Invoices_Rreal_Estate_Types_No);
            ViewData["NWC_Invoices_Subscriber_No"] = new SelectList(_context.NWC_Subscriber_Files, "Id", "NWC_Subscriber_File_Area", nWC_Invoices.NWC_Invoices_Subscriber_No);
            ViewData["NWC_Invoices_Subscription_No"] = new SelectList(_context.NWC_Subscription_Files, "Id", "Id", nWC_Invoices.NWC_Invoices_Subscription_No);
            return View(nWC_Invoices);
        }

        // GET: NWC_Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NWC_Invoices == null)
            {
                return NotFound();
            }

            var nWC_Invoices = await _context.NWC_Invoices
                .Include(n => n.NWC_Rreal_Estate_Types)
                .Include(n => n.NWC_Subscriber_File)
                .Include(n => n.NWC_Subscription_File)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nWC_Invoices == null)
            {
                return NotFound();
            }

            return View(nWC_Invoices);
        }

        // POST: NWC_Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NWC_Invoices == null)
            {
                return Problem("Entity set 'NWC_Context.NWC_Invoices'  is null.");
            }
            var nWC_Invoices = await _context.NWC_Invoices.FindAsync(id);
            if (nWC_Invoices != null)
            {
                _context.NWC_Invoices.Remove(nWC_Invoices);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NWC_InvoicesExists(int id)
        {
          return _context.NWC_Invoices.Any(e => e.Id == id);
        }
    }
}
