using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index( string SearchString)
        {
            var displaydata = _db.Books.ToList();
            if (!String.IsNullOrEmpty(SearchString))
            {
                displaydata = displaydata.Where(s => s.Title.Contains(SearchString)).ToList();
            }
            return View(displaydata);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var details = await _db.Books.FindAsync(id);
            return View(details);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Books ba)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ba);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ba);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var details = await _db.Books.FindAsync(id);
            return View(details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Books ed)
        {
            if (ModelState.IsValid)
            {
                _db.Update(ed);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ed);
        }

        // GET: BooksController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var details = await _db.Books.FindAsync(id);
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Books dd)
        {
            var details = await _db.Books.FindAsync(dd.BookId);
            _db.Books.Remove(details);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //public IActionResult SearchBook()
        //{
        //    return View("SearchBook");
        //}

        //public IActionResult searchForName(string searchPhrase)
        //{
            
        //    return View("SearchResults");
        //}
    }
}
