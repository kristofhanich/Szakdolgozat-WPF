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
    /// Interaction logic for Rendeles.xaml
    /// </summary>
    public partial class Rendeles : Page
    {
        private readonly UgyfelService _ugyfelService = null;
        private readonly AruService _aruService = null;
        private readonly KapcsolatService _kapcsolatService = null;
        public Rendeles()
        {
            _ugyfelService = new UgyfelService();
            _aruService = new AruService();
            _kapcsolatService = new KapcsolatService();
            InitializeComponent();
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            ResponseMessage<List<Ugyfel>> request_ugy = _ugyfelService.GetAll();

            if (request_ugy == null || !request_ugy.IsSuccess || request_ugy.ResponseObject == null)
            {
                MessageBox.Show(request_ugy.ErrorMessage);
            }

            ResponseMessage<List<Aru>> request_aru = _aruService.GetAll();

            if (request_aru == null || !request_aru.IsSuccess || request_aru.ResponseObject == null)
            {
                MessageBox.Show(request_aru.ErrorMessage);
            }

            foreach (var item in request_ugy.ResponseObject)
            {
                UgyfelCB.Items.Add(item.Id + " " + item.Nev);
            }

            foreach (var item in request_aru.ResponseObject)
            {
                VasaroltAruCB.Items.Add(item.Id + " " + item.Nev);
            }

            HataridoDP.DisplayDateStart = DateTime.Now;

            /*Lista feltöltése*/
            /*https://www.wpf-tutorial.com/listview-control/listview-with-gridview/ */
            List <Kapcsolat> lista= new List<Kapcsolat>();

            ResponseMessage<List<Kapcsolat>> request_kapcsolat = _kapcsolatService.GetAll();
            if (request_aru == null || !request_aru.IsSuccess || request_aru.ResponseObject == null)
            {
                MessageBox.Show(request_kapcsolat.ErrorMessage);
            }

            foreach (var item in request_kapcsolat.ResponseObject)
            {
                lista.Add(item);/*.UgyfelID , item.AruID, item.Datum, item.HatarIdo, item.Darab, item.TeljesAr}*/
                rendelesekLista.ItemsSource = lista;/*emiatt dob hibát*/
            }


        }

        public void Frissit(int id)
        {
            int request_menny = _aruService.Elerheto(id);
            darabCB.Items.Clear();

            /*if (request_menny == null || !request_menny.IsSuccess)
            {
                MessageBox.Show(request_menny.ErrorMessage);
            }*/
                if (request_menny == 0)
            {
                ElerhetoL.Content = "Nem elérhető!";
                darabCB.IsEnabled = false;
            }
            else
            {
                darabCB.IsEnabled = true;
                ElerhetoL.Content = request_menny;
                for (int i = 1; i <= request_menny; i++)
                {
                    darabCB.Items.Add(i);
                }
            }
        }
        private void VasaroltAruCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frissit(int.Parse(VasaroltAruCB.SelectedItem.ToString().Split(' ')[0]));
            if (VasaroltAruCB.SelectedItem != null && HataridoDP.SelectedDate != null && darabCB.SelectedItem != null)
            {
                TeljesAr();
            }
        }
        private void darabCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VasaroltAruCB.SelectedItem != null && HataridoDP.SelectedDate != null && darabCB.SelectedItem != null)
            {
                TeljesAr();
            }
        }
        private void HataridoDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VasaroltAruCB.SelectedItem != null && HataridoDP.SelectedDate != null && darabCB.SelectedItem != null)
            {
                TeljesAr();
            }
        }

        private void TeljesAr()
        {
            if (HataridoDP.SelectedDate == null || VasaroltAruCB.SelectedItem == null)
            {
                return;
            }

            int teljesar = Convert.ToInt16(_aruService.GetByID(int.Parse(VasaroltAruCB.SelectedItem.ToString().Split(' ')[0])).ResponseObject.Ar) * int.Parse(darabCB.SelectedItem.ToString());
            teljesarL.Content = teljesar;
        }

        private void Lekeres_Click(object sender, RoutedEventArgs e)
        {
            if (UgyfelCB.SelectedItem == null || VasaroltAruCB.SelectedItem == null || darabCB.SelectedItem == null || _aruService.Elerheto(int.Parse(VasaroltAruCB.SelectedItem.ToString().Split(' ')[0])) == 0 || HataridoDP.SelectedDate == null)
            {
                MessageBox.Show("Kötelező minden elemet kiválasztani!");
                return;
            }
            teljesarL.Content = "";
            Kapcsolat temp = new Kapcsolat();
            temp.UgyfelID = _ugyfelService.GetByID(int.Parse(UgyfelCB.SelectedItem.ToString().Split(' ')[0])).ResponseObject.Id;
            temp.AruID = _aruService.GetByID(int.Parse(VasaroltAruCB.SelectedItem.ToString().Split(' ')[0])).ResponseObject.Id;
            temp.Darab = int.Parse(darabCB.SelectedItem.ToString());
            temp.HatarIdo= DateTime.Parse(HataridoDP.SelectedDate.ToString());
            temp.TeljesAr = Convert.ToInt16(_aruService.GetByID(int.Parse(VasaroltAruCB.SelectedItem.ToString().Split(' ')[0])).ResponseObject.Ar) * int.Parse(darabCB.SelectedItem.ToString());
            DateTime val = _kapcsolatService.Create(temp).ResponseObject.Datum;
            if (val != null)
            {
                Aru gep = new Aru(_aruService.GetByID(temp.AruID).ResponseObject);
                gep.Mennyiseg -= temp.Darab;
                _aruService.Update(gep);
                MessageBox.Show("Sikeres vásárlás rögzítés!");
                Frissit(int.Parse(VasaroltAruCB.SelectedItem.ToString().Split(' ')[0]));

            }
            else
            {
                MessageBox.Show("Hiba a vásárlás rögzítésében!");
            }
        }
    }
}

