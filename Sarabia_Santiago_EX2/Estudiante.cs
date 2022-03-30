using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarabia_Santiago_EX2
{
    public class Estudiante
    {
        public int CI { get; set; }
        public string NomEst { get; set; }
        public string CodCarrera { get; set; }
        public int Semestre { get; set; }

        public Estudiante(int CI, string nomEst, string codCarrera, int semestre)
        {
            this.CI = CI;
            this.NomEst = nomEst;
            this.CodCarrera = codCarrera;
            this.Semestre = semestre;
        }

    }
}
