using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Lapiz))]
    public abstract class Utiles
    {
        public string marca;
        public double precio;

        public abstract bool PreciosCuidados
        {
            get;
        }

        public Utiles()
        {
        }

        public Utiles(string marca,double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }

        protected virtual string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("MARCA:{0}  PRECIO:{1}",this.marca,this.precio);

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
