using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clNegocio;

namespace ConsoleAppPrueTecSolEstrategicas
{
    class Program
    {
        static void Main(string[] args)
        {
            string sCadIni = string.Empty;
            string res = string.Empty;
            Cadenas cCom = new Cadenas();

            do
            {
                Console.WriteLine("Por favor Ingrese la cadena a comprimir:");

                //read character from user input
                sCadIni = Console.ReadLine().ToString();

                Console.WriteLine("Ingreso: " + sCadIni);

            } while (sCadIni.Length == 0);

            res = cCom.ComprimirBasico(sCadIni);
            Console.WriteLine("Resultado de aplicar a " + sCadIni +  " la compresión básica: " + res);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

            Console.WriteLine("Otras pruebas...");
            sCadIni = "aabcccccaaa";
            res = cCom.ComprimirBasico(sCadIni);
            Console.WriteLine("Resultado de aplicar a " + sCadIni + " la compresión básica: " + res);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

            Console.WriteLine("Otras pruebas...");
            sCadIni = "abccccca";
            res = cCom.ComprimirBasico(sCadIni);
            Console.WriteLine("Resultado de aplicar a " + sCadIni + " la compresión básica: " + res);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

            Console.WriteLine("Una mas...");
            sCadIni = "abcc";
            res = cCom.ComprimirBasico(sCadIni);
            Console.WriteLine("Resultado de aplicar a " + sCadIni + " la compresión básica: " + res);
            Console.WriteLine("Presione una tecla para **** TERMINAR ****");
            Console.ReadKey();

        }
    }
}
