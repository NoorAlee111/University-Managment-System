using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;

namespace uams
{
    class Program
    {
        
        static void Main(string[] args)
        {

            string degree = "";
            string code = "";
            string name = "";
            int option = 0;
            while (true)
            {

                option = StudentUI.Menu();
                if (option == 1)
                {
                    Student s = StudentUI.AddStudentUI(DegreeProgram.ProgramList);
                    StudentDL.AddStudent(s);
                }
                else if (option == 2)
                {
                    DegreeProgram p = DegreeProgramUI.AddProgramUI();
                    DegreeProgramDL.AggDegree(p);
                }
                else if (option == 3)
                {
                    List<Student> sortedlist = new List<Student>();
                    sortedlist = StudentDL.sortStudentbyMerit();
                    StudentUI.GenerateMerit(sortedlist);
                }
                else if (option == 4)
                {
                    StudentUI.ViewRegisteredStudents(Student.StudentList);
                }
                else if (option == 5)
                {
                    degree = DegreeProgramUI.getDegreeName();
                    StudentUI.specificdegreeprogram(degree, Student.StudentList);
                }
                else if (option == 6)
                {

                    name = StudentUI.getStudentName();

                    code = StudentUI.getSubjectCode();
                    StudentUI.RegSubject(name, code,Student.StudentList);
                }
                else if (option == 7)
                {
                    StudentUI.CalculateFee(Student.StudentList);
                }
                else if (option == 8)
                {
                    break;
                }

                StudentUI.clearScreen();
            }
        }
        
       

      
       
       

       
       
      
    }       
    
}
