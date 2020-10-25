using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEjercicio
{
    public class Auto
    {
        #region Atributos
        private string color;
        private string marca;
        #endregion

        #region Propiedades
        //Retorna la marca del auto.
        public string Marca
        {
            get { return marca; }
        }

        //Retorna el colordel auto.
        public string Color
        {
            get { return color; }
        }

        #endregion


        #region Constructores
        /// <summary>
        /// Constructor de instancia de la clase auto
        /// </summary>
        /// <param name="color">Color del auto.</param>
        /// <param name="marca">Marca del auto.</param>
        public Auto(string color,string marca)
        {
            this.marca = marca;
            this.color = color;
        }

        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador == que compara 2 autos y determina si son iguales.
        /// </summary>
        /// <param name="a">Auto a comparar.</param>
        /// <param name="b">Auto a comparar.</param>
        /// <returns>True si ambos son null o si tienen la misma marca y color.</returns>
        public static bool operator ==(Auto a,Auto b)
        {
            bool respuesta = false;

            if ((object)a == null && (object)b == null)
            {
                respuesta = true;
            }
            else if ((object)a != null && (object)b != null && a.marca == b.marca && a.color == b.color)
            {
                respuesta = true;
            }

            return respuesta;
        }

        /// <summary>
        /// Sobrecarga del operador != que compara 2 autos y determina si son distintos.Invoca a la sobrecarga del ==.
        /// </summary>
        /// <param name="a">Auto a comparar.</param>
        /// <param name="b">Auto a comparar.</param>
        /// <returns>True si los autos son diferentes.</returns>
        public static bool operator !=(Auto a,Auto b)
        {
            return !(a == b);
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Sobreescritura del método Equals que determina si 2 obejtos son iguales(Auto).
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool respuesta = false;

            if (obj is Auto)
            {
                respuesta = this == (Auto)obj;//si es de tipo Auto invoca a la sobrecarga del ==.
            }

            return respuesta;
        }

        /// <summary>
        /// Sobreescritura del ToString que retorna el estado del obejto auto.
        /// </summary>
        /// <returns>Cadena que contiene los valores de los atributos del auto.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Marca: {0} - Color: {1}",this.marca,this.color);

            return sb.ToString();
        }
        #endregion
    }
}
