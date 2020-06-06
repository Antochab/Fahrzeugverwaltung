using System;
using System.Collections.Generic;

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
            Schadstoffklasse = aSchadstoffklasse; //Property einfügen
        }

        public int Hubraum { get { return hubraum; } set { hubraum = value; } }
        public int Leistung { get { return leistung; } set { leistung = value; } }
        public int Schadstoffklasse
        {
            get { return schadstoffklasse; }
            set
            {
                //prüfen, ob der eingegebene Wert den Wert 1,2 oder 3 enthält
                if (value == 0 || value == 1 || value == 2)
                {
                    schadstoffklasse = value;
                }
                //falls der Wert keinen dieser Werte darstellt, wird eine Fehlermeldung ausgegeben
                else
                {
                    throw new ArgumentException("Schadstoffklasse nicht vorhanden.");
                }
            }
        }


    }
}
