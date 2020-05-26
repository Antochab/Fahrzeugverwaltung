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

        public int Nummer { get { return nummer; } set { nummer = value; } }
        public String Stellplatztyp { get { return stellplatzTyp; } set { stellplatzTyp = value; } }
    }

}
