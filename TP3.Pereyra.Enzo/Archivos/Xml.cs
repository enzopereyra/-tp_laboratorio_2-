using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serealizacion = new XmlSerializer(typeof (T));

                using(XmlTextWriter textoGuardar = new XmlTextWriter(AppDomain.CurrentDomain.BaseDirectory + archivo,Encoding.UTF8))
                {
                    serealizacion.Serialize(textoGuardar, datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serealizacion = new XmlSerializer(typeof(T));

                using(XmlTextReader textoLeer = new XmlTextReader(AppDomain.CurrentDomain.BaseDirectory + archivo))
                {
                    datos = (T)serealizacion.Deserialize(textoLeer);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(T);
            }

            return retorno;
        }
    }
}
