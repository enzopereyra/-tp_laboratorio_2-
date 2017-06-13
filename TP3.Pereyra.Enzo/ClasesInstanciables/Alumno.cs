using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Enumerado

        public enum EEstadoCuenta
        {
            Deudor,
            AlDia,
            Becado
        }

        #endregion

        #region Constructores

        public Alumno()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine(base.MostrarDatos());
            texto.AppendLine("Estado cuenta: " + this._estadoCuenta);
            texto.AppendLine(this.ParticiparEnClase());

            return texto.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }

        #endregion

        #region Sobrecargas

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if ((a._claseQueToma == clase) && (a._estadoCuenta != EEstadoCuenta.Deudor))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion
        
    }
}
