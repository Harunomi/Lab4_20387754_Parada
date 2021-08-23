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
    /// Interaction logic for seguirUsuario.xaml
    /// </summary>
    public partial class seguirUsuario : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public seguirUsuario()
        {
            InitializeComponent();
            mostrarUsuarioOnline();
        }

        private void folllowBT_Click(object sender, RoutedEventArgs e)
        {
            if(usernameSeguirBox.Text == "")
            {
                MessageBox.Show("El campo del username esta en blanco.");
            }
            else
            {
                if(controlador.Follow(usernameSeguirBox.Text) == true)
                {
                    MessageBox.Show("Usuario seguido con exito!");
                    MenuLoggeado ventana = new MenuLoggeado();
                    ventana.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El username ingresado no pertenece a ningun usuario dentro de la red social o ya sigues a esta cuenta");
                }
            }
        }

        private void volverSeguirBT_Click(object sender, RoutedEventArgs e)
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

