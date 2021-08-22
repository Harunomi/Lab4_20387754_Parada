using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.model
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

        public string Name { get => name; set => name = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public List<User> Usuarios { get => usuarios; set => usuarios = value; }
        public List<Post> Publicaciones { get => publicaciones; set => publicaciones = value; }
        public List<React> Reacts { get => reacts; set => reacts = value; }
        public User UsuarioOnline { get => usuarioOnline; set => usuarioOnline = value; }
    }
}
