using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarabia_Santiago_EX2
{
    public class Est_Mat
    {
        public int CI { get; set; }
        public string IdMateria { get; set; }

        public Est_Mat(int ci, string idMateria)
        {
            this.CI = ci;
            this.IdMateria = idMateria;
        }
    }
}
