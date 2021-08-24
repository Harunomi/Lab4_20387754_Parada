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
    /// Interaction logic for comentarioPublicacion.xaml
    /// </summary>
    public partial class comentarioPublicacion : Window
    {
        // atributos
        Controlador controlador = (Controlador)Application.Current.FindResource("controlador");
        private int index;
        public comentarioPublicacion(int indice)
        {
            InitializeComponent();
            mostrarUsuarioOnline();
            rellenarComentariosLB(indice);
      
        }
        public void mostrarUsuarioOnline()
        {
            stringUsuarioOnline.Text = controlador.getStringUsuarioOnline();
        }

        public void rellenarComentariosLB(int index)
        {
            comentariosLB.ItemsSource = controlador.getComentarios(index);
        }

        private void volverMenuCom_Click(object sender, RoutedEventArgs e)
        {
            verPerfil ventana = new verPerfil();
            ventana.Show();
            this.Close();
        }
    }
}
