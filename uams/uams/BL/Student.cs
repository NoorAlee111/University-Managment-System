using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uams.BL
{

    class Student
    {
        public string StudentName;
        public int FscMarks;
        public int EcatMarks;
        public int StudentAge;
        public float Merit;
        public bool registered = false;
        public DegreeProgram gotadmissionin;
        public List<DegreeProgram> Preferences = new List<DegreeProgram>();
        public List<Subject> regsubject = new List<Subject>();
        public static List<Student> StudentList = new List<Student>();
        public float CalculateAgg()
        {
            float Merit = ((FscMarks/1100f) * 0.45F) + ((EcatMarks/400f) * 0.55F)*100f;
            return Merit;

        }
        
        public bool GenerateMerit ()
        {
            
            int count = 0;
            for(int i=0;i<= Preferences.Count;i++)
            {
                if(Merit >= Preferences[i].merit&& Preferences[i].AvailableSeats>0)
                {
                    
                    count++;
                    gotadmissionin = Preferences[i];
                    registered = true;
                    Preferences[i].AvailableSeats--;
                    break;
                }
            }
            if(count==1)
            {
                return true;
                
            }
            if(registered==false)
            {
                return false;
                
            }
            return false;
        }
        public int getcredithours()
        {
            int count = 0;
            for(int i=0;i<regsubject.Count;i++)
            {
                count = count + regsubject[i].CreditHours;
            }
            return count;
        }
        public  bool registersubject(string code)
        {
            int ch = getcredithours();
            for (int i=0;i < Preferences.Count;i++)
            {
                if(registered==true&&gotadmissionin == Preferences[i])
                {
                    
                    for(int x=0;x < Preferences[i].NewSubjects.Count;x++)
                    {
                        if (code == Preferences[i].NewSubjects[x].SubjectCode&&!(regsubject.Contains(Preferences[i].NewSubjects[x])))
                         {
                            if (ch + Preferences[i].NewSubjects[x].CreditHours <= 9)
                            {
                                regsubject.Add(Preferences[i].NewSubjects[x]);
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                                    
                         }
                            
                        
                    }
                }
            }
            return false;
        }
        public float calculatefee()
        {
            float fee = 0.0F; ;
            if(gotadmissionin!=null)
            {
                for(int i=0;i< regsubject.Count;i++)
                {
                    fee = fee + regsubject[i].SubjectFee;
                }
            }
            return fee;
        }
     
  
    }
}
