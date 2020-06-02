using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class Parkhaus
    {
        private String ort, plz, strasse;
        //maximale Kapazität als Readonly, damit sie nicht verändert werden kann
        private readonly int maxKap; 
        protected List<Stellplatz> stellplatzliste = new List<Stellplatz>();

        public Parkhaus(string aOrt, string aPlz, string aStrasse, int aMaxKap, List<Stellplatz> aStellplatzliste)
        {
            ort = aOrt;
            plz = aPlz;
            strasse = aStrasse;
            maxKap = aMaxKap;
            stellplatzliste = aStellplatzliste;
        }

        public String Ort { get { return ort; } set { ort = value; } }
        public String Plz { get { return plz; } set { plz = value; } }
        public String Strasse { get { return strasse; } set { strasse = value; } }
        public int MaxKap { get { return maxKap; } }
        public List<Stellplatz> Stellplatzliste { get { return stellplatzliste; } }

        

       

    }
}
