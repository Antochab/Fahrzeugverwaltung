
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class Stellplatz
    {
        private int nummer;
        private String stellplatzTyp;
        private String kennzeichen;
        private bool istBelegt;

        public Stellplatz(int aNummer, string aStellplatztyp, bool aIstBelegt)
        {
            nummer = aNummer;
            stellplatzTyp = aStellplatztyp;
            istBelegt = aIstBelegt;
        }

        public int Nummer { get { return nummer; } set { nummer = value; } }
        public String Stellplatztyp { get { return stellplatzTyp; } set { stellplatzTyp = value; } }
        public String Kennzeichen { get { return kennzeichen; } set { kennzeichen = value; } }
        public bool IstBelegt { get { return istBelegt; } set { istBelegt = value;  } }
    }

}
