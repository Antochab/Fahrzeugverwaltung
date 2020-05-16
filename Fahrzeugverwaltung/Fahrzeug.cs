using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Fahrzeugverwaltung
{
    abstract class Fahrzeug
    {
        protected String hersteller, modell, kennzeichen;
        protected int erstzulassung;
        protected float anschaffungspreis;


        public Fahrzeug(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis)
        {
            hersteller = aHersteller;
            modell = aModell;
            kennzeichen = aKennzeichen;
            erstzulassung = aErstzulassung;
            anschaffungspreis = aAnschaffungspreis;
        }



    }
}
