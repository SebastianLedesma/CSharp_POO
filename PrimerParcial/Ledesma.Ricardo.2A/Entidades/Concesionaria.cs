using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Clase que contiene objetos de tipo Vehiculo
    public class Concesionaria
    {
        #region Atributos
        private int capacidad;
        private List<Vehiculo> vehiculos;
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor que inicializa el atributo lista de vehículos.Solo es visible dentro de la clase.
        /// </summary>
        private Concesionaria()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Sobrecarga del constructor.
        /// </summary>
        /// <param name="cantidad">Representa la cantidad de vehiculos que puede tener la concesionaria.
        /// Solo es visible dentro de la clase.</param>
        private Concesionaria(int cantidad):this()
        {
            this.capacidad = cantidad;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna el total de precios los autos de la concesionaria.
        /// </summary>
        public double PrecioDeAutos
        {
            get { return this.ObtenerPrecio(EVehiculo.PrecioDeAutos); }
        }

        /// <summary>
        /// Retorna el total de precios de las motos de la concesionaria.
        /// </summary>
        public double PrecioDeMotos
        {
            get { return this.ObtenerPrecio(EVehiculo.PrecioDeMotos); }
        }

        /// <summary>
        /// Retorna el total de precios de los vehiculos de la concesionaria.
        /// </summary>
        public double PrecioTotal
        {
            get { return this.ObtenerPrecio(EVehiculo.PrecioTotal); }
        }

        #endregion


        #region Métodos
        /// <summary>
        /// Obtiene el total de precios de los vehiculos según el valor del enumerado recibido.
        /// </summary>
        /// <param name="tipoVehiculo">Valor del enumerado para filtrar la lista de vehículos.</param>
        /// <returns>Retorna el total de precios.</returns>
        private double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            double precioAcumulado = 0;

            foreach (Vehiculo item in this.vehiculos)
            {
                switch (tipoVehiculo)
                {
                    case EVehiculo.PrecioDeAutos:
                        if (item is Auto)
                        {
                            precioAcumulado += (float)(Auto)item;
                        }
                        break;
                    case EVehiculo.PrecioDeMotos:
                        if (item is Moto)
                        {
                            precioAcumulado += (Moto)item;
                        }
                        break;
                    case EVehiculo.PrecioTotal:
                        if (item is Auto)
                        {
                            precioAcumulado += (float)(Auto)item;
                        }
                        else
                        {
                            precioAcumulado += (Moto)item;
                        }
                        break;
                }
            }

            return precioAcumulado;
        }


        /// <summary>
        /// Retorna el estado de la concesionaria.
        /// </summary>
        /// <param name="c">Concesionaria para obtener el valor de sus atributos.</param>
        /// <returns>Cadena de caracteres que representa el estado de la concesionaria.</returns>
        public static string Mostrar(Concesionaria c)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad:{0}",c.capacidad);
            sb.AppendLine();
            sb.AppendFormat("Total por autos: {0}",c.PrecioDeAutos);
            sb.AppendLine();
            sb.AppendFormat("Total por motos: {0}", c.PrecioDeMotos);
            sb.AppendLine();
            sb.AppendFormat("Total: {0}\n", c.PrecioTotal);
            sb.AppendLine("************************\nListado de vehiculos\n********************");

            foreach (Vehiculo item in c.vehiculos)
            {
                if (item != null)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString();
        }

        #endregion


        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga que instancia una concesionaria al asignarle un int para el atributo cantidad.
        /// </summary>
        /// <param name="cantidad">Valor para asignarle al atributo cantidad.</param>
        public static implicit operator Concesionaria(int cantidad)
        {
            return new Concesionaria(cantidad);
        }


        /// <summary>
        /// Sobrecarga del == que busca un vehículo en la lista de vehículos de la concesionaria.
        /// </summary>
        /// <param name="c">Objeto que contiene la lista de vehículos.</param>
        /// <param name="v">Vehículo a buscar en la lista.</param>
        /// <returns>True si el vehículo está en la lista.</returns>
        public static bool operator ==(Concesionaria c,Vehiculo v)
        {
            bool respuesta = false;

            foreach (Vehiculo item in c.vehiculos)
            {
                if (item.Equals(v))
                {
                    respuesta = true;
                    break;
                }
            }

            return respuesta;
        }


        /// <summary>
        /// Sobrecarga del operador != que determina si un vehículo no está en la lista.Invoca a la sobrecarga del ==.
        /// </summary>
        /// <param name="c">Concesionaria que contiene una lista de vehículos.</param>
        /// <param name="v">Vehículo a buscar en la lista.</param>
        /// <returns>True si el vehículo no esta en la lista de vehículos de la concesionaria.</returns>
        public static bool operator !=(Concesionaria c,Vehiculo v)
        {
            return !(c == v);
        }


        /// <summary>
        /// Sobrecarga del operador + que agrega un vehículo en la lista de vehículos de la concesionaria(si no está).
        /// </summary>
        /// <param name="c">Concesionaria que contiene la lista a recorrer.</param>
        /// <param name="v">Vehículo a agregar.</param>
        /// <returns>True si pudo agregar el vehículo o false si no lo agregó a la lista.</returns>
        public static Concesionaria operator +(Concesionaria c,Vehiculo v)
        {
            if (c.vehiculos.Count < c.capacidad)
            {
                if (c != v)
                {
                    c.vehiculos.Add(v);
                }
                else
                {
                    Console.WriteLine("El vehiculo ya está en la concesionaria!!!");
                }
            }
            else
            {
                Console.WriteLine("No hay mas lugar en la concesionaria!!!");
            }
            

            return c;
        }
        #endregion
    }
}
