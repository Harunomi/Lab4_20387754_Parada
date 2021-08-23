using System;
using System.Collections.Generic;
using System.Text;

namespace modelo
{
    /// <summary>
    /// la clase socialnetwork contiene todas las caracteristicas de una red social 
    /// </summary>
    public class Socialnetwork
    {
        // attributes

        private string name;
        private string fecha;
        private List<User> usuarios;
        private List<Post> publicaciones;
        private List<React> reacts;
        private User usuarioOnline;
        private Boolean online;

        // constructor
        ///<summary>
        /// constructor de una red social, crea las listas y recibe un nombre
        /// </summary>
        public Socialnetwork(string name)
        {
            this.name = name;
            this.online = false;
            // fecha
            DateTime fechaActual = DateTime.Now;
            this.fecha = fechaActual.ToString("dd/MM/yyy");
            this.usuarios = new List<User>();
            this.publicaciones = new List<Post>();
            this.reacts = new List<React>();
        }
        /// <value> Devuelve o setea el nombre de la red social</value>
        public string Name { get => name; set => name = value; }
        /// <value> Devuelve o setea la fecha de creacion de la red social </value>
        public string Fecha { get => fecha; set => fecha = value; }
        /// <value> Devuelve o setea la lista de usuarios de la red social </value>
        public List<User> Usuarios { get => usuarios; set => usuarios = value; }
        /// <value> Devuelve o setea la lista de publicaciones de la red social </value>
        public List<Post> Publicaciones { get => publicaciones; set => publicaciones = value; }
        /// <value> Devuelve o setea la lista de reacciones de la red social </value>
        public List<React> Reacts { get => reacts; set => reacts = value; }
        /// <value> Devuelve o setea el usuario online de la red social </value>
        public User UsuarioOnline { get => usuarioOnline; set => usuarioOnline = value; }
        /// <value> Devuelve o setea el boolean del usuario online </value>
        public bool Online { get => online; set => online = value; }
    }
}

