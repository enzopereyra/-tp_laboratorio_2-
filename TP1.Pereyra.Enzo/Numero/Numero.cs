using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numero
{
    public class Numero
    {
        #region Atributos

        /// <summary>
        /// Atributo tipo double.
        /// </summary>
        private double numero;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de instancia por defecto.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="numero">Valor de asignacion para el atributo.</param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="numero">Valor de asignacion para el atributo.</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        #endregion

        #region Metodos

        #region De Clase

        /// <summary>
        /// Metodo de clase que valida una cadena y lo transforma en numero.
        /// </summary>
        /// <param name="numero">Cadena a validar.</param>
        /// <returns>Un double valido</returns>
        private static double validarNumero(string numero)
        {
            double numeroValido = 0;

            if (double.TryParse(numero, out numeroValido))
            {
                return numeroValido;
            }
            return numeroValido;
        }

        #endregion

        #region De Instancia

        /// <summary>
        /// Metodo de instancia para setear un número.
        /// </summary>
        /// <param name="numero">Guarda el número.</param>
        private void setNumero(string numero) 
        {
            this.numero = Numero.validarNumero(numero);
        }
        /// <summary>
        /// Metodo de instancia para obtener un número.
        /// </summary>
        /// <param name="numero">obtengo el número guardado</param>
        /// <returns>Número previamente guardado</returns>
        public double getNumero(string numero)
        {
            return this.numero;
        }

        #endregion

        #endregion

        #region Sobrecarga de operadores

        // Sobrecarga del operador "+".
        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.numero + numero2.numero;
        }

        // Sobrecarga del operador "-".
        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.numero - numero2.numero;
        }

        // Sobrecarga del operador "*".
        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.numero * numero2.numero;
        }

        // Sobrecarga del operador "/".
        public static double operator /(Numero numero1, Numero numero2)
        {
            if (numero2 == 0.0)
            {
                return 0.0;
            }

            return numero1.numero / numero2.numero;
        }

        // Sobrecarga del operador de comparación "==".
        public static bool operator ==(Numero numero, double cero)
        {
            if (numero.numero == cero)
            {
                return true;  
            }
            return false;
        }

        // Sobrecarga del operador de comparación "!=".
        public static bool operator !=(Numero numero, double cero)
        {
            return !(numero == cero);
        }

        #endregion
    }
}
