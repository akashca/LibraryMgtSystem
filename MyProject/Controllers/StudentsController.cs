using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.Students.ToList();
            return View(displaydata);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var details = await _db.Students.FindAsync(id);
            return View(details);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Students ba)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ba);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ba);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var details = await _db.Students.FindAsync(id);
            return View(details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Students ed)
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
            var details = await _db.Students.FindAsync(id);
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Students dd)
        {
            var details = await _db.Students.FindAsync(dd.Id);
            _db.Students.Remove(details);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
