using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoCartucheraCostosa(object obj,EventArgs ar);

    public class Cartuchera<T> where T: Utiles
    {
        protected int cantidad;
        protected List<T> elementos;

        public event DelegadoCartucheraCostosa EventoPrecio;

        public List<T> Elementos
        {
            get { return this.elementos; }
        }

        public double PrecioTotal
        {
            get
            {
                double acumulado = 0;

                foreach (T item in this.elementos)
                {
                    acumulado += ((Utiles)item).precio;
                }
                return acumulado;
            }
        }

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int cantidad):this()
        {
            this.cantidad = cantidad;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CARTUCHERA DE :{0}",typeof(T).Name);
            sb.AppendLine();
            sb.AppendFormat("CAPACIDAD DE ELEM:{0}   CANTIDAD ACTUAL DE ELEM:{1}   PRECIO TOTAL:{2}",this.cantidad,this.elementos.Count,this.PrecioTotal);
            foreach (T item in this.elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();

        }

        public static Cartuchera<T> operator +(Cartuchera<T> c,T u)
        {
            if (c.elementos.Count < c.cantidad)
            {
                c.elementos.Add(u);
            }
            else
            {
                throw new CartucheraLlenaException();
            }

            if (c.EventoPrecio != null && c.PrecioTotal > 85)
            {
                c.EventoPrecio.Invoke(c,EventArgs.Empty);
            }

            return c;
        }
    }
}
