using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> _claseDelDia;
        private static Random _random;

        #endregion

        #region Contructores

        public Profesor()
        { }

        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
            this._randomClase();
        }

        #endregion

        #region Metodos

        protected override string ParticiparEnClase()
        {
            //Universidad.EClases[] _auxiliar = this._claseDelDia.ToArray();

            StringBuilder texto = new StringBuilder();

            //texto.AppendLine(_auxiliar[0].ToString());
            //texto.AppendLine(_auxiliar[1].ToString());
            foreach (Universidad.EClases item in this._claseDelDia)
            {
                texto.AppendLine(item.ToString());
            }

            return ("CLASES DEL DÍA " + texto.ToString());
            //return "";
        }

        private void _randomClase()
        {
            switch (Profesor._random.Next(4))
            {
                case 0:
                    this._claseDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 1:
                    this._claseDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 2:
                    this._claseDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case 3:
                    this._claseDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
                default:
                    break;
            }
        }

        protected override string MostrarDatos()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("CLASE DE: " + this._claseDelDia);
            texto.Append("POR NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            texto.AppendLine("NACIONALIDAD: " + this._nacionalidad);
            texto.AppendLine("LEGAJO NUMERO: " + this._legajo);
            texto.AppendLine(this.ParticiparEnClase().ToString());

            return texto.ToString();
        }

        #endregion

        #region Sobrecargas

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i._claseDelDia.Contains(clase); 
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
