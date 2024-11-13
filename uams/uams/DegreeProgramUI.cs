using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;

namespace uams
{
    class DegreeProgramUI
    {
       public static DegreeProgram AddProgramUI()
        {
            List<Subject> ListofSub = new List<Subject>();
            float merit;
            int no_of_subjects;
            string ProgramTitle, DegreeDuration;
            int AvailableSeats;
            Console.WriteLine("Enter Degree title:");
            ProgramTitle = Console.ReadLine();
            Console.WriteLine("Enter Degree duration:");
            DegreeDuration = Console.ReadLine();
            Console.WriteLine("Enter no of Available Seats:");
            AvailableSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter merit of this degree program:");
            merit = float.Parse(Console.ReadLine()); ;
            Console.WriteLine("Enter how many subjects to enter:");
            no_of_subjects = int.Parse(Console.ReadLine());
            DegreeProgram S = new DegreeProgram(ProgramTitle, DegreeDuration, AvailableSeats, merit);
            for (int i = 0; i < no_of_subjects; i++)
            {
                Subject s = getsubject();
                bool flag = S.addsubject(s);
                if (flag == true)
                {
                    Console.WriteLine("Subject is registered..");
                }
                else
                {
                    Console.WriteLine("Subject is not registered..");
                }
            }

            return S;
        }
     public static Subject getsubject()
        {
            Subject s = new Subject();

            Console.WriteLine("Enter Subject code:");
            s.SubjectCode = Console.ReadLine();
            Console.WriteLine("Enter Subject type:");
            s.SubjectType = Console.ReadLine();
            Console.WriteLine("Enter Credit Hours:");
            s.CreditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject fees:");
            s.SubjectFee = int.Parse(Console.ReadLine());
            return s;
        }
        public static string getDegreeName()
        {
            string degree = "";
            Console.WriteLine("Enter Degree Name: ");
            degree = Console.ReadLine();
            return degree;
        }
    }
}
