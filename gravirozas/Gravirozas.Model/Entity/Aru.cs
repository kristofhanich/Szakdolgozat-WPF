using System;
using System.Collections.Generic;
using System.Text;

namespace Gravirozas.Model.Entity
{
    public class Aru
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Leiras { get; set; }
        public int Mennyiseg { get; set; }
        public int Ar { get; set; }
        public string Kep { get; set; }

        public Aru()
        {

        }

        public Aru(int id, string nev, string leiras, int mennyiseg, int ar, string kep)
        {
            Id = id;
            Nev = nev;
            Leiras = leiras;
            Mennyiseg = mennyiseg;
            Ar = ar;
            Kep = kep;
        }
        
        public Aru(Aru Aru)
        {
            Id = Aru.Id;
            Nev = Aru.Nev;
            Leiras = Aru.Leiras;
            Mennyiseg = Aru.Mennyiseg;
            Ar = Aru.Ar;
            Kep = Aru.Kep;
        }
        

    }
}
