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
        protected List<Stellplatz> stellplatzliste = new List<Stellplatz>();

        public Parkhaus(string aOrt, string aPlz, string aStrasse)
        {
            ort = aOrt;
            plz = aPlz;
            strasse = aStrasse;
        }

        public String Ort { get { return ort; } set { ort = value; } }
        public String Plz { get { return plz; } set { plz = value; } }
        public String Strasse { get { return strasse; } set { strasse = value; } }
        public List<Stellplatz> Stellplatzliste { get { return stellplatzliste; } }

        public void addStellplatz(int aNummer, string aStellplatztyp, bool aIstBelegt)
        {
            stellplatzliste.Add(new Stellplatz(aNummer, aStellplatztyp, aIstBelegt));
        }

       

    }
}
