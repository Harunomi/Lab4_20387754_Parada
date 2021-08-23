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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public Login()
        {
            InitializeComponent();
        }

        private void IniciarSesionB_Click(object sender, RoutedEventArgs e)
        {
            MenuLoggeado ventana = new MenuLoggeado();
            if(UsernameLogin.Text == "" || PasswordLogin.Password == "")
            {
                MessageBox.Show("El usuario o la contrasena no pueden ser nulos.");
            }
            if (controlador.Login(UsernameLogin.Text, PasswordLogin.Password))
            {
                MessageBox.Show("Sesion iniciada con exito!");
                ventana.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El nombre de usuario y/o contrasena son incorrectos.");
            }
            
        }
    }
}
