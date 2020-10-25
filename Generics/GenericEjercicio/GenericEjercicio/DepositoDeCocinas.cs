using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEjercicio
{
    public class DepositoDeCocinas
    {
        #region Atributos
        private int capacidaMaxima;
        private List<Cocina> lista;
        #endregion

        #region Constructores
        public DepositoDeCocinas(int capacidad)
        {
            this.capacidaMaxima = capacidad;
            this.lista = new List<Cocina>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que busca el indice donde se encuentra la cocina pasada por parámetro.
        /// </summary>
        /// <param name="c">Cocina a buscar en la lista.</param>
        /// <returns>Retorna el indice donde se encuentra la cocina o -1 si no está en la lista.</returns>
        private int GetIndice(Cocina c)
        {
            int indice = -1;
            int contador = 0;
            foreach (Cocina item in this.lista)
            {
                if (item.Equals(c))
                {
                    indice = contador;
                    break;
                }
                contador++;
            }

            return indice;
        }


        /// <summary>
        /// Método que agrega una cocina en la lista si no se supera la capacidad máxima.
        /// </summary>
        /// <param name="c">Cocina a agregar.</param>
        /// <returns>True si pudo agregar la cocina.</returns>
        public bool Agregar(Cocina c)
        {
            return this + c;
        }


        /// <summary>
        /// Método que quita una cocina de la lista.
        /// </summary>
        /// <param name="c">Cocina a quitar  de la lista.</param>
        /// <returns>True si pudo quitar la cociana de la lista.</returns>
        public bool Remover(Cocina c)
        {
            return this - c;
        }
        #endregion


        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga que agrega una cocina a la lista siempre que no se supere la capacidad máxima.
        /// </summary>
        /// <param name="d">Cocina que  contiene la lista.</param>
        /// <param name="c">Cocina a agregar.</param>
        /// <returns>True si pudo agregar la cocina.</returns>
        public static bool operator +(DepositoDeCocinas d,Cocina c)
        {
            bool respuesta = false;

            if (d.lista.Count < d.capacidaMaxima)
            {
                d.lista.Add(c);
                respuesta = true;
            }

            return respuesta;
        }


        /// <summary>
        /// Sobrecarga del operador - que quita una cocina de la lista.
        /// </summary>
        /// <param name="d">Cocina que contiene la lista.</param>
        /// <param name="c">Cocina a eliminar de la lista.</param>
        /// <returns>True si pudo quitar la cocina de la lista.</returns>
        public static bool operator -(DepositoDeCocinas d,Cocina c)
        {
            int indice;
            bool respuesta = false;

            indice = d.GetIndice(c);

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
        /// Sobreescritura del ToString para obtener el estado del deposito de cocinas.
        /// </summary>
        /// <returns>Cadena con los valores de los atributos del deposito de cocina.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad: {0}\n",this.capacidaMaxima);
            sb.AppendFormat("Listado de cocinas\n");

            foreach (Cocina item in this.lista)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
