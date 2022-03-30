using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarabia_Santiago_EX2
{
    public class Materia
    {
        public string CodMateria { get; set; }
        public string NomMateria { get; set; }
        public int Semestre { get; set; }

        public Materia(string codMateria, string nomMateria, int semestre)
        {
            this.CodMateria = codMateria;
            this.NomMateria = nomMateria;
            this.Semestre = semestre;   
        }
    }
}
