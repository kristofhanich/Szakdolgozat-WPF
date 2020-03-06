using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Model.Entity
{
    public class Kapcsolat
    {
        public int ID { get; set; }
        public int UgyfelID { get; set; }
        public int AruID { get; set; }
        public DateTime Datum { get; set; }
        public DateTime HatarIdo { get; set; }
        public int Darab { get; set; }
        public int TeljesAr { get; set; }

        public Kapcsolat()
        {
        }

        public Kapcsolat(int iD, int ugyfelID, int aruID, DateTime datum, DateTime hatarIdo, int darab, int teljesAr)
        {
            ID = iD;
            UgyfelID = ugyfelID;
            AruID = aruID;
            Datum = datum;
            HatarIdo = hatarIdo;
            Darab = darab;
            TeljesAr = teljesAr;
        }

        public override string ToString()
        {
            return $"{UgyfelID}";
        }

    }
}
