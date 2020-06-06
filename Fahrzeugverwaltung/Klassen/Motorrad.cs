using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung
{
    class Motorrad : Fahrzeug
    {
        //Anlegen der Variablen der Klasse
        private int hubraum;

        //Festlegen des Konstruktors der von der Basisklasse Fahrzeug abgeleitet wird
        //Konstruktor wird erweitert um die Variable Hubraum
        public Motorrad(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aHubraum)
        : base(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis)
        {
            hubraum = aHubraum;
        }

        //Getter und Setter für die Variable der Klasse Motorrad
        public int Hubraum { get { return hubraum; } set { hubraum = value; } }
    }

}
