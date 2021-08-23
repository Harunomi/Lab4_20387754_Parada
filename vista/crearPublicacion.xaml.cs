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
    /// Interaction logic for crearPublicacion.xaml
    /// </summary>
    public partial class crearPublicacion : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public crearPublicacion()
        {
            InitializeComponent();
        }

        private void publicarBT_Click(object sender, RoutedEventArgs e)
        {
            // verificamos que no haya campos en blanco
            if (tipoPublicacion.Text == "" || contenidoPublicacion.Text == "")
            {
                MessageBox.Show("Uno o ambos campos anteriores fueron dejados en blanco");
            }
            else
            {
                // caso en que no hayan etieutados
                if(publicacionTags.Text == "")
                {
                    controlador.PostRS(tipoPublicacion.Text, contenidoPublicacion.Text);
                    MenuLoggeado ventana = new MenuLoggeado();
                    MessageBox.Show("Publicacion creada con exito!");
                    ventana.Show();
                    this.Close();

                }
                // caso en que hayan etieutados
                else
                {
                    List<string> listaEtiquetados = publicacionTags.Text.Split(',').ToList();
                    if (controlador.PostRS(tipoPublicacion.Text, contenidoPublicacion.Text, listaEtiquetados) == true)
                    {
                        MenuLoggeado ventana = new MenuLoggeado();
                        MessageBox.Show("Publicacion creada con exito!");
                        ventana.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Uno o mas de los etiquetados no existe en la red social");
                    }
                }
            } 
   
        }

        private void volverMenuP_Click(object sender, RoutedEventArgs e)
        {
            MenuLoggeado ventana = new MenuLoggeado();
            ventana.Show();
            this.Close();
        }
    }
}
