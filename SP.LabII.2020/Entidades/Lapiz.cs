using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public enum ETipoTrazo
    {
        Fino,
        Grueso,
        Medio
    }

    public class Lapiz : Utiles ,ISerializa,IDeserializa
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        public string Path
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\Ledesma.Ricardo.lapiz.xml"; }
        }

        public Lapiz()
            :base()
        {
        }

        public Lapiz(ConsoleColor color,ETipoTrazo trazo,string marca,double precio):base(marca,precio)
        {
            this.trazo = trazo;
            this.color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.UtilesToString());
            sb.AppendFormat("COLOR:{0}   TRAZO:{1}",this.color,this.trazo.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        public bool Xml()
        {
            bool respuesta = false;
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(this.Path,Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Lapiz));

                    ser.Serialize(escritor,this);
                }

                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }

        bool IDeserializa.Xml(out Lapiz aux)
        {
            bool respuesta = false;

            try
            {
                using (XmlTextReader lector =new XmlTextReader(this.Path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Lapiz));

                    aux = (Lapiz)ser.Deserialize(lector);
                }

                respuesta = true;
            }
            catch (Exception ex)
            {
                aux = null;
                respuesta = false;
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }
    }
}
