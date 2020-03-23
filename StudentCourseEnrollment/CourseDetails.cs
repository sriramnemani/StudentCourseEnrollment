using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCourseEnrollment
{
   public class CourseDetails
    {
        //private static int lastcourse = 0;
        /// <summary>
        /// Course properties
        /// </summary>
        public int CourseCode { get; set; }
        public DateTime CourseStartDate { get; set; }
        public string Description { get; set; }
        public decimal CourseFee { get; set; }
        public string Grade { get; set; }
        public Registeration Registeration { get; set; }

     //   private static int lastCourseCode = 0;

        public CourseDetails()
        {
        //    CourseCode = lastCourseCode++;
        }

        public void courseAmt(decimal amount)
        {
            CourseFee = +amount;

        }
    }
}
