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
using Gravirozas.Model;

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
            string richText = new TextRange(LeirasTB.Document.ContentStart, LeirasTB.Document.ContentEnd).Text;
            if (NevTB.Text == "" || richText == "" || ArTB.Text == "" || DarabTB.Text == ""  || KepTB.Text == "")
            {
                MessageBox.Show("Minden mező kitöltése kötelező!");
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(ArTB.Text, "[^0-99]") ||  int.Parse(ArTB.Text) < 0)
            {
                MessageBox.Show("Hibás a bevitt érték!");
                ArTB.BorderBrush = Brushes.Red;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(DarabTB.Text, "[^0-99]") || int.Parse(DarabTB.Text) < 0)
            {
                MessageBox.Show("Hibás a bevitt érték!");
                DarabTB.BorderBrush = Brushes.Red;
            }
            else
            {
                ArTB.BorderBrush = default;
                DarabTB.BorderBrush = default;
                Aru entity = new Aru()
                {
                    Nev = NevTB.Text,
                    Leiras = richText,
                    Mennyiseg = int.Parse(DarabTB.Text),
                    Ar = int.Parse(ArTB.Text),
                    Kep = KepTB.Text
                };

                ResponseMessage<Aru> request = _aruService.Create(entity);

                if (!request.IsSuccess)
                {
                    MessageBox.Show(_aruService.Create(entity).ErrorMessage);
                    return;
                }

                MessageBox.Show("Sikeres árufelvitel!");
            }
        }

        private void Talloz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Kép fájlok (*.jpg, *.png)|*.jpg;*.png";
            string nev="";
            if (openFileDialog.ShowDialog() == true)
            {
                nev = openFileDialog.FileName;
                KepTB.Text = nev;
                File.Copy(nev, $"./{NevTB.Text}.jpg", true);
            }
        }
    }
}
