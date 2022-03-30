using System;
using System.Linq;

namespace Sarabia_Santiago_EX2
{
    class MainClass
    {
        static string[] options =
        {
            "1.Dado el nombre de un director de carrera, mostrar los nombres de estudiantes que estudian esa carrera.",
            "2.Mostrar los nombres de estudiantes por cada materia.",
            "3.Mostrar el nombre de cada carrera junto a los nombres de sus respectivos estudiantes",
            "4.Dado el nombre de una materia mostrar los nombres de estudiantes inscritos en ella.",
        };

        static Estudiante[] estudiantes ={
             new Estudiante(123,"Jose Costas","ISI",4),
             new Estudiante(234,"Carla Mendez","ISI",2),
             new Estudiante(345,"Lony Lopez","IBI",8),
             new Estudiante(456,"Elio Sierra","ISI",3),
             new Estudiante(567,"Jorge Andrade","IBI",8),
             new Estudiante(678,"Erika Herbas","IEL",5),
             new Estudiante(789,"Marco Ignacio","ISI",3),
             new Estudiante(890,"Jose Heredia","IBI",6),
             new Estudiante(901,"Ingrid Asis","IEL",5),
             new Estudiante(012,"Abel Illanes","MED",1),
        };

        static Carrera[] carreras = {
             new Carrera("ISI","Ingenieria de Sistemas Informáticos","DirISI"),
             new Carrera("IBI","Ingenieria Biomedica","DirIBI"),
             new Carrera("IEL","Ingenieria Electronica","DirIEL"),
             new Carrera("MED","Medicina","DirMED")
        };

        static Materia[] materias = {
             new Materia("PRO4","Programacion IV",4),
             new Materia("PRO3","Programacion III",3),
             new Materia("EDD","Estructura de datos",3),
             new Materia("CMP1","Computación",1),
             new Materia("CIR3","Circuitos III",5),
             new Materia("PRO1b","Programacion I",8),
             new Materia("CIR4","Circuitos IV",6),
             new Materia("PRO2","Programacion II",2),
             new Materia("PRO1a","Programacion I",1),
             new Materia("CAL2","Calculo II",2)
        };

        static Est_Mat[] estMaterias = {
             new Est_Mat(123,"PRO3"),
             new Est_Mat(123,"PRO4"),
             new Est_Mat(123,"EDD"),
             new Est_Mat(123,"CAL2"),
             new Est_Mat(234,"PRO1a"),
             new Est_Mat(234,"PRO2"),
             new Est_Mat(345,"PRO1b"),
             new Est_Mat(345,"CIR4"),
             new Est_Mat(456,"EDD"),
             new Est_Mat(456,"PRO2"),
             new Est_Mat(567,"PRO1b"),
             new Est_Mat(678,"CIR3"),
             new Est_Mat(678,"PRO4"),
             new Est_Mat(789,"EDD"),
             new Est_Mat(789,"PRO1a"),
             new Est_Mat(789,"CAL2"),
             new Est_Mat(890,"CIR4"),
             new Est_Mat(890,"PRO3"),
             new Est_Mat(901,"CIR3"),
             new Est_Mat(012,"CMP1")
        };


        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Escoja un inciso");
            foreach (string s in options) Console.WriteLine(s);
            int res = -1;
            bool valid = int.TryParse(Console.ReadLine(), out res);
            if (!valid || res < 1 || res > 4)
            {
                Console.Clear();
                Main(args);
                return;
            }

            Console.Clear();
            Console.WriteLine(options[res - 1]);
            switch (res)
            {
                case 1:
                    Exercise1();
                    break;
                case 2:
                    Exercise2();
                    break;
                case 3:
                    Exercise3();
                    break;
                case 4:
                    Exercise4();
                    break;
            }

            Console.WriteLine("Deseas salir de la ejecucuion? (y/n)");
            string ans = Console.ReadLine();
            if (ans.ToLower() != "y")
            {
                Console.Clear();
                Main(args);
            }
        }

        static void Exercise1()
        {
            Console.WriteLine("Posibles Directores: ");
            foreach (var c in carreras) Console.WriteLine(c.NomDirector);
            Console.WriteLine("Indica el nombre del director");
            string director = Console.ReadLine();
            if (Array.FindIndex(carreras, c => c.NomDirector.ToLower() == director.ToLower()) != -1)
            {
                var studentsTemp = from e in estudiantes
                                      join c in carreras on e.CodCarrera equals c.CodCarrera
                                      where c.NomDirector.ToLower() == director.ToLower()
                                      select e;

                foreach (var e in studentsTemp) Console.WriteLine("CI: " + e.CI + " | Nombre: " + e.NomEst);
            }
            else
            {
                Console.WriteLine("Director invalido.");
                Exercise2();
            }
        }

        static void Exercise2()
        {
            var groupedStudents = from e in estudiantes
                                  join em in estMaterias on e.CI equals em.CI
                                  join m in materias on em.IdMateria equals m.CodMateria
                                  group e by m.NomMateria
                                  ;
            foreach (var s in groupedStudents)
            {
                Console.WriteLine("Estudiantes agrupados por materia:" + s.Key + "\n");
                foreach (var e in s)
                    Console.WriteLine("CI: " + e.CI + " | Nombre: " + e.NomEst);
                Console.WriteLine("\n");
            }
        }

        static void Exercise3()
        {
            var groupedStudents = from e in estudiantes
                                  join c in carreras on e.CodCarrera equals c.CodCarrera
                                  group e by c.NomCarrera;     
            
            foreach (var s in groupedStudents)
            {
                Console.WriteLine("Estudiantes agrupados por carrera:" + s.Key + "\n");
                foreach (var e in s)
                    Console.WriteLine("CI: " + e.CI + " | Nombre: " + e.NomEst);
                Console.WriteLine("\n");
            }
        }

        static void Exercise4()
        {
            Console.WriteLine("Posibles Materias: ");
            foreach (var m in materias) Console.WriteLine(m.NomMateria);
            Console.WriteLine("Indica el nombre de la materia");
            string materia = Console.ReadLine();
            if (Array.FindIndex(materias, m => m.NomMateria.ToLower() == materia.ToLower()) != -1)
            {
                var studentsTemp = from e in estudiantes
                                   join em in estMaterias on e.CI equals em.CI
                                   join m in materias on em.IdMateria equals m.CodMateria
                                   where m.NomMateria.ToLower() == materia.ToLower()
                                   select e;
                Console.WriteLine("Materia: " + materia);
                foreach (var e in studentsTemp) Console.WriteLine("CI: " + e.CI + " | Nombre: " + e.NomEst);
            }
            else
            {
                Console.WriteLine("Materia invalida.");
                Exercise4();
            }
        }


    }
}