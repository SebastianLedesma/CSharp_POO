using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericEjercicio
{
    public class DepositoDeAutos
    {
        #region Atributos
        private int capacidadMaxima;
        private List<Auto> lista;
        #endregion

        #region Constructor
        public DepositoDeAutos(int capacidad)
        {
            this.capacidadMaxima = capacidad;
            this.lista = new List<Auto>();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador + que permite agregar un auto al deposito de autos.
        /// </summary>
        /// <param name="d">Deposito que contiene la lista de autos.</param>
        /// <param name="a">Auto que se agraegará a lista siempre que no se supere la capaciadad del deposito.</param>
        /// <returns>True si pudo agregar el auto a la lista.</returns>
        public static bool operator +(DepositoDeAutos d,Auto a)
        {
            bool respuesta = false;

            if (d.lista.Count < d.capacidadMaxima)
            {
                d.lista.Add(a);
                respuesta = true;
            }

            return respuesta;
        }

        /// <summary>
        /// Sobrecarga del operador - que elimina un auto de la lista siempre que este exista en la lista.
        /// </summary>
        /// <param name="d">Deposito que contiene la lista de autos.</param>
        /// <param name="a">Auto a eliminar de la lista.</param>
        /// <returns>True si pudo quitar el auto de la lista.</returns>
        public static bool operator -(DepositoDeAutos d, Auto a)
        {
            bool respuesta = false;
            int indice;

            if (a != null)
            {
                indice = d.GetIndice(a);

                if (indice != -1)
                {
                    d.lista.RemoveAt(indice);
                    respuesta = true;
                }
            }

            return respuesta;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que busca un auto en la lista.
        /// </summary>
        /// <param name="a">Auto a buscar en la lista del depósito.</param>
        /// <returns>Retorna el índice donde se encuentra el auto o -1 si no lo encontró.</returns>
        private int GetIndice(Auto a)
        {
            int indice = -1;
            int contador = 0;

            foreach (Auto item in this.lista)
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
        /// Método que permite agregar un auto al deposito.Invoca a la sobrecarga del +.
        /// </summary>
        /// <param name="a">Auto a agregar.</param>
        /// <returns>True si pudo agregar el auto.</returns>
        public bool Agregar(Auto a)
        {
            return this + a;
        }


        /// <summary>
        /// Método que permite quitar un auto de la lista.Invoca a la sobrecarga -.
        /// </summary>
        /// <param name="a">Auto a eliminar de la lista.</param>
        /// <returns>True si pudo quitar el auto.</returns>
        public bool Remover(Auto a)
        {
            return this - a;
        }
        #endregion

        #region Sbreescritura
        /// <summary>
        /// Sobreescritura del método ToString que retorna el estado del depósito.
        /// </summary>
        /// <returns>Cadena con los valores de los atributos del deósito.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad: {0}\n",this.capacidadMaxima);
            sb.AppendFormat("Listado de Autos:\n");

            foreach  (Auto item in this.lista)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
