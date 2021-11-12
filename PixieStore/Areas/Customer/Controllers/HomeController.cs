using Microsoft.AspNetCore.Mvc;
using PixieStore.Data;
using PixieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixieStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly PixieStoreContext db;
        public HomeController(PixieStoreContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View(new Contactus());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(Contactus contactus)
        {
            if (ModelState.IsValid)
            {
                db.Contactus.Add(contactus);
                await db.SaveChangesAsync();
                return View();
            }
            return View();
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add_Subscriber(Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                subscriber.Created_Date = DateTime.Now;
                db.Subscriber.Add(subscriber);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }
    }
}