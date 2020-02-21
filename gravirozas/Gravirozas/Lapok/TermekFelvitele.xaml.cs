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
using System.IO;
using Microsoft.Win32;

namespace Gravirozas.Lapok
{
    /// <summary>
    /// Interaction logic for TermekFelvitele.xaml
    /// </summary>

    public partial class TermekFelvitele : Page
    {
        private readonly AruService _aruService = null;
        public TermekFelvitele()
        {
            _aruService = new AruService();
            InitializeComponent();
        }

        private void Felvitel_Click(object sender, RoutedEventArgs e)
        {

            if (NevTB.Text == "" || LeirasTB.Text == "" || ArTB.Text == "" || DarabTB.Text == ""  || KepTB.Text == "")
            {
                MessageBox.Show("Minden mező kitöltése kötelező!");
                return;
            }
            if (int.Parse(ArTB.Text) < 0 || int.Parse(DarabTB.Text) < 0)
            {
                MessageBox.Show("Negatív érték nem adható meg!");
            }
            else
            {
                Aru entity = new Aru()
                {
                    Nev = NevTB.Text,
                    Leiras = LeirasTB.Text,
                    Mennyiseg = int.Parse(DarabTB.Text),
                    Ar = int.Parse(ArTB.Text),
                    Kep = KepTB.Text
                };
                
                entity = _aruService.Create(entity).ResponseObject;
                if(!_aruService.Create(entity).IsSuccess)
                    MessageBox.Show(_aruService.Create(entity).ErrorMessage);
                if (entity != null)
                {
                    MessageBox.Show("Sikeres árufelvitel!");
                }
                else
                {
                    MessageBox.Show("Hiba az árufelvitelben!");
                }
            }
        }

        private void Talloz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Kép fájlok (*.jpg, *.png)|*.jpg ; *.png";
            string nev="";
            if (openFileDialog.ShowDialog() == true)
            {
                nev = openFileDialog.FileName;
                KepTB.Text = nev;
                File.Copy(nev, $"./{openFileDialog.SafeFileName}", true);
            }
        }
    }
}
