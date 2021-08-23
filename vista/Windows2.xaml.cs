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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public Window2()
        {
            InitializeComponent();
        }

        private void registerOut_Click(object sender, RoutedEventArgs e)
        {
            Window1 ventanaInicial = new Window1();
            ventanaInicial.Show();
            this.Close();
        }

        private void RegistrarB_Click(object sender, RoutedEventArgs e)
        {
            Window1 ventanaInicial = new Window1();
            if(Username.Text == "" || Password.Password == "")
            {
                MessageBox.Show("El usuario o la contrasena no pueden ser nulos");
            }
            
            if(controlador.Register(Username.Text, Password.Password))
            {
                MessageBox.Show("Usuario registrado");
                ventanaInicial.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario ya esta registrado");
            }
        }
    }
}
