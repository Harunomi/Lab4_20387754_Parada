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
    /// Interaction logic for verPerfil.xaml
    /// </summary>
    public partial class verPerfil : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        public verPerfil()
        {
            InitializeComponent();
            mostrarUsuarioOnline();
            actualizarUsernameTB();
            actualizarFechaTB();
            actualizarTotalPublicacionesTB();
            rellenarPublicacionLB();
            actualizarTotalSeguidores();
            rellenarFollowersLB();
        }
        public void mostrarUsuarioOnline()
        {
            stringUsuarioOnline.Text = controlador.getStringUsuarioOnline();
        }
        public void actualizarUsernameTB()
        {
            nombreUsuarioTB.Text = controlador.getStringUsuarioOnline();
        }
        public void actualizarFechaTB()
        {
            usuarioFechaTB.Text = controlador.getFechaUsuarioOnline();
        }
        public void actualizarTotalPublicacionesTB()
        {
            cantidadPublicacionTB.Text = controlador.getTotalPublicacionesUser().ToString();
        }

        public void rellenarPublicacionLB()
        {
            publicacionesLB.ItemsSource = controlador.getPublicacionesUsuario();
        }
        public void actualizarTotalSeguidores()
        {
            cantidadSeguidoresTB.Text = controlador.getTotalFollowersUser().ToString();
        }
        public void rellenarFollowersLB()
        {
            followersLB.ItemsSource = controlador.getFollowersUsuario();
        }

        private void publicacionesLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = publicacionesLB.Items.IndexOf(publicacionesLB.SelectedItem);
            comentarioPublicacion ventana = new comentarioPublicacion(index);
            ventana.Show();
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuLoggeado ventana = new MenuLoggeado();
            ventana.Show();
            this.Close();
        }
    }
}
