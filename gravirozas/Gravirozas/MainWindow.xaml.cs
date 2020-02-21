using Gravirozas.Lapok;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gravirozas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rendeles_leadasa(object sender, RoutedEventArgs e)
        {
            Main.Content = new Rendeles();
        }

        private void TermekFelvitele_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TermekFelvitele();
        }

        private void ugyfel_regisztralasa_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new UgyfelReg();
        }

        private void raktar_feltolt(object sender, RoutedEventArgs e)
        {
            Main.Content = new AruFeltolt();
        }

        private void raktar_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new raktar();
        }
    }
}
