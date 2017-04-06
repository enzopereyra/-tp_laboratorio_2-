using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numero;

namespace Calculadora
{
    public class Calculadora
    {
        #region Metodos

        #region De Clase

        /// <summary>
        /// Metodo de clase para efectuar la operación entre dos números.
        /// </summary>
        /// <param name="numero1">Parametro uno para hacer la operación.</param>
        /// <param name="numero2">Parametro dos para hacer la operación.</param>
        /// <param name="operador">Simbolo de la operación.</param>
        /// <returns>El resultado de la operación.</returns>
        public static double operar(Numero.Numero numero1, Numero.Numero numero2, string operador)
        {
            double resultado = 0;

            switch (Calculadora.validarOperador(operador))
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;

                case "-":
                    resultado = numero1 - numero2;
                    break;

                case "*":
                    resultado = numero1 * numero2;
                    break;

                case "/":
                    resultado = numero1 / numero2;
                    break;

                default:
                    resultado = numero1 + numero2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Metodo de clase para validar el simbolo de la operación.
        /// </summary>
        /// <param name="operador">Simbolo de la operación</param>
        /// <returns>Simbolo validado,</returns>
        public static string validarOperador(string operador)
        {
            string operadorValido;

            switch (operador)
            {
                case "+":
                    operadorValido = "+";
                    break;

                case "-":
                    operadorValido = "-";
                    break;

                case "*":
                    operadorValido = "*";
                    break;

                case "/":
                    operadorValido = "/";
                    break;

                default:
                    operadorValido = "+";
                    break;
            }

            return operadorValido;
        }

        #endregion

        #endregion
    }
}
