using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Clase derivada de Vehiculo.
    public class Auto : Vehiculo
    {
        #region Atributos
        private ETipo tipo;
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor de instancia de la clase Auto.
        /// </summary>
        /// <param name="modelo">Modelo del vehículo.</param>
        /// <param name="precio">Precio del vehículo.</param>
        /// <param name="fabri">Fabricante del auto.</param>
        /// <param name="tipo">Enumerado que asigna el tipo de vehículo.</param>
        public Auto(string modelo,float precio,Fabricante fabri,ETipo tipo):base(precio,modelo,fabri)
        {
            this.tipo = tipo;
        }

        #endregion


        #region Sobrecargas de operadores
        /// <summary>
        /// Sobrecarga que retorna el precio del auto.
        /// </summary>
        /// <param name="a">Auto del cual se obtiene su precio.</param>
        public static explicit operator float(Auto a)
        {
            return a.precio;
        }

        /// <summary>
        /// Sobrecarga del operador == que determina si dos autos son iguales.
        /// </summary>
        /// <param name="a">Auto a comparar.</param>
        /// <param name="b">Auto a comparar.</param>
        /// <returns>Retorna true los vehículos son iguales y los autos son del mismo tipo.</returns>
        public static bool operator ==(Auto a,Auto b)
        {
            return ((Vehiculo)a) == ((Vehiculo)b) && a.tipo == b.tipo;
        }

        /// <summary>
        /// Sobrecarga del operador != que determina si dos autos son distintos.Invoca a la sobrecarga del ==.
        /// </summary>
        /// <param name="a">Auto a comparar.</param>
        /// <param name="b">Auto a comparar.</param>
        /// <returns>True si los autos son distintos.</returns>
        public static bool operator !=(Auto a,Auto b)
        {
            return !(a == b);
        }

        #endregion


        #region Sobreescritura de métodos
        /// <summary>
        /// Sobreescritura del Equals que determina si dos autos son iguales.Invoca a la sobrecarga ==.
        /// </summary>
        /// <param name="obj">Objeto a comparar(si es de tipo Auto)</param>
        /// <returns>True si es Auto y si es igual al objeto que instancia al equals.</returns>
        public override bool Equals(object obj)
        {
            bool respuesta = false;

            if (obj is Auto)
            {
                respuesta = this == (Auto)obj;
            }

            return respuesta;
        }


        /// <summary>
        /// Sobreescritura del ToString para obtener el estado del auto.
        /// </summary>
        /// <returns>Cadena de carateres que representa el estado del auto.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine((string)this);
            sb.AppendFormat("TIPO:{0}",this.tipo.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        #endregion
    }
}
