using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDir.Interface;
using TelephoneDir.Models;

namespace TelephoneDir.Controllers
{
    public class TelephoneDirController : Controller
    {
        private readonly ITelephoneDirService _context;

        public TelephoneDirController(ITelephoneDirService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAllPerson());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(Person personData)
        {

            _context.Create(personData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string name)
        {
            var md = _context.GetPersonDetails(name);
            return View(md);
        }

        [HttpPost]
        public IActionResult EditPost(string name, Person personData)
        {

            _context.Update(name, personData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string name)
        {
            var md = _context.GetPersonDetails(name);
            return View(md);
        }

        [HttpGet]
        public IActionResult Delete(string name)
        {
            var md = _context.GetPersonDetails(name);
            return View(md);
        }
        [HttpPost]
        public IActionResult DeletePost(string name)
        {
            _context.Delete(name);
            return RedirectToAction("Index");
        }
    }
}
