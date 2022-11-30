using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {



        public int AñoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }

        public string Direccion { get; set; }

        public Escuela(string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            this.Nombre = nombre;
            AñoDeCreacion = año;
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela");
            Printer.Pitar(15000,cantidad:3);
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            

            Printer.WriteTitle($"Escuela {Nombre} Limpia");
        }
    }
}