using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung
{
    class LKW : Fahrzeug
    {
        private int achsenAnzahl;
        private int zuladung;

        public LKW(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aAchsenanzahl, int aZuladung)
        : base(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis)
        {
            achsenAnzahl = aAchsenanzahl;
            zuladung = aZuladung;
        }

        public int Achsenanzahl { get { return achsenAnzahl; } set { achsenAnzahl = value; } }
        public int Zuladung { get { return zuladung; } set { zuladung = value; } }

        public override float berechneSteuerschuldKennzeichen(List<Fahrzeug> fahrzeugliste, string kennzeichen)
        {
            //Prüfen, ob Kennzeichen in der Fahrzeugliste vorhanden ist
            //sonst erfolgt eine Fehlerausgabe

            if ((fahrzeugliste.Exists(x => x.Kennzeichen == kennzeichen)) == false)
            {
                throw new ArgumentException("Kennzeichen nicht vorhanden!");
            }

            //Anlegen der Variablen steuerschuld
            float steuerschuld;
            //Finden des Fahrezugs mit dem übergebenen Kennzeichen
            Fahrzeug f = Fahrzeugpool.sucheFahrzeug(fahrzeugliste, kennzeichen);

            //Konvertieren des Fahrzeugs in den Typ LKW
            //um auf spezifische Variablen der Klasse LKW zugreifen zu können
            LKW l = (LKW)Convert.ChangeType(f, typeof(LKW));
            steuerschuld = l.Zuladung * 100;

            return steuerschuld;
        }


    }
}
