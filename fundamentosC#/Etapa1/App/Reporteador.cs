using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
                throw new ArgumentNullException(nameof(dicObjEsc));

            _diccionario = dicObjEsc;

        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {

            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>();
            }
            {
                return new List<Evaluación>();
            }


        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluación> ListaEvaluaciones)
        {

            ListaEvaluaciones = GetListaEvaluaciones();

            return (from ev in ListaEvaluaciones

                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluación>> GetDicEvaluaXAsig()
        {
            var diccionario = new Dictionary<string, IEnumerable<Evaluación>>();

            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;
                diccionario.Add(asig, evalsAsig);
            }

            return diccionario;
        }

        public Dictionary<string, IEnumerable<object>> GetPromeAlumnXAsig()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDicEvaluaXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promedioAlumnos = from eval in asigConEval.Value
                                      group eval by new { eval.Alumno.UniqueID, eval.Alumno.Nombre }
                                      into grupoEvalsAlumno
                                      select new AlumnoPromedio
                                      {
                                          alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                          alumnoId = grupoEvalsAlumno.Key.UniqueID,
                                          promedio = grupoEvalsAlumno.Average(ev => ev.Nota)
                                      };
                rta.Add(asigConEval.Key, promedioAlumnos);
            }
            return rta;
        }
    }
}