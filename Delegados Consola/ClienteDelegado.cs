using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegados
{
    delegate void EscribeMensaje(String mensaje);

    class ClienteDelegado
    {

        public EscribeMensaje DireccionDeMetodo;

        public int Divide(int p1, int p2)
        {
            int c = 0;

            if (p2 == 0)
            {
                if (DireccionDeMetodo != null)
                {
                    DireccionDeMetodo("Dentro de divide: División por cero");
                }
            }
            else
            {
                c = p1 / p2;
            }
            
            return c;
        }

        // Dirección: Es un método conocido como callBack
        // Action es un delegado para métodos que retornan void 
        public int Divide(int p1, int p2, Action<String> direccion)
        {
            int c = 0;

            if (p2 == 0)
            {
                if (direccion != null)
                {
                    direccion("Dentro de divide: División por cero");
                }
            }
            else
            {
                c = p1 / p2;
            }

            return c;
        }

        public int DivideConFunc(int p1, int p2, Func<String, bool> direccion)
        {
            int c = 0;

            if (p2 == 0)
            {
                if (direccion != null)
                {
                    var resultado = direccion("Dentro de divide: División por cero");
                }
            }
            else
            {
                c = p1 / p2;
            }

            return c;
        }
     }
}
