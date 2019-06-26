using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza el calculo de dos numeros.
        /// </summary>
        /// <param name="num1">Primer argumento de la operacion</param>
        /// <param name="num2">Segundo argumento de la operacion</param>
        /// <param name="operador">Indica la operacion entre los numeros</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Valida que el operador sea (+ - * /) 
        /// </summary>
        /// <param name="operador">Operador que hay que validar</param>
        /// <returns>Retorna "operador" si es valido, si no "+"</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador.Equals("-") || operador.Equals("/") || operador.Equals("*"))
                return operador;
            return "+";
        }
    }
}
