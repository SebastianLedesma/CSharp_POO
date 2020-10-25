using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEjercicio
{
    public class Cocina
    {
        #region Atributos
        private int codigo;
        private bool esIndustrial;
        private double precio;
        #endregion

        #region Propiedades
        //Retorna el atributo precio.
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        //Retorna el atributo esIndustrial.
        public bool EsIndustrial
        {
            get { return esIndustrial; }
        }

        //Retorna el código de la cocina.
        public int Codigo
        {
            get { return codigo; }
        }
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor de instancia de la clase Cocina.
        /// </summary>
        /// <param name="codigo">Código de la cocina.</param>
        /// <param name="precio">Precio de la cocina.</param>
        /// <param name="esIndustrial">Determina si es industrial o no.</param>
        public Cocina(int codigo,double precio,bool esIndustrial)
        {
            this.codigo = codigo;
            this.precio = precio;
            this.esIndustrial = esIndustrial;
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador ==.Determina si dos cocinas son iguales.
        /// </summary>
        /// <param name="a">Cocina a comparar.</param>
        /// <param name="b">Cocina a comparar.</param>
        /// <returns>True si las cocinas son iguales.</returns>
        public static bool operator ==(Cocina a,Cocina b)
        {
            bool respuesta = false;
            if ((object)a == null && (object)b == null)
            {
                respuesta = true;
            }
            else if ((object)a != null && (object)b != null && a.codigo == b.codigo && a.esIndustrial == b.esIndustrial && a.precio == b.precio)
            {
                respuesta = true;
            }

            return respuesta;
        }

        /// <summary>
        /// Sobrecarga del operador !=.Determina si 2 cocinas son diferentes.
        /// </summary>
        /// <param name="a">Cocina a comparar.</param>
        /// <param name="b">Cocina a comparar.</param>
        /// <returns>True si las cocinas diferentes.</returns>
        public static bool operator !=(Cocina a,Cocina b)
        {
            return !(a == b);
        }
        #endregion


        #region Sobreescritura
        /// <summary>
        /// Sobreescritura del Equals. Se comparan 2 objetos y se determina si son iguales.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True si las cocinas son iguales.</returns>
        public override bool Equals(object obj)
        {
            bool respuesta = false;

            if (obj is Cocina)
            {
                respuesta = this == (Cocina)obj;
            }

            return respuesta;
        }


        /// <summary>
        /// Sobreescritura del ToString que retorna el estado de la cocina.
        /// </summary>
        /// <returns>Cadena que contiene el valor de los atributos de la cocina.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Código: {0}  -  Precio. {1}  -  Es Industrial? {2}",this.codigo,this.precio,this.esIndustrial);

            return sb.ToString();
        }
        #endregion
    }
}
