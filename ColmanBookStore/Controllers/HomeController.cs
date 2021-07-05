using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ColmanBookStore.Models;
using ColmanBookStore.Data;

namespace ColmanBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //private readonly BookStoreContext _context;
        /*public HomeController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Shop()
        {
            List<Product> products = _context.Products.ToList();
            ViewBag.Products = products;

            List<Category> categories = _context.Categories.Where(cat => !cat.IsDeleted).ToList();
            ViewBag.Categories = categories;

            ViewBag.productsInBagCount = getProductsInBagCount();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Shop(string searchText, int category, int minPrice, int maxPrice)
        {
            List<Category> categories = _context.Categories.Where(cat => !cat.IsDeleted).ToList();
            ViewBag.Categories = categories;

            List<Product> products;

            if (searchText != null)
            {
                products = _context.Products.Where((p) => p.Name.Contains(searchText)).Include(product => product.Category).ToList();
            }
            else
            {
                products = _context.Products.Include(product => product.Category).ToList();
            }

            if (category != 0)
            {
                products = products.Where((p) => p.Category.ID == category).ToList();
            }

            if (maxPrice <= 0)
            {
                maxPrice = int.MaxValue;
            }

            products = products.Where((p) => p.Price >= minPrice && p.Price <= maxPrice).ToList();

            ViewBag.Products = products;

            ViewBag.productsInBagCount = getProductsInBagCount();

            return View();
        }

        private dynamic getProductsInBagCount()
        {
            var keys = HttpContext.Session.Keys.Where(key => key != "adminId" && key != "fullName");
            int productsInBagCount = 0;
            foreach (var key in keys)
            {
                productsInBagCount += int.Parse(HttpContext.Session.GetString(key));
            }

            return productsInBagCount;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "The Smarty Colman.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewBag.Branches = _context.Branches.ToList();
            return View();
        }*/

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*public IActionResult NotFound()
        {
            return View();
        }*/
    }
}
