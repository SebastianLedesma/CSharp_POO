using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Goma:Utiles
    {
        public bool soloLapiz;

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        public Goma(bool soloLapiz,string marca,double precio):base(marca,precio)
        {
            this.soloLapiz = soloLapiz;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.UtilesToString());
            sb.AppendLine();
            sb.AppendFormat("SOLO LAPIZ:{0}",this.soloLapiz);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
