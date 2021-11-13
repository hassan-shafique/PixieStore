using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PixieStore.Data;
using PixieStore.Models;
using PixieStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsController : Controller
    {
        private readonly PixieStoreContext db;
        public ProductsController(PixieStoreContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            var vm = new ProductsMainVM();
            vm.Products = await db.Products.ToListAsync();
            return View(vm);
        }
        public async Task<IActionResult> SingleProduct(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var product = db.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                var vm = new SingleProductsVM();
                vm.Products = product;
                return View(vm);
            }
        }
    }
}
