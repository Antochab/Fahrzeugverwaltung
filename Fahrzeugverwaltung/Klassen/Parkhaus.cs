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
        private String parkhausnummer; 
        //maximale Kapazität als Readonly, damit sie nicht verändert werden kann
        private readonly int maxKap; 
        protected List<Stellplatz> stellplatzliste = new List<Stellplatz>();

        public Parkhaus(string aOrt, string aPlz, string aStrasse, int aMaxKap, String aParkhausnummer, List<Stellplatz> aStellplatzliste)
        {
            ort = aOrt;
            plz = aPlz;
            strasse = aStrasse;
            maxKap = aMaxKap;
            parkhausnummer = aParkhausnummer;
            stellplatzliste = aStellplatzliste;
        }

        public String Ort { get { return ort; } set { ort = value; } }
        public String Plz { get { return plz; } set { plz = value; } }
        public String Strasse { get { return strasse; } set { strasse = value; } }
        public int MaxKap { get { return maxKap; } }
        public String Parkhausnummer { get { return parkhausnummer; }  set { parkhausnummer = value; } }
        public List<Stellplatz> Stellplatzliste { get { return stellplatzliste; } }

        public List<Stellplatz> stellplaetzeAnlegen(int anzahlPKW, int anzahlMotorrad, int anzahlLKW)
        {
            List<Stellplatz> lStellplatzliste = new List<Stellplatz>();
            int gesamtanzahl = anzahlPKW + anzahlMotorrad + anzahlLKW;
            for(int i = 0; i <= gesamtanzahl; i++)
            {
                if(i < anzahlPKW)
                {
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "PKW", false));
                }
                else if(i < anzahlMotorrad)
                {
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "Motorrad", false));
                }
                else
                {
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "LKW", false));
                }
            }

            return lStellplatzliste;
        }

    }
}
