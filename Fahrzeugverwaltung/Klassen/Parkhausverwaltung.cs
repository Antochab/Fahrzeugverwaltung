using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Fahrzeugverwaltung.Klassen
{
    public class Parkhausverwaltung
    {
        List<Parkhaus> parkhausliste = new List<Parkhaus>();

        public void neuesParkhausAnlegen(string aOrt, string aPlz, string aStrasse, int aMaxKap, List<Stellplatz> aStellplatzliste)
        {
            if(aMaxKap > aStellplatzliste.Count())
            {
                throw new ArgumentException ("Liste zu groß!");
            }

            parkhausliste.Add(new Parkhaus(aOrt, aPlz, aStrasse, aMaxKap, aStellplatzliste));
        }
    }
}
