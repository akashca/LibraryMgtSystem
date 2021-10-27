using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace MyProject.Controllers
{
    public class BookReturnController : Controller
    {
        private readonly ApplicationDbContext _db;
        public int Days;
        public BookReturnController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(new BookReturn());
        }

        public IActionResult FinCalc(BookReturn s)
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Save(BookReturn bookReturn)
        {
            if (ModelState.IsValid)
            {
                _db.BookReturn.Add(bookReturn);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookReturn);
        }
        public IActionResult GetIssueId(int IssueId)
        {
            var studentid = (from s in _db.IssueDetails where s.IssueId == IssueId
                             select new
                             {
                                 IssueDate = s.IssueDate,
                                 ReturnDate = s.ReturnDate,
                                 id = s.IssueId,
                                 title = s.Title,
                                  ElapsedDays = SqlFunctions.DateDiff("day", s.ReturnDate, DateTime.Now)

                             }).ToArray();
            return Json(studentid);
        }
       
    }
}
