using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        #region Atributos
        private string marca;
        private EPais pais;
        #endregion



        #region Constructores
        /// <summary>
        /// Constructor de instancia para crear un Fabricante.
        /// </summary>
        /// <param name="marca">Cadena de caracteres que representa la marca del fabricante.</param>
        /// <param name="pais">Enumerado que representa el pais de origen del fabricante.</param>
        public Fabricante(string marca,EPais pais)
        {
            this.marca = marca;
            this.pais = pais;
        }
        #endregion



        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga que retorna los valores del fabricante al recibir un objeto de este tipo
        /// </summary>
        /// <param name="f">Fabricante a mostrar</param>
        public static implicit operator string(Fabricante f)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("FABRICANTE: {0} - {1}",f.marca,f.pais.ToString());

            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga del operador que permite comparar dos fabricantes.Son iguales si ambos son null o si
        /// poseen la misma marca y el pais de origen.
        /// </summary>
        /// <param name="a">Objeto a fabricar.</param>
        /// <param name="b">Objeto a fabricar.</param>
        /// <returns>True si son null o si tienen el mismo valor en sus atributos.</returns>
        public static bool operator ==(Fabricante a,Fabricante b)
        {
            bool respuesta = false;

            if (((object)a) == null && ((object)b) == null)
            {
                respuesta = true;
            }
            else if (((object)a) != null && ((object)b) != null && a.marca == b.marca && a.pais == b.pais)
            {
                respuesta = true;
            }

            return respuesta;
        }


        /// <summary>
        /// Sobrecarga que evalua si dos fabricantes no son iguales.Se basa en la sobrecarga del operador ==.
        /// </summary>
        /// <param name="a">Objeto a fabricar.</param>
        /// <param name="b">Objeto a fabricar.</param>
        /// <returns>True si los fabricantes no son iguales.</returns>
        public static bool operator !=(Fabricante a,Fabricante b)
        {
            return !(a == b);
        }
        #endregion
    }
}
