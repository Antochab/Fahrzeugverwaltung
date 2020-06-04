using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class LKW : Fahrzeug
    {
        private int achsenAnzahl;
        private int zuladung;

        public LKW(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aAchsenanzahl, int aZuladung)
        :base(aHersteller,aModell,aKennzeichen,aErstzulassung,aAnschaffungspreis)        {
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
            //Konvertieren des Fahrzeugs in den Typ Motorrad
            //um auf spezifische Variablen der Klasse Motorrad zugreifen zu können
            Motorrad m = (Motorrad)Convert.ChangeType(f, typeof(Motorrad));
            steuerschuld = (m.Hubraum + 99) / 10 * 20;
            return steuerschuld;
        }


    }
}
