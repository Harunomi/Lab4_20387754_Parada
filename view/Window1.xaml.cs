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

namespace Lab4.view
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void BTN_bloque1_Click(object sender, RoutedEventArgs e)
        {
            TB_bloque1.Text = "la wea que querai";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_bloque1.Text = "la wea que querai2222";
        }
    }
}
