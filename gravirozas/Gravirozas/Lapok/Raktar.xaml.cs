using Gravirozas.Model.Entity;
using Gravirozas.Service;
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

namespace Gravirozas.Lapok
{
    /// <summary>
    /// Interaction logic for raktar.xaml
    /// </summary>
    public partial class raktar : Page
    {
        private readonly AruService _aruService = null;
        public List<Aru> aruk;
        public int szamlalo = 0;
        public raktar()
        {
            _aruService = new AruService();
            aruk = _aruService.GetAll().ResponseObject;
            InitializeComponent();
            Feltolt(szamlalo);
        }
        public void Feltolt(int id)
        {
            AruNeveL.Content = aruk[id].Nev;
            LeirasL.Content = aruk[id].Leiras;
            ArL.Content = aruk[id].Ar + " Ft";
            AruDarabL.Content = aruk[id].Mennyiseg;
            string eleres = System.IO.Path.GetFullPath(aruk[id].Kep);
            Kep.Source = new BitmapImage(new Uri(eleres));
        }
        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            szamlalo--;
            if (szamlalo < 0)
            {
                szamlalo = aruk.Count - 1;
            }
            Feltolt(szamlalo);
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            szamlalo++;
            if (szamlalo == aruk.Count)
            {
                szamlalo = 0;
            }
            Feltolt(szamlalo);
        }
    }
}
