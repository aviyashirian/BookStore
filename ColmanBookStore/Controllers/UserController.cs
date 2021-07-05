using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColmanBookStore.Data;

namespace ColmanBookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly BookStoreContext _context;

        public UserController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == null || password == null)
            {
                TempData["LoginFailed"] = true;
                return Redirect("/Registration/SignIn");
            }

            var admin = _context.Admins.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (admin == null)
            {
                TempData["LoginFailed"] = true;
                return Redirect("/Registration/SignIn");
            }

            HttpContext.Session.SetInt32("adminId", admin.Id);
            HttpContext.Session.SetString("fullName", admin.FullName);

            return RedirectToAction("Welcome", "Admin", null);
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetInt32("adminId") == null)
            {
                return View("Views/Users/NotFound.cshtml");
            }

            HttpContext.Session.Remove("adminId");
            return RedirectToAction("Index", "Home", null);
        }
    }
}
