using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter textoGuardar = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo, true))
                {
                    textoGuardar.Write(datos);
                    retorno = true;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamReader textoLeer = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo, Encoding.UTF8))
                {
                    datos = textoLeer.ReadToEnd();
                    retorno = true;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = "";
            }

            return retorno;
        }
    }
}
