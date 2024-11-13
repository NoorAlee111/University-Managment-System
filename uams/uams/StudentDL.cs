using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;

namespace uams
{
    class StudentDL
    {
        public static void AddStudent(Student S)
        {
            Student.StudentList.Add(S);
        }
        public static List<Student> sortStudentbyMerit()
        {
            List<Student> sortedlist = new List<Student>();
            for (int i = 0; i < Student.StudentList.Count; i++)
            {
                Student. StudentList[i].Merit = Student.StudentList[i].CalculateAgg();
            }
            sortedlist = Student.StudentList.OrderByDescending(o => o.Merit).ToList();
            return sortedlist;
        }


    }
}
