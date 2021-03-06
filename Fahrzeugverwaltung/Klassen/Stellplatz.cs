﻿/// <head>
/// Diese Klasse beinhaltet die Eigenschaften eines Stellplatzes sowie die Getter und Setter Methoden.
/// Sie repräsentiert einen Stellplatz, welcher in einem Parkhaus existieren kann.
/// </head>
using System;

namespace Fahrzeugverwaltung
{
    public class Stellplatz
    {
        //Variablen der Klasse Stellplatz festlegen
        private String nummer;
        private String stellplatzTyp;
        private String kennzeichen;
        private bool istBelegt;
        private String parkhausnummer;

        //Festlegen des Konstruktors der Klasse Stellplatz
        public Stellplatz(String aNummer, String aStellplatztyp, bool aIstBelegt, String aParkhausnummer)
        {
            nummer = aNummer;
            stellplatzTyp = aStellplatztyp;
            istBelegt = aIstBelegt;
            Parkhausnummer = aParkhausnummer;
        }

        //Erstellen der Getter und Setter der Klasse
        public String Nummer { get { return nummer; } set { nummer = value; } }
        public String Parkhausnummer { get { return parkhausnummer; } set { parkhausnummer = value; } }
        public String Stellplatztyp { get { return stellplatzTyp; } set { stellplatzTyp = value; } }
        public String Kennzeichen { get { return kennzeichen; } set { kennzeichen = value; } }
        public bool IstBelegt { get { return istBelegt; } set { istBelegt = value; } }
    }

}
