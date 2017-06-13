using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        #endregion

        #region Contructores

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Metodos

        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto claseTexto = new Texto();

            if (claseTexto.Guardar(jornada.ToString(), "MiArchivo.txt"))
                retorno = true;

            return retorno;
        }

        public static string Leer()
        {
            string texto;
            Texto claseTexto = new Texto();

            claseTexto.Leer("ArchivoTexto.txt", out texto);
            
            return texto;
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Jornada j, Alumno a)
        {
            return j._alumnos.Contains(a);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }

            return j;
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("JORNADA:");
            texto.AppendLine(this._instructor.ToString());
            texto.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                texto.AppendLine(item.ToString());
            }

            return texto.ToString();
        }

        #endregion
    }
}
