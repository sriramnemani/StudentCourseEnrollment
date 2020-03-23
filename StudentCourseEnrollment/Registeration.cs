using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentCourseEnrollment
{
   public class Registeration
    {
        /// <summary>
        /// Registeration Details 
        /// </summary>       
        public int RegID { get; set; }
        public int StudentId { get; set; }           
        public int CourseCode { get;set; }           
        public DateTime StartDate { get; set; }
        public Studentdetails Studdetails { get; set; }
        public CourseDetails  CourseDetails { get; set; }

       // private static int lastRegCode = 0;

        public Registeration()
        {
           // RegID = lastRegCode++;
        }

    }

}
