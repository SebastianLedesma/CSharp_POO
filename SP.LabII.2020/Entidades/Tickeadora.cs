using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Tickeadora
    {
        public static bool ImprimirTicket(string ruta,string contenido)
        {
            bool respuesta = false;

            try
            {
                using (StreamWriter escritor = new StreamWriter(ruta,true,Encoding.UTF8))
                {
                    escritor.WriteLine(contenido);
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
            }

            return respuesta;
        }
    }
}
