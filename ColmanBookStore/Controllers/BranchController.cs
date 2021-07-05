using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColmanBookStore.Models;
using ColmanBookStore.Data;

namespace ColmanBookStore.Controllers
{
    public class BranchController : Controller
    {
        private readonly BookStoreContext _context;

        public BranchController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getBranches()
        {
            List<Branch> branches = _context.Branches.ToList();
            ViewBag.Branches = branches;

            return Json(branches);
        }
    }
}
