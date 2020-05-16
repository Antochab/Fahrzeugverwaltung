using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Fahrzeugverwaltung
{
    class PKW : Fahrzeug
    {
        private int hubraum, leistung, schadstoffklasse; /// Schadstoffklasse nur 1,2,oder 3 erlaubt -> in SET überprüfen


        public PKW(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aHubraum, int aLeistung, int aSchadstoffklasse)
        : base(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis)
        {
            hubraum = aHubraum;
            leistung = aLeistung;
            schadstoffklasse = aSchadstoffklasse; //Property einfügen
        }
    }
}
