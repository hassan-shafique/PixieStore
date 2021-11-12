using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PixieStore.Data;
using PixieStore.Models;

namespace PixieStore.Controllers
{
    [Area("Admin")]
    public class ContactusController : Controller
    {
        private readonly PixieStoreContext _context;

        public ContactusController(PixieStoreContext context)
        {
            _context = context;
        }

        // GET: Contactus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactus.ToListAsync());
        }

        // GET: Contactus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.Contactus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactus == null)
            {
                return NotFound();
            }

            return View(contactus);
        }

        // GET: Contactus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.Contactus.FindAsync(id);
            if (contactus == null)
            {
                return NotFound();
            }
            return View(contactus);
        }

        // POST: Contactus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Subject,Message,PublishedDate")] Contactus contactus)
        {
            if (id != contactus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactusExists(contactus.Id))
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
            return View(contactus);
        }

        // GET: Contactus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactus = await _context.Contactus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactus == null)
            {
                return NotFound();
            }

            return View(contactus);
        }

        // POST: Contactus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactus = await _context.Contactus.FindAsync(id);
            _context.Contactus.Remove(contactus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactusExists(int id)
        {
            return _context.Contactus.Any(e => e.Id == id);
        }
    }
}
