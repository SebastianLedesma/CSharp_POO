using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEjercicio
{
    //Clase generic que recibe un parámetro.
    public class Deposito<T>
    {
        #region Atributos
        private int capacidadMaxima;
        private List<T> lista;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de instancia de la clase generic Depósito.
        /// </summary>
        /// <param name="capacidad">Cantidad máxima de elementos que se guardarán en el depósito.</param>
        public Deposito(int capacidad)
        {
            this.capacidadMaxima = capacidad;
            this.lista = new List<T>();
        }
        #endregion


        #region Métodos
        /// <summary>
        /// Método que retorna el índice del objeto a buscar.
        /// </summary>
        /// <param name="a">Objeto a buscar.</param>
        /// <returns>Retorna el índice de la posición del objeto o -1 si no lo encontró.</returns>
        private int GetIndice(T a)
        {
            int indice = -1;
            int contador = 0;

            foreach (T item in this.lista)
            {
                if (item.Equals(a))
                {
                    indice = contador;
                    break;
                }
                contador++;
            }
            return indice;
        }

        /// <summary>
        /// Método que agregar un objeto a la lista del depósito.
        /// </summary>
        /// <param name="o">Objeto a agregar.</param>
        /// <returns>True si se agrego el objeto al deposito.</returns>
        public bool Agregar(T o)
        {
            return this + o;
        }

        /// <summary>
        /// Método que quita un elemento de la lista del depósito.
        /// </summary>
        /// <param name="o">Objeto a eliminar.</param>
        /// <returns>True si se pudo eliminar el objeto de la lista del depósito.</returns>
        public bool Remover(T o)
        {
            return this - o;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador + que permite agregar un objeto a la lista del mismo tipo siempre que no esta no esté completa.
        /// </summary>
        /// <param name="d">Depósito que  contiene la lista.</param>
        /// <param name="o">Objeto a agregar.</param>
        /// <returns>True si se pudo agregar el objeto a la lista.</returns>
        public static bool operator +(Deposito<T> d,T o)
        {
            bool respuesta = false;

            if (d.lista.Count < d.capacidadMaxima)
            {
                d.lista.Add(o);
                respuesta = true;
            }
            return respuesta;
        }


        /// <summary>
        /// Sobrecarga del operador - que quita un elemento de la lista.
        /// </summary>
        /// <param name="d">Depósito que contiene la lista de elementos.</param>
        /// <param name="o">Objeto a elimninar.</param>
        /// <returns>True si pudo eliminar el objeto de la lista.</returns>
        public static bool operator -(Deposito<T> d,T o)
        {
            bool respuesta = false;
            int indice;

            indice = d.GetIndice(o);

            if (indice != -1)
            {
                d.lista.RemoveAt(indice);
                respuesta = true;
            }
            return respuesta;
        }
        #endregion


        #region Sobreescritura
        /// <summary>
        /// Sobreescritura del método ToString que retornar el estado del depósito de objetos.
        /// </summary>
        /// <returns>Cadena con los valores de los atributos del depósito.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad máxima: {0}\n",this.capacidadMaxima);
            sb.AppendFormat("Listado de {0}:\n",typeof(T).Name);

            foreach (T item in this.lista)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
