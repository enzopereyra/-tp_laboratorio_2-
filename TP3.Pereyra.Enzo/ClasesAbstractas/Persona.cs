using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos

        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        protected string _nombre;

        #endregion

        #region Enumerado

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Propiedades

        public string Apellido 
        {
            get { return this._apellido; }
            set {
                    if (this.ValidarNombreApellido(value) != null)
                    {
                        this._apellido = value;
                    } 
                }
        }
        public int DNI 
        { 
            get { return this._dni; } 
            set {
                    if (this.ValidarDni(this._nacionalidad, value) != 0)
                    {
                        this._dni = value; 
                    }
                } 
        }
        public ENacionalidad Nacionalidad 
        { 
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set {
                    if (this.ValidarNombreApellido(value) != null)
                    {
                        this._apellido = value;
                    }
                } 
        }
        public string StringToDNI
        {
            set
            {
                if (this.ValidarDni(this._nacionalidad, value) != 0)
                {
                    this._dni = int.Parse(value);
                }
            }
        }

        #endregion

        #region Constructores

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
            this._nombre = nombre;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;

            try
            {
                if (dato > 1 || dato < 89999999)
                {
                    if (nacionalidad == ENacionalidad.Argentino)
                    {
                        retorno = 1;
                    }
                    else
                    {
                        throw new Excepciones.DniInvalidoException("La nacionalidad no se condice con el número de DNI");
                    }

                }

                if ((nacionalidad == ENacionalidad.Extranjero) && (dato > 89999999))
                {
                    retorno = -1;
                }
            }
            catch(Excepciones.DniInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numero = int.Parse(dato);

            return this.ValidarDni(nacionalidad, numero);
        }

        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (dato[i] < 65 || dato[i] > 122 )
                {
                    return null;   
                }
            }

            return dato;
        }

        #endregion

        #region Sobrecargas

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            texto.AppendLine("NACIONALIDAD: " + this._nacionalidad);
            //texto.AppendLine("Dni: " + this._dni);

            return texto.ToString();
        }

        #endregion

    }
}
