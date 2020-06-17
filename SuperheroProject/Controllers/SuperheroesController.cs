using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroProject.Data;
using SuperheroProject.Models;

namespace SuperheroProject.Controllers
{
    public class SuperheroesController : Controller
    {
        private ApplicationDbContext _context;
        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superheroes
        public IActionResult Index()
        {
            return View(_context.Superheroes);
        }

        // GET: Superheroes/Details/5
        public IActionResult Details(int id)
        {
            return View(_context.Superheroes.Where(s => s.Id == id).SingleOrDefault());
        }

        // GET: Superheroes/Create
        public IActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superheroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Edit/5
        public IActionResult Edit(int id)
        {

            return View(_context.Superheroes.Where(s => s.Id == id).SingleOrDefault());
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                var oldSuperhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
                _context.Update(oldSuperhero);
                oldSuperhero = superhero;
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}