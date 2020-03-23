using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourseEnrollment;
using NToastNotify;

namespace StudentCourseEnrollUI.Controllers
{
    [Authorize]
    public class StudentdetailsController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public StudentdetailsController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
       
        // GET: Studentdetails
        public IActionResult Index()
        {            
            
            return View(School.GetStudentInfoByEmailAddress(HttpContext.User.Identity.Name));
        }

        // GET: Studentdetails/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentdetails = School.GetStudName(id.Value);
            if (studentdetails == null)
            {
                return NotFound();
            }

            return View(studentdetails);
        }

        // GET: Studentdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studentdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("StudName,StudGender,StudEmailAdd")] 
        Studentdetails studentdetails)
        {
            if (ModelState.IsValid)
            {
                School.AddStudent(studentdetails.StudName, studentdetails.StudEmailAdd, studentdetails.StudGender);
                _toastNotification.AddSuccessToastMessage("Student created!");
                return RedirectToAction(nameof(Index));
            }
            return View(studentdetails);
        }

        // GET: Studentdetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentdetails = School.GetStudName(id.Value);
            if (studentdetails == null)
            {
                return NotFound();
            }
            return View(studentdetails);
        }

        // POST: Studentdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("StudentId,StudName,StudDOB,StudGender,StudEmailAdd,StudAddress,StudphNum")] Studentdetails studentdetails)
        {
            if (id != studentdetails.StudentId)
            {
                return NotFound();
            }
            
                if (ModelState.IsValid)
                {
                    School.Update(studentdetails);
                    return RedirectToAction(nameof(Index));
                }
            return View(studentdetails);
        }

        // GET: Studentdetails/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentdetails = School.GetStudName(id.Value);
            if (studentdetails == null)
            {
                return NotFound();
            }

            return View(studentdetails);
        }

        // POST: Studentdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            School.RemoveStudent(id);   
            return RedirectToAction(nameof(Index));
        }

       // private bool StudentdetailsExists(int id)
        //{
          //  return _context.StudentDetails.Any(e => e.StudentId == id);
        //}
    }
}
