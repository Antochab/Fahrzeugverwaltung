using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung
{
    public abstract class Fahrzeug
    {
        protected string hersteller, modell, kennzeichen, stellplatznummer;
        protected int erstzulassung;
        protected float anschaffungspreis;

        public Fahrzeug(string aHersteller, string aModell, string aKennzeichen, int aErstzulassung, float aAnschaffungspreis)
        {
            hersteller = aHersteller;
            modell = aModell;
            kennzeichen = aKennzeichen;
            erstzulassung = aErstzulassung;
            anschaffungspreis = aAnschaffungspreis;
        }

        public String Hersteller { get { return hersteller; } set { hersteller = value; } }
        public String Modell { get { return modell; } set { modell = value; } }
        public String Kennzeichen { get { return kennzeichen; } set { kennzeichen = value; } }
        /// <summary>
        /// TODO
        /// Bei Set Erstzulassung Kriterium setzen,das man in einem bestimmten Bereich bleibt!
        /// </summary>
        public int Erstzulassung { get { return erstzulassung; } set { erstzulassung = value; } }
        public float Anschaffungspreis { get { return anschaffungspreis; } set { anschaffungspreis = value; } }
        public String Stellplatznummer { get { return stellplatznummer; } set { stellplatznummer = value; } }

        public abstract float berechneSteuerschuldKennzeichen(List<Fahrzeug> fahrzeugliste, string kennzeichen);

    }
}
