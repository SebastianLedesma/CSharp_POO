using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Clase derivada de Vehiculo
    public class Moto : Vehiculo
    {
        #region Atributos
        private ECilindrada cilindrada;
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor de instancia de la clase Moto.
        /// </summary>
        /// <param name="marca">Marca del fabricante.</param>
        /// <param name="pais">País del origen del fabricante.</param>
        /// <param name="modelo">Modelo del vehículo.</param>
        /// <param name="precio">Precio del vehículo.</param>
        /// <param name="cilindrada">Cilindrada de la moto.</param>
        public Moto(string marca,EPais pais,string modelo,float precio,ECilindrada cilindrada)
            :base(precio,modelo,new Fabricante(marca,pais))
        {
            this.cilindrada = cilindrada;
        }

        #endregion


        #region Sobrecarga de operadores
        /// <summary>
        /// Sorbecarga del operador == que determina si dos motos son iguales.
        /// </summary>
        /// <param name="a">Moto a comparar.</param>
        /// <param name="b">Moto a comparar.</param>
        /// <returns>True si los vehículos son iguales y tienen la misma cilindrada.</returns>
        public static bool operator ==(Moto a,Moto b)
        {
            return ((Vehiculo)a) == ((Vehiculo)b) && a.cilindrada == b.cilindrada;
        }


        /// <summary>
        /// Sobrecarga del operador != que determina si dos motos son distintas.
        /// </summary>
        /// <param name="a">Moto a comparar.</param>
        /// <param name="b">Moto a comparar.</param>
        /// <returns>True si las motos son distintas.</returns>
        public static bool operator !=(Moto a,Moto b)
        {
            return !(a == b);
        }


        /// <summary>
        /// Sobrecarga que retorna el precio de la moto.
        /// </summary>
        /// <param name="a">Moto de la cual se obtiene su precio.</param>
        public static implicit operator float(Moto a)
        {
            return a.precio;
        }

        #endregion


        #region Sobreescritura de métodos
        /// <summary>
        /// Sobreescritura del equals que determina si dos motos son iguales.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True si el objeto es de tipo Moto y este es igual al objeto que instancia el equals.</returns>
        public override bool Equals(object obj)
        {
            bool respuesta = false;

            if (obj is Moto)
            {
                respuesta = this == (Moto)obj;
            }

            return respuesta;
        }


        /// <summary>
        /// Sobreescritura del ToString que retorna el estado de la moto.
        /// </summary>
        /// <returns>Retorna una cadena de caracteres que representa el estado de la moto.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine((string)this);
            sb.AppendFormat("CILINDRADA: {0}",this.cilindrada);
            sb.AppendLine();

            return sb.ToString();

        }

        #endregion
    }
}
