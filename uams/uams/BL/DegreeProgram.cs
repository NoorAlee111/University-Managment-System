using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uams.BL
{
    class DegreeProgram
    {
      public  string ProgramTitle;
      public string DegreeDuration;
       public int AvailableSeats;
        public float merit;
        public List<Subject> NewSubjects =new List<Subject>();
        public static List<DegreeProgram> ProgramList = new List<DegreeProgram>();
        public DegreeProgram(string ProgramTitle,string DegreeDuration,int AvailableSeats,float merit)
        {
            this.ProgramTitle = ProgramTitle;
            this.DegreeDuration= DegreeDuration;
            this.AvailableSeats = AvailableSeats;
            this.merit=merit;
          

        }
        public int CalculateCreditHours()
        {
            int count = 0;
            for(int i=0;i<NewSubjects.Count;i++)
            {
                count = count + NewSubjects[i].CreditHours;
            }
            return count;
        }
            
        public bool addsubject(Subject s)
        {
            bool flag = false;
            int credithours = CalculateCreditHours();
            if(credithours<=20)
            {
                NewSubjects.Add(s);
                flag = true;
            }
            return flag;
          
        }
      

    }
}
