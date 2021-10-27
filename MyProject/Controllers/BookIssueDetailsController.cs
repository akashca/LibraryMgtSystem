using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class BookIssueDetailsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookIssueDetailsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
