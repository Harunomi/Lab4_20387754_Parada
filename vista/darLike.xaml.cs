using Lab4.controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab4.vista
{
    /// <summary>
    /// Interaction logic for darLike.xaml
    /// </summary>
    public partial class darLike : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public darLike()
        {
            InitializeComponent();
            mostrarUsuarioOnline();
        }

        private void darLikeBT_Click(object sender, RoutedEventArgs e)
        {
            if (idLikeBox.Text == "")
            {
                MessageBox.Show("No has ingresado ninguna ID de una publicacion.");
            }
            else
            {

                try
                {
                    int id = Int32.Parse(idLikeBox.Text);
                    if (controlador.Like(id) == true)
                    {
                        MessageBox.Show("Like agregado con exito!");
                        MenuLoggeado ventana = new MenuLoggeado();
                        ventana.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La ID de la publicacion ingresada no existe o ya contiene un like del usuario");
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("La id ingresada no corresponde a un valor numerico");
                }
            }
        }

        private void volverDarLikeBT_Click(object sender, RoutedEventArgs e)
        {
            MenuLoggeado ventana = new MenuLoggeado();
            ventana.Show();
            this.Close();
        }
        public void mostrarUsuarioOnline()
        {
            stringUsuarioOnline.Text = controlador.getStringUsuarioOnline();
        }
    }
}
