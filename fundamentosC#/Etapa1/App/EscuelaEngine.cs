using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        /* public EscuelaEngine()
        {

        } */

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic, bool imprEv = false)
        {
            foreach (var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());

                if (!imprEv && obj.Key == LlaveDiccionario.Evaluacion)
                {
                    Console.WriteLine("No se imprimieron las evaluaciones por defecto");
                }


                foreach (var valor in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if (imprEv)
                                Console.WriteLine(valor);
                            break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine("Escuela: " + valor);
                            break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine("Alumno: " + valor.Nombre);
                            break;
                        case LlaveDiccionario.Curso:
                            var cursoTemporal = valor as Curso;
                            if (cursoTemporal != null)
                            {
                                int count = ((Curso)valor).Alumnos.Count;
                                Console.WriteLine("Curso: " + valor.Nombre + " Cantidad de alumnos: " + count);
                            }
                            break;
                        default:
                            Console.WriteLine(valor);
                            break;
                    }



                }
            }
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());


            var listatmpEv = new List<Evaluación>();
            var listatmpAl = new List<Alumno>();
            var listatmpAs = new List<Asignatura>();

            foreach (var curso in Escuela.Cursos)
            {
                listatmpAl.AddRange(curso.Alumnos);
                listatmpAs.AddRange(curso.Asignaturas);


                foreach (var alumno in curso.Alumnos)
                {
                    listatmpEv.AddRange(alumno.Evaluaciones);
                }
            }

            diccionario.Add(LlaveDiccionario.Evaluacion, listatmpEv.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignatura, listatmpAs.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listatmpAl.Cast<ObjetoEscuelaBase>());

            return diccionario;
        }

        public void Inicializar()
        {
            this.Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogotá");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();



        }



        #region GetObjetosEscuela Sobrecarga
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool TraeEvaluaciones = true,
            bool TraeAlumnos = true,
            bool TraeAsignaturas = true,
            bool TraeCursos = true
            )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            bool TraeEvaluaciones = true,
            bool TraeAlumnos = true,
            bool TraeAsignaturas = true,
            bool TraeCursos = true
            )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool TraeEvaluaciones = true,
            bool TraeAlumnos = true,
            bool TraeAsignaturas = true,
            bool TraeCursos = true
            )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            bool TraeEvaluaciones = true,
            bool TraeAlumnos = true,
            bool TraeAsignaturas = true,
            bool TraeCursos = true
            )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool TraeEvaluaciones = true,
            bool TraeAlumnos = true,
            bool TraeAsignaturas = true,
            bool TraeCursos = true
            )
        {
            conteoEvaluaciones = 0;
            conteoAsignaturas = 0;
            conteoAlumnos = 0;
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if (TraeCursos)
                listaObj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                if (TraeAsignaturas)
                    conteoAsignaturas += curso.Asignaturas.Count;
                listaObj.AddRange(curso.Asignaturas);

                if (TraeAlumnos)
                    conteoAlumnos += curso.Alumnos.Count;
                listaObj.AddRange(curso.Alumnos);

                if (TraeEvaluaciones)
                {

                    foreach (var alumno in curso.Alumnos)
                    {
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                        listaObj.AddRange(alumno.Evaluaciones);
                    }
                }

            }





            return listaObj.AsReadOnly();
        }

        #endregion

        #region Metodos que cargan
        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var ListaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Educacion fisica"},
                    new Asignatura{Nombre="Castellanos"},
                    new Asignatura{Nombre="Ciencias naturales"},
                };
                curso.Asignaturas = ListaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Kevin", "Laura", "Farid", "Donald", "Alvaro" };
            string[] nombre2 = { "Mariana", "Valentina", "Luciana", "Salomon", "Daniel", "Mauricio" };
            string[] apellido1 = { "Ramos", "Bermudez", "Pacheco", "Murillo", "Moyano", "Torres" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy(alumno => alumno.UniqueID).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
            };

            foreach (var curso in Escuela.Cursos)
            {
                int cantRamdom = new Random().Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantRamdom);
            }
        }
        private void CargarEvaluaciones()
        {
            var rnd = new Random(System.Environment.TickCount);
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {


                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = MathF.Round(5 * (float)rnd.NextDouble(), 2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }
        #endregion
    }
}

