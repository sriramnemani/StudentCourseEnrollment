using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentCourseEnrollment
{
    public static class School
    {
        //private static List<Studentdetails> students = new List<Studentdetails>();
        //private static List<CourseDetails> courses = new List<CourseDetails>();
        //private static List<Registeration> register = new List<Registeration>();
        private static SchoolDbContext db = new SchoolDbContext();

        public static Registeration studentRegister(int studentid, int coursecode)
        {
            var reg = new Registeration
            {
                StartDate = DateTime.UtcNow,
                StudentId = studentid,
                CourseCode = coursecode
            };
            db.Registeration.Add(reg);
            db.SaveChanges();
            return reg;
        }

        public static void studentUnRegisterCourse(int regid, int coursecode)
        {
            Registeration reg = db.Registeration.Where(reg => reg.CourseCode == coursecode
                                                && reg.RegID == regid).Single();
            db.Registeration.Remove(reg);
            db.SaveChanges();
        }



        public static CourseDetails Addcourse(string descrp, decimal coursefee = 0)
        {
            //string newcourse = "";
            var courseinfo = new CourseDetails
            {
                // CourseCode = coursecode,
                Description = descrp,
                CourseStartDate = DateTime.UtcNow
            };
            if (coursefee > 0)
            {
                courseinfo.courseAmt(coursefee);
            }
            db.CourseDetails.Add(courseinfo);
            db.SaveChanges();
            return courseinfo;
        }

        public static void DropCourse(int coursecode)
        {
            CourseDetails CS = db.CourseDetails.Where(CS => CS.CourseCode == coursecode).Single();
            db.CourseDetails.Remove(CS);
            db.SaveChanges();
        }

        public static Studentdetails AddStudent(string stuname,
                                            string emailaddress,
                                            TypeofGender gender = TypeofGender.Female)
        {
            var student = new Studentdetails
            {
                StudName = stuname,
                StudEmailAdd = emailaddress,
                StudGender = gender,
            };
            db.StudentDetails.Add(student);
            db.SaveChanges();
            return student;
        }

        public static void RemoveStudent(int studentid)
        {
            //var student = new Studentdetails();

            Studentdetails SD = db.StudentDetails.Where(SD => SD.StudentId == studentid).Single();
            db.StudentDetails.Remove(SD);
            db.SaveChanges();
        }
        public static Studentdetails GetStudName(int studId)
        {
            var stud = db.StudentDetails.SingleOrDefault(a => a.StudentId == studId);
            if (stud == null)
            {
                throw new ArgumentException("Invalid StudentID! Try Again.");
            }
            return stud;
        }

        public static CourseDetails GetCourseName(int coursecode)
        {
            var course = db.CourseDetails.SingleOrDefault(a => a.CourseCode == coursecode);
            return course;
        }

        public static IEnumerable<Studentdetails> GetStudentInfoByEmailAddress(string emailAddress)
        {
            return db.StudentDetails.Where(a => a.StudEmailAdd == emailAddress);
        }

        public static Registeration GetRegisterations(int regid)
        {
            var reg = db.Registeration.SingleOrDefault(a => a.RegID == regid);
            return reg;
        }
       

        public static IEnumerable<Registeration> GetAllRegisterationforCourses()
        {
             var reg = from rg in db.Registeration
                        select rg;
            
            if (reg == null)
            {
                throw new ArgumentException("Invalid Registeration! Try Again.");
            }           
            return reg;
        }

        public static void GetAllCoursesByStudent1(int studentId)
        {
            var course = from st in db.StudentDetails
                         join rg in db.Registeration
                         on st.StudentId equals rg.StudentId
                         join cs in db.CourseDetails
                         on rg.CourseCode equals cs.CourseCode
                         where rg.StudentId == studentId
                         select new
                         {
                             st.StudentId,
                             st.StudName,
                             cs.Description,
                             cs.CourseFee
                         };
            
        }

        public static IEnumerable<CourseDetails> GetAllCourses()
        {
            var course = from cs in db.CourseDetails
                          select cs;
            if (course == null)
            {
                throw new ArgumentException("Invalid course! Try Again.");
            }
            return course;
        }

        public static CourseDetails GetCourse(string name)
        {
            var course = db.CourseDetails.SingleOrDefault(a => a.Description == name);
            if (course == null)
            {
                throw new ArgumentException("Invalid StudentID! Try Again.");
            }
            return course;
        }        
        
        public static void Update(Studentdetails UpdateStuddetails)
        {
            var oldStudentdetails = GetStudName(UpdateStuddetails.StudentId);
            oldStudentdetails.StudName = UpdateStuddetails.StudName;
            oldStudentdetails.StudGender = UpdateStuddetails.StudGender;
            oldStudentdetails.StudEmailAdd = UpdateStuddetails.StudEmailAdd;
            oldStudentdetails.StudAddress = UpdateStuddetails.StudAddress;
            oldStudentdetails.StudphNum = UpdateStuddetails.StudphNum;

            db.SaveChanges();
        }


        public static void UpdateCourse(CourseDetails UpdateCourdetails)
        {
            var oldCourdetails = GetCourseName(UpdateCourdetails.CourseCode);
            oldCourdetails.Description = UpdateCourdetails.Description;
            oldCourdetails.CourseFee = UpdateCourdetails.CourseFee;
           
            db.SaveChanges();
        }

        public static void UpdateRegister(Registeration UpdateRegisteration)
        {
            var oldRegister = GetRegisterations(UpdateRegisteration.RegID);
            oldRegister.StudentId = UpdateRegisteration.StudentId;
            oldRegister.CourseCode = UpdateRegisteration.CourseCode;         
            db.SaveChanges();
        }

        public static void PrintAllRegisterations()
        {
            if (db.Registeration != null)
            {
                foreach (var a in db.Registeration)
                {
                    Console.WriteLine($"StudentID: {a.StudentId}, " +
                     $"Coursecode: {a.CourseCode}");
                }
            }
            else 
            {
                Console.WriteLine("Registeration List is Empty.");
            }
        }

        
        public static void PrintAllcoursedetails()
        {            
            if (db.CourseDetails != null)
            {
                foreach (var a in db.CourseDetails)
                {
                    Console.WriteLine($"CourseCode: {a.CourseCode}, " +
                     $"Name: {a.Description}, " +
                     $"Fee: {a.CourseFee}");
                }
            }
            else
            {
                Console.WriteLine("Course List is Empty.");
            }
        }
    }
}
