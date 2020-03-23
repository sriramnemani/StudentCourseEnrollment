using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourseEnrollment;

namespace StudentCourseEnrollUI.Controllers
{
    public class RegisterationsController : Controller
    {
        //private readonly SchoolDbContext _context;

       // public RegisterationsController(SchoolDbContext context)
        //{
          //  _context = context;
        //}

        // GET: Registerations
        public IActionResult Index()
        {
            var register = School.GetAllRegisterationforCourses();
              return View(register);
            // return View(School.GetStudentInfoByEmailAddress(HttpContext.User.Identity.Name));
           // return View();
        }

        // GET: Registerations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeration = School.GetRegisterations(id.Value);
              
           if (registeration == null)
           {
             return NotFound();
           }

            return View(registeration);
        }

        // GET: Registerations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registerations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StudentId,CourseCode")] Registeration registeration)
        {
            if (ModelState.IsValid)
            {
                School.studentRegister(registeration.StudentId, registeration.CourseCode);
                return RedirectToAction(nameof(Index));
            }           
            return View(registeration);
        }

        // GET: Registerations/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeration = School.GetRegisterations(id.Value);
            if (registeration == null)
            {
                return NotFound();
            }
            
            return View(registeration);
        }

        // POST: Registerations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RegID,StudentId,CourseCode,StartDate")] Registeration registeration)
        {
            if (id != registeration.RegID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                School.UpdateRegister(registeration);            
                return RedirectToAction(nameof(Index));
            }
           return View(registeration);
        }

        // GET: Registerations/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeration = School.GetRegisterations(id.Value);
            if (registeration == null)
            {
                return NotFound();
            }

            return View(registeration);
        }

        // POST: Registerations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id, int? courseID)
        {
            School.studentUnRegisterCourse(id.Value, courseID.Value);
            return RedirectToAction(nameof(Index));
        }

        //private bool RegisterationExists(int id)
        //{
          //  return _context.Registeration.Any(e => e.RegID == id);
       // }
    }
}
