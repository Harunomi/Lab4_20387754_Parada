﻿using System;
using Lab4.model;
using System.Collections.Generic;
using System.Text;

namespace Lab4.control
{
    /// <summary>
    /// La clase controlador contiene todas las funciones y logica del programa, usa el model y es usado por la vista
    /// </summary>
    public class Controller
    {
        private Socialnetwork redSocial;
        private static Controller instancia;
        // constructor
        ///<summary>
        /// Constructor de controlador, se crea la instancia
        /// </summary>
        public Controller()
        {
            this.redSocial = new Socialnetwork("LMAOBOOK");
        }
        // Metodos

        ///<value> Devuelve la instancia del controlador, sino esta, se crea</value>
        public static Controller Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Controller();
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
    }

    

}
