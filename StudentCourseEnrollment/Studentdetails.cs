using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCourseEnrollment
{
   public enum TypeofGender
    {
        Female,
        Male
    }
    /// <summary>
    /// This represnets a student information
    /// to enroll the course and assignment scores.
    /// </summary>
    public class Studentdetails
    {
        // declare static variable field
     //   private static int lastStudentId = 0;

        #region properties of Student information
        /// <summary>
        /// unique student ID
        /// and student email address
        /// </summary>
        public int StudentId { get;  set; }
       // public string StudPassword { get; set; }
        public string StudName { get; set; }        
        public DateTime StudDOB { get; set; }
        public TypeofGender StudGender { get; set; }
        public string StudEmailAdd { get; set; }
        public string StudAddress { get; set; }
        public long StudphNum { get; set; }
        public Registeration Registeration { get; set; }
        //public Account Account { get; set; }


        #endregion
        // declare static method 
        //declare public constructor
        public Studentdetails()
        {
            //StudentId = lastStudentId++;
            StudDOB = DateTime.UtcNow;
        }       

    }
}