using chakito.Models;
using chakito.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chakito.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseContext db;

        public StudentController(DatabaseContext db)
        {
            this.db = db;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var stds = db.students.ToList();
            return View(stds);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var std = db.students.SingleOrDefault(s => s.Id == id);
            //var students = db.students.Where(x => x.Name =="peter").ToList();
            return View(std);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student model)
        {
            try
            {
                db.students.Add(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.students.SingleOrDefault(student => student.Id == id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                var std = db.students.SingleOrDefault(student => student.Id == id);
                if(std != null)
                {
                    std.Name = student.Name;
                    std.Description = student.Description;
                    db.students.Update(std);
                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var std = db.students.SingleOrDefault(student => student.Id == id);
            return View(std);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var std = db.students.SingleOrDefault(student => student.Id == id);
                if(std != null)
                {
                    db.students.Remove(std);
                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
