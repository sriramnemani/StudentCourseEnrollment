using System;

namespace StudentCourseEnrollment
{
    class Program
    {
        static void Main(string[] args)
        {
            // var studentCurInfo = new studInfo();
            
            //private static List<CourseDetails> courses = new List<CourseDetails>();
            var courses = new CourseDetails();
            var students = new Studentdetails();
            var register = new Registeration();
            Console.WriteLine("*********************");
            Console.WriteLine("Welcome to School!");
            while (true)
            {
                Console.WriteLine("*********************");
                Console.WriteLine("0. Exit");                
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Add Courses");
                Console.WriteLine("3. New Registeration");
                Console.WriteLine("4. Unregister");                
                Console.WriteLine("5. Remove Student");
                Console.WriteLine("6. View all Students");
               // Console.WriteLine("4. Get all Students by email");

                Console.WriteLine("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank You!!!");
                        return;

                    
                    case "1":
                        Console.WriteLine("Student Name:");
                        var studName = Console.ReadLine();

                        Console.WriteLine("Student Email Address:");
                        var studEmail = Console.ReadLine();

                        Console.WriteLine("Student Gender:");
                        //Array of string assign to variable
                        var studGen = Enum.GetNames(typeof(TypeofGender));
                        for (var i = 0; i < studGen.Length; i++)
                        {
                            Console.WriteLine($"{i}. {studGen[i]}");
                        }

                        //Type casting
                        //Generic methods "<>"
                        //Read the value asking the enum to parse the string into and then give you the type.
                        var studGender = Enum.Parse<TypeofGender>(Console.ReadLine());
                                                
                        var studentInfo = School.AddStudent(studName,studEmail,studGender);

                        Console.WriteLine($"StudID: {studentInfo.StudentId} " +
                        $" StudName: {studentInfo.StudName} " +
                        $" Email: {studentInfo.StudEmailAdd} " +
                        $" StudentGender: {studentInfo.StudGender} ");                 
                        
                        break;

                    case "2":
                       
                            Console.WriteLine("Description:");
                            var desc = Console.ReadLine();

                            Console.WriteLine("courseFee:");
                            var coursefee = Convert.ToDecimal(Console.ReadLine());
                                                       
                                var courseInfo = School.Addcourse(desc, coursefee);
                                Console.WriteLine($"CourseCode: {courseInfo.CourseCode} " +
                                $" Description: {courseInfo.Description} " +
                                $" Fee: {courseInfo.CourseFee:C}");

                                Console.WriteLine("new course created!");                           
                        
                        School.PrintAllcoursedetails();
                        break;

                    case "3":

                        Console.WriteLine("StudentId:");
                        var studentId = Convert.ToInt32 (Console.ReadLine());

                        Console.WriteLine("CourseCode:");
                        var coursecode =Convert.ToInt32(Console.ReadLine());

                        var registerInfo = School.studentRegister(studentId,coursecode);

                        Console.WriteLine($"StudID: {registerInfo.StudentId} " +
                                $" CourseCode: {registerInfo.CourseCode} ");
                               
                        break;

                    case "4":

                        Console.WriteLine("Studet Id:");
                        var studentid = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("CourseCode:");
                        var courcode = Convert.ToInt32(Console.ReadLine());

                        School.studentUnRegisterCourse(studentid,courcode);

                        Console.WriteLine("unregistered student from course.");
                        break;

                    case "5":
                        Console.WriteLine("student ID:");
                        var studId = Convert.ToInt32(Console.ReadLine());

                        School.RemoveStudent(studId);

                        Console.WriteLine("Student Record Deleted!");
                        break;

                    case "6":
                        // School.PrintAllStudentswithcourses();
                        //  School.PrintAllRegisterations();
                        Console.WriteLine("student ID:");
                        //var studId1 = Convert.ToInt32(Console.ReadLine());
                        //School.GetAllCoursesByStudent(studId1);
                        //
                        // foreach (var stud in student)
                        // {
                        //   Console.WriteLine($"SID: {stud.StudentId}, " +
                        //     $"SN: {stud.CourseCode}");
                        //}
                        School.GetAllRegisterationforCourses();
                        break;
                    case "7":

                    default:
                        Console.WriteLine("Invalid option! Try again!");
                        break;
                }

            }

        }
    }
}
