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
    public class CourseDetailsController : Controller
    {
      //  private readonly SchoolDbContext _context;

        //public CourseDetailsController(SchoolDbContext context)
        //{
        //    _context = context;
        //}

        // GET: CourseDetails
        public IActionResult Index()
        {
            var courses = School.GetAllCourses();
            return View(courses);
        }

        // GET: CourseDetails/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = School.GetCourseName(id.Value);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return View(courseDetails);
        }

        // GET: CourseDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("Description,CourseFee")] CourseDetails courseDetails)
        {
            if (ModelState.IsValid)
            {
                School.Addcourse(courseDetails.Description, courseDetails.CourseFee);
                return RedirectToAction(nameof(Index));
            }
            return View(courseDetails);
        }

        // GET: CourseDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails =School.GetCourseName(id.Value);
            if (courseDetails == null)
            {
                return NotFound();
            }
            return View(courseDetails);
        }

        // POST: CourseDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CourseCode,CourseStartDate,Description,CourseFee,Grade")] CourseDetails courseDetails)
        {
            if (id != courseDetails.CourseCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                School.UpdateCourse(courseDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(courseDetails);
        }

        // GET: CourseDetails/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = School.GetCourseName(id.Value);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return View(courseDetails);
        }

        // POST: CourseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            School.DropCourse(id);
            return RedirectToAction(nameof(Index));
        }

       // private bool CourseDetailsExists(int id)
       // {
         //   return _context.CourseDetails.Any(e => e.CourseCode == id);
        //}
    }
}
