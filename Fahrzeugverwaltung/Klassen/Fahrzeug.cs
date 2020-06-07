/// <head>
/// Diese Klasse enthält alle relevanten Informationen, die für alle Fahrzeuge gespeichert werden müssen. Sie stellt
/// dabei die Basisklasse für die Klassen PKW, LKW und Motorrad dar, welche alle von dieser Klasse abgeleitet werden
/// und diese um ihre eigenen Attribute erweitern.
/// </head>

using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung
{
    public abstract class Fahrzeug
    {
        //Variablen der Klasse festlegen
        protected String hersteller, modell, kennzeichen, stellplatznummer;
        protected int erstzulassung;
        protected float anschaffungspreis;

        //Konstruktor der Klasse Fahrzeig
        public Fahrzeug(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis)
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
