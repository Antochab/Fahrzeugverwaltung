using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class Motorrad : Fahrzeug
    {
        private int hubraum;

        public Motorrad(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aHubraum)
        : base(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis)
        {
            hubraum = aHubraum;
        }
        public int Hubraum { get { return hubraum; } set { hubraum = value; } }

        public override float berechneSteuerschuldKennzeichen(List<Fahrzeug> fahrzeugliste, string kennzeichen)
        {
            //Anlegen der Variablen steuerschuld
            float steuerschuld;
            //Finden des Fahrezugs mit dem übergebenen Kennzeichen
            Fahrzeug f = Fahrzeugpool.sucheFahrzeug(fahrzeugliste, kennzeichen);

            if ((fahrzeugliste.Exists(x => x.Kennzeichen == kennzeichen)) == false)
            {
                throw new ArgumentException("Kennzeichen nicht vorhanden!");
            }

            //Konvertieren des Fahrzeugs in den Typ Motorrad
            //um auf spezifische Variablen der Klasse Motorrad zugreifen zu können
            Motorrad m = (Motorrad)Convert.ChangeType(f, typeof(Motorrad));
            steuerschuld = (m.Hubraum + 99) / 10 * 20;
            return steuerschuld;
        }

    }

}
