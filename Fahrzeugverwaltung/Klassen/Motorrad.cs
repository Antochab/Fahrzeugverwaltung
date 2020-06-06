using System;
using System.Collections.Generic;

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
    }

}
