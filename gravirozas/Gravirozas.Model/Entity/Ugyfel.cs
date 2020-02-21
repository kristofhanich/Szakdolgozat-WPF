using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Model.Entity
{
    public class Ugyfel
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Cim { get; set; }
        public string Telefonszam { get; set; }
        public Ugyfel() { 
        
        }

        public Ugyfel(int id,string nev,string cim, string telefonszam)
        {
            Id = id;
            Nev = nev;
            Cim = cim;
            Telefonszam = telefonszam;
        }
    }
}
