using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarabia_Santiago_EX2
{
    public class Carrera
    {
        public string CodCarrera { get; set; }
        public string NomCarrera { get; set; }
        public string NomDirector { get; set; }

        public Carrera(string codCarrera, string nomCarrera, string nomDirector)
        {
            this.CodCarrera = codCarrera;
            this.NomCarrera = nomCarrera;
            this.NomDirector = nomDirector;
        }
    }
}
