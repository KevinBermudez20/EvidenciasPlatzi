
using System;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;

            var engine = new EscuelaEngine();
            engine.Inicializar();

            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");


            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsig = reporteador.GetListaAsignaturas();

            var listaEvalXAsig = reporteador.GetDicEvaluaXAsig();

            var listaprome = reporteador.GetPromeAlumnXAsig();

            Printer.WriteTitle("Captura de una Evaluacion por consola");
            var newEval = new Evaluación();
            string Nombre, NotaString;
            float Nota;

            Printer.WriteTitle("Ingrese el nombre de la Evaluacion");
            Printer.PresioneEnter();
            Nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new ArgumentException("El valor del nombre no puede estar vacio");
            }
            else
            {
                newEval.Nombre = Nombre.ToLower();
                WriteLine("El nombre de la evaluacion ha sido ingresado correctamente");
            }
            Printer.DrawLine();

            Printer.WriteTitle("Ingrese la nota de la Evaluacion");
            Printer.PresioneEnter();
            NotaString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(NotaString))
            {
                throw new ArgumentException("El valor de nota no puede estar vacio");
            }
            else
            {
                newEval.Nota = float.Parse(NotaString);
                WriteLine("El valor de nota de la evaluacion ha sido ingresado correctamente");
            }

        }

        private static void AccionDelEvento(object? sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo.....");
            Printer.Pitar(659, 250, 2); //mi
            Printer.Pitar(659, 500, 1);
            Printer.Pitar(659, 250, 2);
            Printer.Pitar(659, 500, 1);
            Printer.Pitar(659, 250, 1);//mi
            Printer.Pitar(784, 250, 1);//sol
            Printer.Pitar(523, 250, 1);//do
            Printer.Pitar(587, 250, 1);//re
            Printer.Pitar(659, 1000, 1);//mi

            Printer.Pitar(698, 250, 4);//fa
            Printer.Pitar(659, 250, 4);
            Printer.Pitar(587, 250, 3);//re
            Printer.Pitar(659, 250, 1);//mi
            Printer.Pitar(587, 500, 1);//re
            Printer.Pitar(784, 500, 1);//sol

            Printer.Pitar(659, 250, 2); //mi
            Printer.Pitar(659, 500, 1);
            Printer.Pitar(659, 250, 2);
            Printer.Pitar(659, 500, 1);
            Printer.Pitar(659, 250, 1);//mi
            Printer.Pitar(784, 250, 1);//sol
            Printer.Pitar(523, 250, 1);//do
            Printer.Pitar(587, 250, 1);//re
            Printer.Pitar(659, 1000, 1);//mi

            Printer.Pitar(698, 250, 4);//fa
            Printer.Pitar(659, 250, 4);
            Printer.Pitar(784, 250, 2);//sol
            Printer.Pitar(698, 250, 1);//fa
            Printer.Pitar(587, 250, 1);//re
            Printer.Pitar(523, 500, 1);//do


            Printer.Pitar(392, 250, 1);//sol
            Printer.Pitar(440, 500, 1);//la
            Printer.Pitar(392, 250, 1);//sol
            Printer.Pitar(329, 500, 1);//mi
            Printer.Pitar(523, 500, 1);//do2
            Printer.Pitar(440, 500, 1);//la
            Printer.Pitar(392, 1000, 1);//sol

            Printer.Pitar(392, 250, 1);//sol
            Printer.Pitar(440, 250, 1);//la
            Printer.Pitar(392, 250, 1);//sol
            Printer.Pitar(440, 250, 1);//la
            Printer.Pitar(392, 500, 1);//sol
            Printer.Pitar(523, 500, 1);//do2
            Printer.Pitar(493, 750, 1);//si











            Printer.WriteTitle("salio");
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueID}");
                }
            }

        }


    }
}
