using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clNegocio
{
    public class Cadenas
    {
        // Utilizando C#, implemente un método que ejecute una "compresión" básica de una cadena
        // utilizando el conteo de caracteres repetidos.
        // Por ejemplo, la cadena: "aabcccccaaa", se debe convertir en "a2b1c5a3".
        // Si la cadena "comprimida" no es más pequeña que la cadena original, 
        // el método debe devolver la cadena original.

        public string ComprimirBasico(string CadOri)
        {
            string resultado = string.Empty;
            char anterior;
            int contador = 0;

            if (CadOri != null)
            {
                if (CadOri.Length > 0)
                {
                    anterior = char.Parse(CadOri.Substring(0, 1));

                    foreach (char item in CadOri)
                    {
                        // Item = anterior incrementa contador sino inicializa contador
                        if (anterior == item)
                        {
                            contador++;
                        }
                        else
                        {
                            resultado = resultado + anterior + contador.ToString();
                            anterior = item;
                            contador = 1;
                        }
                    }

                    if (contador > 0)
                    {
                        resultado = resultado + anterior + contador.ToString();
                    }

                }

                if (resultado.Length > CadOri.Length)
                    resultado = CadOri;
            }



            return resultado;
        }
    }
}
