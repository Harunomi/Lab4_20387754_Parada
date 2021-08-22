using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.model
{
    /// <summary>
    /// La clase User contiene todas las caracteristicas que posee un usuario dentro de la red social
    /// </summary>
    public class User
    {
        // attributes
        private static int idGlobal = 0;
        private int id;
        private string username;
        private string password;
        private string fecha;
        private List<User> followers;
        private List<Post> publicaciones;

        // constructor
        public User(string username, string password)
        {
            this.username = username;  
            this.password = password;
            idGlobal = idGlobal + 1;
            this.id = idGlobal;
            this.followers = new List<User>();
            this.publicaciones = new List<Post>();
            // fecha
            DateTime fechaActual = DateTime.Now;
            this.fecha = fechaActual.ToString("dd/MM/yyy");
        }

        /// <value> Devuelve o setea el id del usuario </value>
        public int Id { get => id; set => id = value; }
        /// <value> Devuelve o setea el username del usuario</value>
        public string Username { get => username; set => username = value; }
        /// <value> Devuelve o setea la password del usuario </value>
        public string Password { get => password; set => password = value; }
        /// <value> Devuelve o setea la fecha de creacion del usuario</value>
        public string Fecha { get => fecha; set => fecha = value; }
        /// <value> Devuelve o setea la lista de followers del usuario </value>
        public List<User> Followers { get => followers; set => followers = value; }
        /// <value> Devuelve o setea la lista de publicaciones del usuario </value>
        public List<Post> Publicaciones { get => publicaciones; set => publicaciones = value; }
    }
}
