using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Model.Entity
{
    public class KapcsolatLista : Kapcsolat
    {
        public string UgyfelNev { get; set; }
        public string AruNev { get; set; }

        public KapcsolatLista()
        {
        }

        public KapcsolatLista(string ugyfelNev, string aruNev) : base()
        {
            UgyfelNev = ugyfelNev;
            AruNev = aruNev;
        }

        public KapcsolatLista(string ugyfelNev, string aruNev, int iD, int ugyfelID, int aruID, DateTime datum, DateTime hatarIdo, int darab, int teljesAr)
            : base(iD, ugyfelID, aruID, datum, hatarIdo, darab, teljesAr)
        {
            UgyfelNev = ugyfelNev;
            AruNev = aruNev;
        }
    }
    

}
