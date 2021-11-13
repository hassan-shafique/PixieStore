using Microsoft.AspNetCore.Mvc;
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
    public class HomeController : Controller
    {
        private readonly PixieStoreContext db;
        public HomeController(PixieStoreContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(new HomeVM());
        }

        public IActionResult ContactUs()
        {
            return View(new ContactusViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(ContactusViewModel contactusViewModel)
        {
            if (ModelState.IsValid)
            {
                contactusViewModel.Contactus.PublishedDate = DateTime.Now;
                db.Contactus.Add(contactusViewModel.Contactus);
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