using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.Persistencia.Test
{
    public class Calculadora
    {
        public int Fatorial(int numero)
        {
            if (numero ==0)
            {
                return 1;
            }
            return numero * Fatorial(numero - 1);
            /*
            int aux = 0;
            int resultado = 0;
            int numero2 = numero;
            for (int i = 0; i < numero; i++)
            {
                aux = numero2-1;
                resultado += numero *aux ;
                numero2--;
            }
            return resultado;*/
        }
    }
}
