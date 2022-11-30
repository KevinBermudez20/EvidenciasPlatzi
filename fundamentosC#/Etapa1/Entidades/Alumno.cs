using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreEscuela.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        

        public List<Evaluación> Evaluaciones { get; set; }

         public Alumno()
    {
        Evaluaciones = new List<Evaluación>();
    }
    }
}