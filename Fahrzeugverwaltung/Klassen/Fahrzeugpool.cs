using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    public class Fahrzeugpool
    {
        private List<Fahrzeug> fahrzeugliste = new List<Fahrzeug>();
        private List<Parkhaus> parkhausliste = new List<Parkhaus>(); 

        public void neuenPKWAnlegen(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aHubraum, int aLeistung, int aSchadstoffklasse)
        {
            //neuen PKW zur Liste hinzufügen hinzufügen
            PKW pkw = new PKW(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis, aHubraum, aLeistung, aSchadstoffklasse);
            fahrzeugliste.Add(pkw);
            stellplatzZuweisen(pkw);
        }

        public void neuenLKWAnlegen(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aAchsenAnzahl, int aZuladung)
        {
            //neuen PKW zur Liste hinzufügen hinzufügen
            LKW lkw = new LKW(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis, aAchsenAnzahl, aZuladung);
            fahrzeugliste.Add(lkw);
            stellplatzZuweisen(lkw);
        }

        public void neuesMotorradAnlegen(String aHersteller, String aModell, String aKennzeichen, int aErstzulassung, float aAnschaffungspreis, int aHubraum)
        {
            //neuen PKW zur Liste hinzufügen hinzufügen
            Motorrad motorrad = new Motorrad(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis, aHubraum);
            fahrzeugliste.Add(motorrad);
            stellplatzZuweisen(motorrad);

        }

        public void neuesParkhausAnlegen(string aOrt, string aPlz, string aStrasse)
        {
            parkhausliste.Add(new Parkhaus(aOrt, aPlz, aStrasse));
        }

        public Fahrzeug sucheFahrzeug(string kennzeichen)
        {
            //finden des Fahrzeugs in der Fahrzeugliste
            Fahrzeug f = fahrzeugliste.Find(x => x.Kennzeichen.Contains(kennzeichen));
            //Zurückgeben des Ergebnisses
            return f;
        }

       public float berechneSteuerschuldKennzeichen(string kennzeichen)
        {
            //Anlegen der Variablen steuerschuld
            float steuerschuld;
            //Finden des Fahrezugs mit dem übergebenen Kennzeichen
            Fahrzeug f = sucheFahrzeug(kennzeichen);
            //If Abfrage, um die Steuerschuld in Abhängigkeit des Fahrzeugtyps zu ermitteln
            if(f.GetType().Equals(typeof(PKW)))
            {
                //Konvertieren des Fahrzeugs in den Typ PKW
                //um auf spezifische Variablen der Klasse PKW zugreifen zu können
                PKW p = (PKW)Convert.ChangeType(f, typeof(PKW));
                steuerschuld = (p.Hubraum + 99) / 100 * 10 * (p.Schadstoffklasse + 1);
            }
            else if(f.GetType().Equals(typeof(LKW)))
            {
                //Konvertieren des Fahrzeugs in den Typ LKW
                //um auf spezifische Variablen der Klasse LKW zugreifen zu können
                LKW l = (LKW)Convert.ChangeType(f, typeof(LKW));
                steuerschuld = l.Zuladung * 100;
            }
            else
            {
                //Konvertieren des Fahrzeugs in den Typ Motorrad
                //um auf spezifische Variablen der Klasse Motorrad zugreifen zu können
                Motorrad m = (Motorrad)Convert.ChangeType(f, typeof(Motorrad));
                steuerschuld = (m.Hubraum + 99) / 10 * 20;
            }
            //Zurückgeben des Ergebnisses
            return steuerschuld;
        }

       public float berechneSteuerschuld()
        {
            //TODO Fahrzeuge mit Steuerschulden ausgeben
            float steuerschuld = 0;
            //berechnen der Steuerschuld für jedes Fahrzeug in der Fahrzeugliste
            foreach(Fahrzeug f in fahrzeugliste)
            {
                //addieren des Ergebnis der Berechnung der Steuerschuld auf die Variable Steuerschuld
                steuerschuld = steuerschuld + berechneSteuerschuldKennzeichen(f.Kennzeichen);
            }

            //Zurückgeben des Ergebnisses
            return steuerschuld;
        }

      public void stellplatzZuweisen(Fahrzeug f)
        {
            bool abbruch = false;
            foreach(Parkhaus element in parkhausliste)
            {
                foreach(Stellplatz s in element.Stellplatzliste)
                {
                    string fahrzeugtyp = f.GetType().ToString();
                    if(s.IstBelegt == false)
                    {
                        if(s.Stellplatztyp == fahrzeugtyp)
                        {
                            s.Kennzeichen = f.Kennzeichen;
                            abbruch = true;
                            break;
                        }
                    }
                }
                if(abbruch == true)
                {
                    break;
                }
            }

        }

    }
}
