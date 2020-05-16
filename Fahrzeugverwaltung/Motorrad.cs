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

    }

}
