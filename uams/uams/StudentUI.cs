using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;

namespace uams
{
    class StudentUI
    {
        public static int idx = 0;
        public static int Menu()
        {
            int op;
            Console.WriteLine("*******************************************");
            Console.WriteLine("********************UAMS*******************");
            Console.WriteLine("*******************************************");
            Console.WriteLine("1:Add Student");
            Console.WriteLine("2:Add Degree Program");
            Console.WriteLine("3:Generate Merit");
            Console.WriteLine("4:View Registered Students");
            Console.WriteLine("5:View Students of a Specific Program");
            Console.WriteLine("6:Register Subjects For a Specific Student");
            Console.WriteLine("7:Calculate Fees for all Registered Students");
            Console.WriteLine("8:Exit");
            Console.WriteLine("Enter your option");
            op = int.Parse(Console.ReadLine());
            return op;

        }
        public static void GenerateMerit(List<Student> sortedlist)
        {
            for (int i = 0; i < sortedlist.Count; i++)
            {
                bool flag = sortedlist[i].GenerateMerit();
                if (flag == true)
                {
                    Console.WriteLine("{0} got admission in {1}", sortedlist[i].StudentName, sortedlist[i].gotadmissionin.ProgramTitle);
                }
                else if (flag == false)
                {
                    Console.WriteLine("{0} did not get admission.", sortedlist[i].StudentName);
                }

            }
        }
        public static Student AddStudentUI(List<DegreeProgram> ProgramList)
        {
            int no_of_pref;
            Student s = new Student();
            Console.WriteLine("Enter Student Name:");
            s.StudentName = Console.ReadLine();
            Console.WriteLine("Enter Student Age:");
            s.StudentAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student FSC Marks:");
            s.FscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat Marks:");
            s.EcatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Availaible Degree program");
            for (int i = 0; i < ProgramList.Count; i++)
            {
                Console.WriteLine(ProgramList[i].ProgramTitle + "\t");
            }
            Console.WriteLine("Enter how many preferences to enter:");
            no_of_pref = int.Parse(Console.ReadLine());
            for (int i = 0; i < no_of_pref; i++)
            {
                string pref = takingpref(ProgramList);
                s.Preferences.Add(ProgramList[idx]);
            }
            return s;
        }
        public static string takingpref(List<DegreeProgram> ProgramList)
        {
            string pref = "";
            bool flag = false;
            while (flag != true)
            {
                pref = Console.ReadLine();
                for (int i = 0; i < ProgramList.Count; i++)
                {
                    if (pref == ProgramList[i].ProgramTitle)
                    {
                        flag = true;
                        idx = i;
                        break;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("You entered wrong input..enter again...");
                }
            }
            return (pref);
        }
        public static void ViewRegisteredStudents(List<Student> StudentList)
        {
            int count = 0;
            Console.WriteLine("Name\t\tFsc\t\tEcat\t\tAge");
            for (int i = 0; i < StudentList.Count; i++)
            {
                if (StudentList[i].registered == true)
                {
                    Console.WriteLine(StudentList[i].StudentName + "\t\t" + StudentList[i].FscMarks + "\t\t" + StudentList[i].EcatMarks + "\t\t" + StudentList[i].StudentAge);
                }
                count++;
            }
            if (count == 0)
            {
                Console.WriteLine("No students are registered yet");
            }
        }
        public static void specificdegreeprogram(string degree, List<Student> StudentList)
        {
            Console.WriteLine("Name\t\tFsc\t\tEcat\t\tAge");
            for (int i = 0; i < StudentList.Count; i++)
            {
                if (degree == StudentList[i].gotadmissionin.ProgramTitle)
                {
                    Console.WriteLine(StudentList[i].StudentName + "\t\t" + StudentList[i].FscMarks + "\t\t" + StudentList[i].EcatMarks + "\t\t" + StudentList[i].StudentAge);
                }
            }
        }
     public static void RegSubject(string name, string code, List<Student> StudentList)
        {
            for (int i = 0; i < StudentList.Count; i++)
            {
                if (name == StudentList[i].StudentName)
                {
                    bool flag = StudentList[i].registersubject(code);
                    if (flag == true)
                    {
                        Console.WriteLine("Subject is registered..");
                    }
                    else
                    {
                        Console.WriteLine("A student cannot have more than 9 CH..");
                    }
                }
            }
        }
      public  static void CalculateFee(List<Student> StudentList)
        {
            float fee;
            for (int i = 0; i < StudentList.Count; i++)
            {
                fee = StudentList[i].calculatefee();
                Console.WriteLine("{0}'s fees is {1}", StudentList[i].StudentName, fee);
            }
        }
      public  static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

     public   static string getStudentName()
        {
            string name = "";
            Console.WriteLine("Enter Student Name: ");
            name = Console.ReadLine();
            return name;
        }
     
       public static string getSubjectCode()
        {
            string code = "";
            Console.WriteLine("Enter Subject Code:");
            code = Console.ReadLine();
            return code;
        }

    }
}
