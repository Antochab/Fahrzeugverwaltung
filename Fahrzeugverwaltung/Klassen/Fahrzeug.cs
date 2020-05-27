﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Fahrzeugverwaltung
{
    abstract class Fahrzeug
    {
        protected string hersteller, modell, kennzeichen;
        protected int erstzulassung;
        protected float anschaffungspreis;


        public Fahrzeug(string aHersteller, string aModell, string aKennzeichen, int aErstzulassung, float aAnschaffungspreis)
        {
            hersteller = aHersteller;
            modell = aModell;
            kennzeichen = aKennzeichen;
            erstzulassung = aErstzulassung;
            anschaffungspreis = aAnschaffungspreis;
        }

        public String Hersteller{ get { return hersteller; } set { hersteller = value; } }
        public String Modell { get { return modell; } set { modell = value; } }
        public String Kennzeichen { get { return kennzeichen; } set { kennzeichen = value; } }
        public int Erstzulassung { get { return erstzulassung; } set { erstzulassung = value; } }
        public float Anschaffungspreis { get { return anschaffungspreis; } set { anschaffungspreis = value; } }





    }
}