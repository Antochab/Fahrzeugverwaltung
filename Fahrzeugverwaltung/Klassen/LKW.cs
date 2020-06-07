using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung
{
    class LKW : Fahrzeug
    {
        //festlegen der Variablen der Klasse LKW
        private int achsenAnzahl;
        private float zuladung;

        //Konstruktor anlegen
        //erbt Konstruktor von der Basisklasse Fahrzeug und erweitert diesen um die Achsenanzahl und die Zuladung
        public LKW(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aAchsenanzahl, float aZuladung)
        : base(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis)
        {
            achsenAnzahl = aAchsenanzahl;
            zuladung = aZuladung;
        }

        //Getter und Setter der Klasse LKW
        public int Achsenanzahl { get { return achsenAnzahl; } set { achsenAnzahl = value; } }
        public float Zuladung { get { return zuladung; } set { zuladung = value; } }
    }
}
