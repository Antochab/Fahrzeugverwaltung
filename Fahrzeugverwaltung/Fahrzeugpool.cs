using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class Fahrzeugpool
    {
        protected List<Fahrzeug> fahrzeugliste = new List<Fahrzeug>();

        public Fahrzeugpool(List<Fahrzeug> aFahrzeugliste)
        {
            fahrzeugliste = aFahrzeugliste;
        }

        public List<Fahrzeug> Fahrzeugliste { get { return fahrzeugliste; } } 


        public void neuesFahrzeug(Fahrzeug f)
        {
            fahrzeugliste.Add(f);
        }
        public Fahrzeug sucheFahrzeug(string kennzeichen)
        {
            Fahrzeug f = fahrzeugliste.Find(x => x.Kennzeichen.Contains(kennzeichen));
            return f;
        }
    }
}
