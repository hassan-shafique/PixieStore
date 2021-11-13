using Microsoft.AspNetCore.Mvc;
using PixieStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.Areas.Customer.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PixieStoreContext db;
        public ProductsController(PixieStoreContext _db)
        {
            _db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SingleProduct(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //Pending
                //It will be completed.
                //once the Product Model class is created.
                //To create product I have to create
                //Tags, Catagories etc.
                //as well as its variations
//                var product = 
            }
            return View();
        }
    }
}
