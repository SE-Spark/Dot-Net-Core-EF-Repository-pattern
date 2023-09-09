using chakito.Models;
using chakito.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chakito.Controllers
{
    public class PersonController : Controller
    {
        private IRepository<Person> repository;

        public PersonController(IRepository<Person> repository)
        {
            this.repository = repository;
        }

        // GET: PersonController
        public ActionResult Index()
        {
            var persons = repository.GetAll();
            return View(persons);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            var person = repository.GetById(id);
            return View(person);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person model)
        {
            try
            {
                repository.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            var person = repository.GetById(id);
            return View(person);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person model)
        {
            try
            {
                repository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            var person = repository.GetById(id);
            return View(person);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repository.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
