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

        public List<Fahrzeug> Fahrzeugliste { get { return fahrzeugliste; } } 


        public void neuenPKWAnlegen(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aHubraum, int aLeistung, int aSchadstoffklasse)
        {
            fahrzeugliste.Add(new PKW(aHersteller,aModell,aKennzeichen,aErstzulassung,aAnschaffungspreis,aHubraum,aLeistung,aSchadstoffklasse));

        }
        public Fahrzeug sucheFahrzeug(string kennzeichen)
        {
            Fahrzeug f = fahrzeugliste.Find(x => x.Kennzeichen.Contains(kennzeichen));
            return f;
        }
    }
}
