using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung
{
    public abstract class Fahrzeug
    {
        //Variablen der Klasse festlegen
        protected string hersteller, modell, kennzeichen, stellplatznummer;
        protected int erstzulassung;
        protected float anschaffungspreis;

        //Konstruktor der Klasse Fahrzeig
        public Fahrzeug(string aHersteller, string aModell, string aKennzeichen, int aErstzulassung, float aAnschaffungspreis)
        {
            hersteller = aHersteller;
            modell = aModell;
            kennzeichen = aKennzeichen;
            erstzulassung = aErstzulassung;
            anschaffungspreis = aAnschaffungspreis;
        }

        //Getter und Setter Methoden für die Variablen der Klasse
        public String Hersteller { get { return hersteller; } set { hersteller = value; } }
        public String Modell { get { return modell; } set { modell = value; } }
        public String Kennzeichen { get { return kennzeichen; } set { kennzeichen = value; } }
        public int Erstzulassung { get { return erstzulassung; } set { erstzulassung = value; } }
        public float Anschaffungspreis { get { return anschaffungspreis; } set { anschaffungspreis = value; } }
        public String Stellplatznummer { get { return stellplatznummer; } set { stellplatznummer = value; } }

        

    }
}
