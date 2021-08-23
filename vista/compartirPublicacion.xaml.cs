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
    /// Interaction logic for compartirPublicacion.xaml
    /// </summary>
    public partial class compartirPublicacion : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public compartirPublicacion()
        {
            InitializeComponent();
            mostrarUsuarioOnline();
        }
        public void mostrarUsuarioOnline()
        {
            stringUsuarioOnline.Text = controlador.getStringUsuarioOnline();
        }

       

        private void volverMenuP_Click(object sender, RoutedEventArgs e)
        {
            MenuLoggeado ventana = new MenuLoggeado();
            ventana.Show();
            this.Close();
        }

        private void compartirBT_Click(object sender, RoutedEventArgs e)
        {
            if (IDcompartirBT.Text == "")
            {
                MessageBox.Show("El campo de la ID no puede estar en blanco");
            }
            else
            {
                try
                {
                    int id = Int32.Parse(IDcompartirBT.Text);

                    if (publicacionCTags.Text == "")
                    {
                        if( controlador.Share(id) == true)
                        {
                            MessageBox.Show("Publicacion compartida con exito!");
                            MenuLoggeado ventana = new MenuLoggeado();
                            ventana.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El id entregado no corresponde a ninguna publicacion");
                        }
                        
                    }
                    else
                    {
                        List<string> tags = publicacionCTags.Text.Split(',').ToList();
                        if (controlador.Share(id, tags) == true)
                        {
                            MessageBox.Show("Publicacion compartida con exito!");
                            MenuLoggeado ventana = new MenuLoggeado();
                            ventana.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Uno o mas de los etiquetados no existe en la red social o el ID entregado no pertenece a ninguna publicacion");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Ingrese una expresion numerica en el campo de la ID");
                }
            }
        }
    }
}
