using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Clase abstracta que no se puede instanciar.Se utiliza como clase base(padre).
    public abstract class Vehiculo
    {
        #region atributos
        protected Fabricante fabricante;
        protected static Random generadorDeVelocidad;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;
        #endregion


        #region Propiedades
        //Propiedad que inicializa el atributo velocidadMáxima.
        public int VelocidadMaxima
        {
            get {
                if (this.velocidadMaxima == 0)
                {
                    this.velocidadMaxima = Vehiculo.generadorDeVelocidad.Next(100,280);
                }

                return this.velocidadMaxima;
            }
        }
        #endregion


        #region Constructores
        /// <summary>
        /// Consturctor estático de la clase.Inicializa los aatributos estáticos de la clase Vehículo.
        /// </summary>
        static Vehiculo()
        {
            Vehiculo.generadorDeVelocidad = new Random();
        }


        /// <summary>
        /// Constuctor que instancia la clase.
        /// </summary>
        /// <param name="precio">Precio del vehículo.</param>
        /// <param name="modelo">Cadena de caracteres que representa el modelo del vehículo.</param>
        /// <param name="fabri">Fabricante del vehículo.</param>
        public Vehiculo(float precio,string modelo,Fabricante fabri)
        {
            this.precio = precio;
            this.modelo = modelo;
            this.fabricante = fabri;
        }


        /// <summary>
        /// Sobrecarga de contructor.
        /// </summary>
        /// <param name="marca">Cadena de caracteres que representa la marca del fabricante del vehículo.</param>
        /// <param name="pais">Enumerado que asigna un país para el fabricante del vehículo.</param>
        /// <param name="modelo">Cadena de caracteres que representa el modelo del vehículo.</param>
        /// <param name="precio">Precio del vehículo.</param>
        public Vehiculo(string marca,EPais pais,string modelo,float precio)
            :this(precio,modelo,new Fabricante(marca,pais))
        {
        }
        #endregion


        #region Métodos
        /// <summary>
        /// Método de clase que retorna el estado del vehículo.
        /// </summary>
        /// <param name="v">Vehículo a mostrar.</param>
        /// <returns>Cadena de caracteres con el estado del vehículo.</returns>
        private static string Mostrar(Vehiculo v)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(v.fabricante);
            sb.AppendFormat("MODELO: {0}\n", v.modelo);
            sb.AppendFormat("VELOCIDA MAXIMA: {0}\n", v.VelocidadMaxima);
            sb.AppendFormat("PRECIO: {0}", v.precio);

            return sb.ToString();
        }

        #endregion


        #region Sobrecargas
        /// <summary>
        /// Sobrecarga que retorna el estado de un vehículo.Invoca a un método de clase.
        /// </summary>
        /// <param name="v">Vehículo a mostrar.</param>
        public static explicit operator string(Vehiculo v)
        {
            return Vehiculo.Mostrar(v);
        }


        /// <summary>
        /// Sobrecarga del operador == que determina si dos vehículos son iguales.
        /// </summary>
        /// <param name="a">Vehículo a comparar.</param>
        /// <param name="b">Vehículo a comparar.</param>
        /// <returns>Retorna true si ambos son null o si el fabricante y modelo de los vehículos son el mismo.</returns>
        public static bool operator ==(Vehiculo a,Vehiculo b)
        {
            bool respuesta = false;

            if (((object)a) == null && ((object)b) == null)
            {
                respuesta = true;
            }
            else if (((object)a) != null && ((object)b) != null && a.fabricante == b.fabricante && a.modelo == b.modelo)
            {
                respuesta = true;
            }

            return respuesta;
        }


        /// <summary>
        /// Sobrecarga del operador != que determina si dos vehículos son distintos.Invoca a la sobrecarga del ==.
        /// </summary>
        /// <param name="a">Vehículo a comparar.</param>
        /// <param name="b">Vehículo a comparar.</param>
        /// <returns>True si los vehículos son distintos.</returns>
        public static bool operator !=(Vehiculo a,Vehiculo b)
        {
            return !(a == b);
        }

        #endregion
    }
}
