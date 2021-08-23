using System;
using System.Collections.Generic;
using System.Text;

namespace modelo
{
    /// <summary>
    /// La clase React tiene todas las caracteristicas que posee una reaccion.
    /// </summary>
    public class React
    {
        // atributos 
        private static int idGlobal = 0;
        private int id;
        private User autor;
        private string fecha;
        private string tipo;

        // constructor
        /// <summary>
        /// constructor de una reaccion, recibe el auto y el tipo
        /// </summary
        public React(User autor, string tipo)
        {
            idGlobal = idGlobal + 1;
            this.id = idGlobal;
            this.autor = autor;
            this.tipo = tipo;
            // fecha
            DateTime fechaActual = DateTime.Now;
            this.fecha = fechaActual.ToString("dd/MM/yyy");
        }

        /// <value> Devuelve o setea el id de la reaccion </value>
        public int Id { get => id; set => id = value; }
        /// <value> Devuelve o setea el autor de la reaccion </value>
        public User Autor { get => autor; set => autor = value; }
        /// <value> Devuelve o setea la fecha de la reaccion </value>
        public string Fecha { get => fecha; set => fecha = value; }
        /// <value> Devuelve o setea el tipo de reaccion </value>
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
