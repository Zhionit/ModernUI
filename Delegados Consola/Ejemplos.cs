using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegados
{
    class Ejemplos
    {
        public void EjemploDelegado()
        {
            ClienteDelegado clienteDelegado = new ClienteDelegado();
            clienteDelegado.DireccionDeMetodo = Escribe;
            clienteDelegado.DireccionDeMetodo += Escribe2;

            Console.WriteLine(clienteDelegado.Divide(4, 0));
            Console.WriteLine(clienteDelegado.DireccionDeMetodo);
        }

        public void EjemploDelegadoAnonimo()
        {
            ClienteDelegado clienteDelegado = new ClienteDelegado();
            clienteDelegado.DireccionDeMetodo = delegate(String mensaje)
                                                {
                                                    Console.WriteLine("Desde el delegado Anónimo: {0}", mensaje);
                                                };
            Console.WriteLine(clienteDelegado.Divide(4, 0));
        }

        public void EjemploOperadorLambda()
        {
            ClienteDelegado clienteDelegado = new ClienteDelegado();
            clienteDelegado.DireccionDeMetodo = (mensaje) =>
            {
                Console.WriteLine("Desde Operador Lambda '=>' : {0}", mensaje);
            };
            Console.WriteLine(clienteDelegado.Divide(4, 0));
        }

        public void EjemploOperadorLambdaConUnaExpresion()
        {
            ClienteDelegado clienteDelegado = new ClienteDelegado();
            clienteDelegado.DireccionDeMetodo = mensaje => Console.WriteLine("Desde Operador Lambda con una xpresión '=>' : {0}", mensaje);
            
            Console.WriteLine(clienteDelegado.Divide(4, 0));
        }

        public void EjemploDelegadoPersonalizado()
        {
            ClienteDelegado clienteDelegado = new ClienteDelegado();
            
            Console.WriteLine(clienteDelegado.Divide(4, 0, Escribe));
        }

        public void EjemploDelegadoPersonalizadoConFunc()
        {
            ClienteDelegado clienteDelegado = new ClienteDelegado();

            Func<string, bool> direccion = ErrorDivision;

            Console.WriteLine(clienteDelegado.DivideConFunc(4, 0, direccion));
        }

        void Escribe(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        void Escribe2(string mensaje)
        {
            Console.WriteLine("Desde escribe 2 {0}", mensaje, (mensaje + " ----2"));
        }

        bool ErrorDivision(string mensaje)
        {
            Console.WriteLine(mensaje);
            return true;
        }

    }
}
