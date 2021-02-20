using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sacapunta : Utiles
    {
        public bool deMetal;

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        public Sacapunta(bool deMetal,double precio,string marca):base(marca,precio)
        {
            this.deMetal = deMetal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.UtilesToString());
            sb.AppendLine();
            sb.AppendFormat("DE METAL:{0}",this.deMetal);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
