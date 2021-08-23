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
    /// Interaction logic for comentarPublicacion.xaml
    /// </summary>
    public partial class comentarPublicacion : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public comentarPublicacion()
        {
            InitializeComponent();
            mostrarUsuarioOnline();
        }

        public void mostrarUsuarioOnline()
        {
            stringUsuarioOnline.Text = controlador.getStringUsuarioOnline();
        }

        private void volverDarLikeBT_Click(object sender, RoutedEventArgs e)
        {
            MenuLoggeado ventana = new MenuLoggeado();
            ventana.Show();
            this.Close();
        }

        private void comentarBT_Click(object sender, RoutedEventArgs e)
        {
            if(IDcomentarBT.Text == "" || contenidoComentarioBox.Text == "")
            {
                MessageBox.Show("Los cambos de contenido o ID no pueden estar en blanco.");
            }
            else
            {
                try
                {
                    int id = Int32.Parse(IDcomentarBT.Text);
                    if(controlador.Comment(id,contenidoComentarioBox.Text) == true)
                    {
                        MessageBox.Show("Comentario creado exitosamente!");
                        MenuLoggeado ventana = new MenuLoggeado();
                        ventana.Show();
                        this.Close();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("El campo de la ID debe ser un valor numerico");
                }
            }
        }
    }
}
