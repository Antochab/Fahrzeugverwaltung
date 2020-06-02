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

        public void neuenPKWAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aHubraum, String aLeistung, String aSchadstoffklasse)
        {
            int hubraum = 0;
            int leistung = 0;
            int schadstoffklasse = 0;

            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            if (int.TryParse(aHubraum, out hubraum) == false || String.IsNullOrWhiteSpace(aHubraum))
            {
                throw new ArgumentException("Hubraum überprüfen");
            }
            if (int.TryParse(aLeistung, out leistung) == false || String.IsNullOrWhiteSpace(aLeistung))
            {
                throw new ArgumentException("Leistung überprüfen");
            }
            if (int.TryParse(aSchadstoffklasse, out schadstoffklasse) == false || String.IsNullOrWhiteSpace(aSchadstoffklasse))
            {
                throw new ArgumentException("Schadstoffklasse überprüfen");
            }

            try {
                //neuen PKW zur Liste hinzufügen hinzufügen
                PKW pkw = new PKW(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aHubraum), Convert.ToInt32(aLeistung), Convert.ToInt32(aSchadstoffklasse));
                fahrzeugliste.Add(pkw);
                stellplatzZuweisen(pkw);
            } catch
            {
                throw new Exception("Something went wrong");
            }
        }


        public void neuenLKWAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aAchsenAnzahl, String aZuladung)
        {
            int achsenanzahl = 0;
            int zuladung = 0;

            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            if (int.TryParse(aAchsenAnzahl, out achsenanzahl) == false || String.IsNullOrWhiteSpace(aAchsenAnzahl))
            {
                throw new ArgumentException("Achsenanzahl überprüfen");
            }
            if (int.TryParse(aZuladung, out zuladung) == false || String.IsNullOrWhiteSpace(aZuladung))
            {
                throw new ArgumentException("Zuladung überprüfen");
            }

            //neuen PKW zur Liste hinzufügen hinzufügen
            LKW lkw = new LKW(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aAchsenAnzahl), Convert.ToInt32(aZuladung));
            fahrzeugliste.Add(lkw);
            stellplatzZuweisen(lkw);
        }

        public void neuesMotorradAnlegen(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis, String aHubraum)
        {
            int hubraum = 0;

            ExceptionHandling(aHersteller, aModell, aKennzeichen, aErstzulassung, aAnschaffungspreis);

            if (int.TryParse(aHubraum, out hubraum) == false || String.IsNullOrWhiteSpace(aHubraum))
            {
                throw new ArgumentException("Hubraum überprüfen");
            }

            //neuen PKW zur Liste hinzufügen hinzufügen
            Motorrad motorrad = new Motorrad(aHersteller, aModell, aKennzeichen, Convert.ToInt32(aErstzulassung), float.Parse(aAnschaffungspreis), Convert.ToInt32(aHubraum));
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
            //Prüfen, ob Kennzeichen in der Fahrzeugliste vorhanden ist
            //sonst erfolgt eine Fehlerausgabe

            if((fahrzeugliste.Exists(x => x.Kennzeichen == kennzeichen)) == false)
            {
                throw new ArgumentException("Kennzeichen nicht vorhanden!");
            }

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
        private void ExceptionHandling(String aHersteller, String aModell, String aKennzeichen, String aErstzulassung, String aAnschaffungspreis)
        {
            int erstzulassung = 0;
            float anschaffungspreis = 0;

            if (String.IsNullOrEmpty(aHersteller) || String.IsNullOrWhiteSpace(aHersteller))
            {
                throw new ArgumentException("Hersteller überprüfen");
            }
            if (String.IsNullOrEmpty(aModell) || String.IsNullOrWhiteSpace(aModell))
            {
                throw new ArgumentException("Modell überprüfen");
            }
            //Format angeben
            if (String.IsNullOrEmpty(aKennzeichen) || String.IsNullOrWhiteSpace(aKennzeichen))
            {
                throw new ArgumentException("Kennzeichen überprüfen");
            }
            if (int.TryParse(aErstzulassung, out erstzulassung) == false || String.IsNullOrWhiteSpace(aErstzulassung))
            {
                throw new ArgumentException("Erstzulassung überprüfen");
            }
            if (float.TryParse(aAnschaffungspreis, out anschaffungspreis) == false || String.IsNullOrWhiteSpace(aAnschaffungspreis))
            {
                throw new ArgumentException("Anschaffungspreis überprüfen");
            }
        }
        public List<String> gibAlleDatenAus()
        {
            string output = "{0,-15}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-15}\t{5,-15}\t";
            List<String> alleFahrzeugDaten = new List<String>();
            alleFahrzeugDaten.Add(string.Format(output, "Hersteller", "Modell", "Kennzeichen", "Erstzulassaung", "Anschaffungspreis", "Typ"));

            foreach (Fahrzeug fahrzeug in fahrzeugliste)
            {
                alleFahrzeugDaten.Add(string.Format(output, fahrzeug.Hersteller, fahrzeug.Modell, fahrzeug.Kennzeichen, fahrzeug.Erstzulassung.ToString(), fahrzeug.Anschaffungspreis.ToString(), fahrzeug.GetType()));
            }
            return alleFahrzeugDaten;
        }

    }
}

