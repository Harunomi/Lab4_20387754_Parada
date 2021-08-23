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
    /// Interaction logic for MenuLoggeado.xaml
    /// </summary>
    public partial class MenuLoggeado : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public MenuLoggeado()
        {
            InitializeComponent();
            mostrarUsuarioOnline();
          
        }

        public void mostrarUsuarioOnline()
        {
            stringUsuarioOnline.Text = controlador.getStringUsuarioOnline();


        }

        private void postBT_Click(object sender, RoutedEventArgs e)
        {
            crearPublicacion ventana = new crearPublicacion();
            ventana.Show();
            this.Close();
        }
    }
}
