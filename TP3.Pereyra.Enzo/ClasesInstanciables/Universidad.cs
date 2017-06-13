using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesor;

        #endregion

        #region Enumerados

        public enum EClases
        {
            Laboratorio,
            Legislacion,
            Programacion,
            SPD
        }

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesor; }
            set { }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { }
        }

        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        #endregion

        #region Contructores

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesor = new List<Profesor>();
        }

        #endregion

        #region Metodos

        public static bool Guardar(Universidad gim)
        {
            bool retorno = false;
            Xml<Universidad> claseXml = new Xml<Universidad>();

            if (claseXml.Guardar("ArchivoXml.xml", gim))
                retorno = true;

            return retorno;
        }

        public static Universidad Leer()
        {
            Universidad gim = new Universidad();
            Xml<Universidad> claseXml = new Xml<Universidad>();

            claseXml.Leer("ArchivoXml.xml", out gim);
            

            return gim;
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder texto = new StringBuilder();

            foreach (Alumno item in gim.alumnos)
            {
                texto.AppendLine(item.ToString());
            }

            foreach (Jornada item in gim.jornada)
            {
                texto.AppendLine(item.ToString());
            }

            foreach (Profesor item in gim.profesor)
            {
                texto.AppendLine(item.ToString());
            }

            return texto.ToString();
        }

        #endregion

        #region Sobrecargas

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.alumnos.Contains(a);
        }

        public static bool operator !=(Universidad g, Alumno a)
        { 
            return !(g == a); 
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            try
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item == clase)
                    {
                        return item;
                    }
                }
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            try
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item != clase)
                    {
                        return item;
                    }
                }
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.profesor.Contains(i);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }

            return g;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = (g == clase);

            //Jornada j = new Jornada(clase, p);

            Jornada j = null;
            
            if (!(Object.Equals(p, null)))
            {
                j = new Jornada(clase, p);
            }
           
            if (!(Object.Equals(j, null)))
            {
                foreach (Alumno item in g.Alumnos)
                {
                    if (item == clase)
                    {
                        j = j + item;
                    }
                }

                g.Jornadas.Add(j);
            }

            return g; 
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesor.Add(i);
            }

            return g;
        }

        #endregion
    }
}
