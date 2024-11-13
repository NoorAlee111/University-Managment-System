using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;

namespace uams
{
    class DegreeProgramDL
    {
        public static void AggDegree(DegreeProgram P)
        {
            DegreeProgram.ProgramList.Add(P);
        }
    }
}
