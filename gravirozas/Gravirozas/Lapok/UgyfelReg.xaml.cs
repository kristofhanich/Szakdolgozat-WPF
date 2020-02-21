using Gravirozas.Model;
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
    /// Interaction logic for UgyfelReg.xaml
    /// </summary>
    public partial class UgyfelReg : Page
    {
        private readonly UgyfelService _ugyfelService = null;
        public UgyfelReg()
        {
            _ugyfelService = new UgyfelService();
            InitializeComponent();
        }


        private void Regisztral_Click(object sender, RoutedEventArgs e)
        {
            if (UgyfelTB.Text == "" || CimTB.Text == "" || TelefonTB.Text == "")
            {
                MessageBox.Show("Minden mező kitöltése kötelező!");
                return;
            }
            else
            {
                Ugyfel entity = new Ugyfel()
                {
                    Nev = UgyfelTB.Text,
                    Cim = CimTB.Text,
                    Telefonszam = TelefonTB.Text
                };
                entity = _ugyfelService.Create(entity).ResponseObject;
                if (entity != null)
                {
                    MessageBox.Show("Ügyfél felvitele sikeres!");
                }
                else
                {
                    MessageBox.Show("Ügyfél felvitele sikertelen!");
                }
            }
            UgyfelTB.Text = "";
            CimTB.Text = "";
            TelefonTB.Text = "";
        }
    }
}
