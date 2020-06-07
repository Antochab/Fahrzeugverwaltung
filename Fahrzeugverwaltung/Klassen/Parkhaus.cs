/// <head>
/// Diese Klasse beinhaltet alle relevanten Daten, die über ein Parkhaus abgespeichert werden sollen sowie die
/// dazugehörigen Getter und Setter Methoden. Zudem wird in dieser Klasse das Anlegen von Stellplätzen für das
/// jeweilige Parkhaus ermöglicht.
/// </head>

using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung
{
    public class Parkhaus
    {
        //festlegen der Variablen der Klasse
        private String ort, plz;
        private String parkhausnummer;
        private int anzahlPKW, anzahlMotorrad, anzahlLKW;
        protected List<Stellplatz> stellplatzliste = new List<Stellplatz>();

        //Festlegen des Konstruktors der Klasse Parkhaus
        public Parkhaus(String aOrt, string aPlz, String aParkhausnummer, int aAnzahlPKW, int aAnzahlMotorrad, int aAnzahlLKW)
        {
            ort = aOrt;
            plz = aPlz;
            parkhausnummer = aParkhausnummer;
            anzahlPKW = aAnzahlPKW;
            anzahlMotorrad = aAnzahlMotorrad;
            anzahlLKW = aAnzahlLKW;
            //Stellplatzliste zuweisen erfolgt über den Aufruf der Methode stellplaetzeAnlegen
            Stellplatzliste = stellplaetzeAnlegen(aAnzahlPKW, aAnzahlMotorrad, aAnzahlLKW);
        }
        //festlegen der Getter und Setter der Variablen der Klasse
        public String Ort { get { return ort; } set { ort = value; } }
        public String Plz { get { return plz; } set { plz = value; } }
        public String Parkhausnummer { get { return parkhausnummer; } set { parkhausnummer = value; } }
        public List<Stellplatz> Stellplatzliste { get { return stellplatzliste; } set { stellplatzliste = value; } }
        public int AnzahlPKW { get { return anzahlPKW; } set { anzahlPKW = value; } }
        public int AnzahlMotorrad { get { return anzahlMotorrad; } set { anzahlMotorrad = value; } }
        public int AnzahlLKW { get { return anzahlLKW; } set { anzahlLKW = value; } }


        public List<Stellplatz> stellplaetzeAnlegen(int anzahlPKW, int anzahlMotorrad, int anzahlLKW)
        {
            List<Stellplatz> lStellplatzliste = new List<Stellplatz>();
            //errechnen der Gesamtanzahl der anzulegen
            int gesamtanzahl = anzahlPKW + anzahlMotorrad + anzahlLKW;
            //festlegen der Summe von PKW Stellplätzen und Motorrad Stellplätzen
            //die Differenz zwischen der Anzahl der PKWs und dieser Variable wird verwendet, um die Stellplätze des Typs Motorrad anzulegen
            int motorrad = anzahlPKW + anzahlMotorrad;
            //Über die Gesamtanzahl an Stellplätzen iterieren
            for (int i = 0; i <= gesamtanzahl; i++)
            {
                //prüfen, ob i kleiner als die Anzahl an PKW Stellplätzen ist
                if (i < anzahlPKW)
                {
                    //Stellplätze der Stellplatzliste hinzufügen
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "Fahrzeugverwaltung.PKW", false, parkhausnummer));
                }
                //prüfen, ob i größer als die Anzahl der PKW Stellplätze ist, aber kleiner als die Anzahl der Motorrad Stellplätze
                else if (i < motorrad)
                {
                    //Stellplätze der Stellplatzliste hinzufügen
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "Fahrzeugverwaltung.Motorrad", false, parkhausnummer));
                }
                //ist i größer als die Anzahl der Motorrad Stellplätze, handelt es sich um Stellplätze des Typs LKW
                else
                {
                    //Stellplätze der Stellplatzliste hinzufügen
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "Fahrzeugverwaltung.LKW", false, parkhausnummer));
                }
            }

            //zurückgeben der Stellplatzliste
            return lStellplatzliste;
        }

    }
}
