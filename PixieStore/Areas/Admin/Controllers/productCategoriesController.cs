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
    public class productCategoriesController : Controller
    {
        private readonly PixieStoreContext _context;

        public productCategoriesController(PixieStoreContext context)
        {
            _context = context;
        }

        // GET: Admin/productCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.productCategory.ToListAsync());
        }

        // GET: Admin/productCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.productCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: Admin/productCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/productCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product_CatName,Category_Desc,created_Date,last_Update")] productCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCategory);
        }

        // GET: Admin/productCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.productCategory.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        // POST: Admin/productCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product_CatName,Category_Desc,created_Date,last_Update")] productCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productCategoryExists(productCategory.Id))
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
            return View(productCategory);
        }

        // GET: Admin/productCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.productCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: Admin/productCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCategory = await _context.productCategory.FindAsync(id);
            _context.productCategory.Remove(productCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool productCategoryExists(int id)
        {
            return _context.productCategory.Any(e => e.Id == id);
        }
    }
}
