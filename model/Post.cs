using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.model
{
    ///<sumary>
    /// La clase Post contiene todas las caracteristicas que posee una publicacion.
    /// </sumary>
    public class Post{
        private static int idGlobal = 0;
        private int id;
        private string tipo;
        private string texto;
        private string fecha;
        private User autor;
        private List<React> reactions;
        private List<Post> comments;
        private List<string> tags;
        private List<User> shared;

        // constructor
        ///<summary>
        /// Constructor de una publicacion, recibe el tipo de publicacion y el texto
        /// </summary>
        public Post(string tipo, string texto)
        {
            this.tipo = tipo;
            this.texto = texto;
            idGlobal = idGlobal + 1;
            this.id = idGlobal;
            this.reactions = new List<React>();
            this.comments = new List<Post>();
            this.tags = new List<string>();
            this.shared = new List<User>();
            this.tags = new List<string>();
            // fecha
            DateTime fechaActual = DateTime.Now;
            this.fecha = fechaActual.ToString("dd/MM/yyy");

        }
        public Post(string tipo, string texto, List<string> tags){
            this.tipo = tipo;
            this.texto = texto;
            idGlobal = idGlobal + 1;
            this.id = idGlobal;
            this.reactions = new List<React>();
            this.comments = new List<Post>();
            this.tags = tags;
            this.shared = new List<User>();
            this.tags = new List<string>();
            // fecha
            DateTime fechaActual = DateTime.Now;
            this.fecha = fechaActual.ToString("dd/MM/yyy");
        }
        // getters y setters
        /// <value> devuelve o setea el valor de la ID</value>
        public int Id { get => id; set => id = value; }
        /// <value> devuelve o setea el valor del tipo de publicacion </value>
        public string Tipo { get => tipo; set => tipo = value; }
        /// <value> devuelve o setea el valor del contenido como texto de la publicacion </value>
        public string Texto { get => texto; set => texto = value; }
        /// <value> devuelve o setea la fecha de creacion de la publicacion </value>
        public string Fecha { get => fecha; set => fecha = value; }
        /// <value> devuelve o setea el autor de una publicacion </value>
        public User Autor { get => autor; set => autor = value; }
        /// <value> devuelve o setea la lista de reacciones de una publicacion</value>
        public List<React> Reactions { get => reactions; set => reactions = value; }
        /// <value> devuelve o setea la lista de etiquetados de la publicacion</value>
        public List<string> Tags { get => tags; set => tags = value; }
        /// <value> devuelve o setea la lista de compartidos de la publicacion </value>
        public List<User> Shared { get => shared; set => shared = value; }
        /// <value> devuelve o setea la lista de comentarios de la publicacion</value>
        internal List<Post> Comments { get => comments; set => comments = value; }
    }

    

}
