using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos

        protected int _legajo;

        #endregion

        #region Constructores

        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        #region Metodos

        protected virtual string MostrarDatos()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine(base.ToString());
            texto.AppendLine("LEGAJO NÚMERO: " + this._legajo);

            return texto.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        public override bool Equals(object obj)
        {
            if ((obj is Universitario) && (this == obj))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if ((pg1._nacionalidad == pg2._nacionalidad) && ((pg1._legajo == pg2._legajo) || (pg1._dni == pg2._dni)))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
