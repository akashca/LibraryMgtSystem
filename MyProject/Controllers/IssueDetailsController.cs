using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class IssueDetailsController : Controller
    {
        private readonly ApplicationDbContext _db;


        public IssueDetailsController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
        //    var displaydata = _db.IssueDetails.ToList();
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var details = await _db.IssueDetails.FindAsync(id);
            return View(details);
        }

        [HttpPost]
        public IActionResult Save(IssueDetails issue)
        {
            if (ModelState.IsValid)
            {
                _db.IssueDetails.Add(issue);
                 _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issue);
        }

        [HttpGet]
        public IActionResult getBook()
        {
            var books = _db.Books.Select(p => new
            {
                Id = p.BookId,
                title = p.Title
            }).ToList();
            return Json(books);
        }
        [HttpPost]
        public IActionResult GetIssueId(int IssueId)
        {
            var issueid = (from s in _db.Students where s.Id == IssueId select s.StudentName).ToList();
            return Json(IssueId);
        }

    }
}
