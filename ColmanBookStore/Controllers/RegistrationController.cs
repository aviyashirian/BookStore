using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColmanBookStore.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult SignIn()
        {
            if (HttpContext.Session.GetInt32("adminId") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Welcome", "Admin", null);
            }
        }
    }
}
