using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PixieStore.Data;
using PixieStore.Models;

namespace PixieStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribersController : Controller
    {
        private readonly PixieStoreContext _context;

        public SubscribersController(PixieStoreContext context)
        {
            _context = context;
        }

        // GET: Admin/Subscribers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subscriber.ToListAsync());
        }

        // GET: Admin/Subscribers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscriber
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // GET: Admin/Subscribers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Subscribers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,S_Email,Created_Date")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscriber);
        }

        // GET: Admin/Subscribers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscriber.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            return View(subscriber);
        }

        // POST: Admin/Subscribers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,S_Email,Created_Date")] Subscriber subscriber)
        {
            if (id != subscriber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriberExists(subscriber.Id))
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
            return View(subscriber);
        }

        // GET: Admin/Subscribers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscriber
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // POST: Admin/Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriber = await _context.Subscriber.FindAsync(id);
            _context.Subscriber.Remove(subscriber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriberExists(int id)
        {
            return _context.Subscriber.Any(e => e.Id == id);
        }
    }
}
