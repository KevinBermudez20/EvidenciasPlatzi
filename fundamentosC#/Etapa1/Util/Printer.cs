using static System.Console;


namespace CoreEscuela.Util

{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            
           WriteLine("".PadLeft(tam,'=')); 
        }

        public static void WriteTitle(string titulo)
        {
            DrawLine(titulo.Length+4);
            WriteLine($"| {titulo} |");
            DrawLine(titulo.Length+4);
        }
        public static void Pitar(int hz=2000, int tiempo=500, int cantidad =1)
        {
            while (cantidad-->0)
            {
                Beep(hz,tiempo);
                
            }
        }
        public static void PresioneEnter()
        {
            WriteLine("Presione ENTER para continuar");
        }
    }
}