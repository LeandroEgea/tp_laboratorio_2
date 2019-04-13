using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            //TODO dividir entre 0
            if (operador.Equals("/") && num2.Equals(null))//TODO
            {
                return double.MinValue;
            }
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
            }
            return 0;
        }

        private static string ValidarOperador(string operador)
        {
            if (operador.Equals("-") || operador.Equals("/") || operador.Equals("*"))
                return operador;
            return "+";
        }
    }
}
