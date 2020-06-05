using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Fahrzeugverwaltung.Klassen
{
    public class Parkhausverwaltung
    {
        private List<Parkhaus> parkhausliste = new List<Parkhaus>();

        public void neuesParkhausAnlegen(string aOrt, string aPlz, string aStrasse, int aMaxKap, String aParkhausnummer, List<Stellplatz> aStellplatzliste)
        {
            if(aMaxKap > aStellplatzliste.Count())
            {
                throw new ArgumentException ("Liste zu groß!");
            }
            if ((parkhausliste.Exists(x => x.Parkhausnummer == aParkhausnummer)) == false)
            {
                throw new ArgumentException("Kennzeichen nicht vorhanden!");
            }

            parkhausliste.Add(new Parkhaus(aOrt, aPlz, aStrasse, aMaxKap, aParkhausnummer, aStellplatzliste));
        }
    }
}
