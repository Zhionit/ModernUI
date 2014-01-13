using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegados
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejemplos ejemplo = new Ejemplos();

            ejemplo.EjemploDelegadoPersonalizadoConFunc();

            Console.WriteLine("Presiona <Enter> Para terminar.");
            Console.ReadLine();
        }
    }
}
