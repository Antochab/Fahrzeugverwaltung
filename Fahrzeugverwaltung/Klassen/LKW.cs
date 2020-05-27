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


    }
}
