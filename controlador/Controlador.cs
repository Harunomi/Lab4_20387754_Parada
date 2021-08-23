using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelo;

namespace Lab4.controlador
{
    /// <summary>
    /// La clase controlador contiene todas las funciones y logica del programa, usa el model y es usado por la vista
    /// </summary>
    public class Controlador
    {
        private Socialnetwork redSocial;
        private static Controlador instancia;
        // constructor
        ///<summary>
        /// Constructor de controlador, se crea la instancia
        /// </summary>
        public Controlador()
        {
            this.redSocial = new Socialnetwork("LMAOBOOK");
            poblarRedSocial();
        }
        // Metodos

        ///<value> Devuelve la instancia del controlador, sino esta, se crea</value>
        public static Controlador Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Controlador();
                }
                return instancia;
            }
        }

        ///<summary>
        /// pobla la red social con 5 usuarios, 10 publicaciones, 3 followers
        /// </summary>
        public void poblarRedSocial()
        {
            // creamos los usuarios
            User user1 = new User("Katsugo", "uwu123");
            User user2 = new User("Harunomi", "password1");
            User user3 = new User("Spica", "Cybele");
            User user4 = new User("uNable", "nomehackeen");
            User user5 = new User("Kappita", "1234");

            // creo las publicaciones
            Post post1 = new Post("text", "Explorando la nueva red social");
            Post post2 = new Post("photo", "publicacion.jpeg");
            Post post3 = new Post("audio", "cover.mp3");
            Post post4 = new Post("photo", "tremendomapita.png");
            Post post5 = new Post("audio", "song.mp3");
            Post post6 = new Post("text", "Como se ocupa esta red social LOL");
            Post post7 = new Post("text", "termine de jugar, luego de 10 horas");
            Post post8 = new Post("text", "es dificil soportar el stress");
            Post post9 = new Post("text", "chicos manana se prende stream");
            Post post10 = new Post("photo", "papitasfritas.png");

            // agrego las publicaciones a los usuarios
            user2.Publicaciones.Add(post1);
            user2.Publicaciones.Add(post2);
            user1.Publicaciones.Add(post3);
            user4.Publicaciones.Add(post4);
            user4.Publicaciones.Add(post10);
            user1.Publicaciones.Add(post5);
            user1.Publicaciones.Add(post9);
            user3.Publicaciones.Add(post6);
            user5.Publicaciones.Add(post7);
            user2.Publicaciones.Add(post8);

            // agrego los usuarios a la red social

            redSocial.Usuarios.Add(user1);
            redSocial.Usuarios.Add(user2);
            redSocial.Usuarios.Add(user3);
            redSocial.Usuarios.Add(user4);
            redSocial.Usuarios.Add(user5);

            // agrego las publicaciones a la red social

            redSocial.Publicaciones.Add(post1);
            redSocial.Publicaciones.Add(post2);
            redSocial.Publicaciones.Add(post3);
            redSocial.Publicaciones.Add(post4);
            redSocial.Publicaciones.Add(post5);
            redSocial.Publicaciones.Add(post6);
            redSocial.Publicaciones.Add(post7);
            redSocial.Publicaciones.Add(post8);
            redSocial.Publicaciones.Add(post9);
            redSocial.Publicaciones.Add(post10);

            // agrego un par de followers
            user2.Followers.Add(user1);
            user2.Followers.Add(user3);
            user1.Followers.Add(user2);
            user5.Followers.Add(user2);

        }

        ///<summary>
        /// Registra a un usuario en la red social, retorna true si se pudo crear el usuario, false sino.
        /// </summary>

        /// <returns>
        /// true si el usuario fue registrado, false si ya existia en la red social.
        /// </returns>

        public bool Register(string username, string password)
        {
            // verificamos que el usuario no exista en la red social
            if (redSocial.Usuarios.Any(i => i.Username == username))
            {
                return false;
            }
            else
            {
                User nuevoUsuario = new User(username, password);
                redSocial.Usuarios.Add(nuevoUsuario);
                return true;
            }
        }

        ///<summary>
        /// Autentifica a un usuario en la red social comprobando que sea el nombre de usuario y contrasena correctos
        /// </summary>

        ///<returns>
        /// true si el usuario con su username coincidia con su contrasena, false caso contrario
        /// </returns>

        public bool Login(string username, string password)
        {
            // verificamos que el usuario y contrasena sean validos
            if (redSocial.Usuarios.Any(i => i.Username == username && i.Password == password))
            {
                // si es verdad, loggeamos al usuario
                redSocial.UsuarioOnline = redSocial.Usuarios.Find(i => i.Username == username);
                redSocial.Online = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// dejamos una marca que en la red social actualmente no hay ningun conectado 
        /// </summary>
        public void Logout()
        {
            redSocial.Online = false;
        }
        /// <summary>
        /// funcion que permite saber si hay un usuario conectado en la red social
        /// </summary>
        /// <returns>
        /// true si hay un usuario online, false caso contrario
        /// </returns>
        public bool isOnline()
        {
            if (redSocial.Online == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// funcion que permite crear una publicacion dentro de una red social
        /// </summary>
        /// <param name="tipo">el tipo de publicacion</param>
        /// <param name="texto">el contenido de la publicacion</param>
        public void PostRS(string tipo, string texto)
        {
            // creamos la publicacion
            Post nuevoPost = new Post(tipo, texto);
            // le agregamos el autor de la publicacion
            nuevoPost.Autor = redSocial.UsuarioOnline;
            // la agregamos a la red social
            redSocial.Publicaciones.Add(nuevoPost);
            // se agrega la publicacion a la lista de publicaciones del usuario online
            redSocial.UsuarioOnline.Publicaciones.Add(nuevoPost);
        }
        /// <summary>
        /// funcion que permite crear una publicacion dentro de una red social con etiquetados
        /// </summary>
        /// <param name="tipo"> el tipo de publicacion</param>
        /// <param name="texto">el texto de la publicacion</param>
        /// <param name="tags">lista de etiquetados </param>
        public bool PostRS(string tipo, string texto, List<string> tags)
        {
            // verificamos que los usuarios en tags existan en la red social 
            int counter = 0;
            for (int j = 0; j < tags.Count; j++)
            {
                if (redSocial.Usuarios.Any(i => i.Username == tags[j]))
                {
                    counter = counter + 1;
                }
            }
            if (counter == tags.Count)
            {
                // creamos la publicacion
                Post nuevoPost = new Post(tipo, texto, tags);
                // le agregamos el autor de la publicacion
                nuevoPost.Autor = redSocial.UsuarioOnline;
                // la agregamos a la red social
                redSocial.Publicaciones.Add(nuevoPost);
                // se agrega la publicacion a la lista de publicaciones del usuario online
                redSocial.UsuarioOnline.Publicaciones.Add(nuevoPost);
                return true;
            }
            return false;

        }
        /// <summary>
        /// funcion uqe permite seguir a otro usuario dentro de la red social
        /// </summary>
        /// <param name="username">nombre del usuario a seguir</param>
        public bool Follow(string username)
        {
            // verificamos si el usuario a seguir existe
            if (redSocial.Usuarios.Any(i => i.Username == username))
            {
                // verificamos que el usuario no se pueda seguir a si mismo
                if (redSocial.UsuarioOnline.Username != username)
                {
                    // verificamos que el usuario ya no sea seguido por el usuario online
                    if(redSocial.Usuarios.Find(i=>i.Username == username).Followers.Any(j=>j.Username == redSocial.UsuarioOnline.Username) == false)
                    {
                        // agregamos el usuario online  a la lista de followers del usuario a seguir
                        redSocial.Usuarios.Find(i => i.Username == username).Followers.Add(redSocial.UsuarioOnline);
                        return true;
                    }
                    
                }
            }
            return false;
        }
        /// <summary>
        /// funcion que permite compartir una publicacion segun su id
        /// </summary>
        /// <param name="id">id de la publicacion a compartir</param>
        public bool Share(int id)
        {
            // buscamos la publicacion en la red social
            if (redSocial.Publicaciones.Any(i => i.Id == id))
            {
                // creamos la publicacion compartida
                Post publicacionCompartida = new Post(redSocial.Publicaciones.Find(i => i.Id == id).Tipo, redSocial.Publicaciones.Find(i => i.Id == id).Texto);
                // agrego el usuario que compartio la publicacion a la publicacion original
                redSocial.Publicaciones.Find(i => i.Id == id).Shared.Add(redSocial.UsuarioOnline);
                // seteo el autor de la publicacion compartida
                publicacionCompartida.Autor = redSocial.UsuarioOnline;
                // agrego la publicacion creada a la lista de publicaciones del usuario
                redSocial.UsuarioOnline.Publicaciones.Add(publicacionCompartida);
                return true;
            }
            return false;
        }
        /// <summary>
        /// funcion que permite compartir una publicacion segun su id
        /// </summary>
        /// <param name="id">id de la publicacion a compartir</param>
        /// <param name="tags">lista de etiquetados</param>
        public bool Share(int id, List<string> tags)
        {
            // verificamos que los usuarios en tags existan en la red social 
            int counter = 0;
            for (int j = 0; j < tags.Count; j++)
            {
                if (redSocial.Usuarios.Any(i => i.Username == tags[j]))
                {
                    counter = counter + 1;
                }
            }
            if (counter == tags.Count)
            {
                // buscamos la publicacion en la red social
                if (redSocial.Publicaciones.Any(i => i.Id == id)) 
                {
                    // creamos la publicacion compartida
                    Post publicacionCompartida = new Post(redSocial.Publicaciones.Find(i => i.Id == id).Tipo, redSocial.Publicaciones.Find(i => i.Id == id).Texto, tags);
                    // agrego el usuario que compartio la publicacion a la publicacion original
                    redSocial.Publicaciones.Find(i => i.Id == id).Shared.Add(redSocial.UsuarioOnline);
                    // seteo el autor de la publicacion compartida
                    publicacionCompartida.Autor = redSocial.UsuarioOnline;
                    // agrego la publicacion creada a la lista de publicaciones del usuario
                    redSocial.UsuarioOnline.Publicaciones.Add(publicacionCompartida);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// funcion que permite crear un comentario a una publicacion o otro comentario
        /// </summary>
        /// <param name="id">id de la publicacion a comentar</param>
        /// <param name="texto">contenido del comentario como string</param>
        public bool Comment(int id, string texto)
        {
            // verificamos uqe la publicacion exista
            if (redSocial.Publicaciones.Any(i => i.Id == id))
            {
                // creamos el comentario
                Post nuevoComentario = new Post("comentario", texto);
                // seteamos el comentario con el autor
                nuevoComentario.Autor = redSocial.UsuarioOnline;
                // agregamos el comentario a la lista de publicaciones de la red social
                redSocial.Publicaciones.Add(nuevoComentario);
                // agregamos el comentario a la lista de publicaciones del usuario
                redSocial.UsuarioOnline.Publicaciones.Add(nuevoComentario);
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// permite agregar un like a una publicacion
        /// </summary>
        /// <param name="id">el id de la publicacion a darle like</param>
        public bool Like(int id)
        {
            // vericiamos que la publicacion exista
            if (redSocial.Publicaciones.Any(i => i.Id == id))
            {
                //verificamos que no exista una reaccion ya agregada con el usuario online como autor
                if (redSocial.Publicaciones.Find(i => i.Id == id).Reactions.Any(j => j.Autor.Username == redSocial.UsuarioOnline.Username) == true)
                {
                    return false;
                }
                else
                {
                    // creamos la reaccion
                    React nuevaReaccion = new React(redSocial.UsuarioOnline, "like");
                    // agregamos la reaccion a la publicacion
                    redSocial.Publicaciones.Find(i => i.Id == id).Reactions.Add(nuevaReaccion);
                    // agregamos la reaccion a la lista de reacciones de la red social
                    redSocial.Reacts.Add(nuevaReaccion);
                    return true;
                }
                
            }
            return false;
        }

        public string getStringUsuarioOnline()
        {

            return redSocial.UsuarioOnline.Username;
            
        }

        public string getFechaUsuarioOnline()
        {
            return redSocial.UsuarioOnline.Fecha;
        }
        public int getTotalPublicacionesUser()
        {
            return redSocial.UsuarioOnline.Publicaciones.Count();
        }

        public List<Post> getPublicacionesUsuario()
        {
            return redSocial.UsuarioOnline.Publicaciones;
        }

        



    }



}
