﻿using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung
{
    public class Parkhaus
    {
        private String ort, plz;
        private String parkhausnummer;
        //maximale Kapazität als Readonly, damit sie nicht verändert werden kann
        private int anzahlPKW, anzahlMotorrad, anzahlLKW;
        protected List<Stellplatz> stellplatzliste = new List<Stellplatz>();

        public Parkhaus(string aOrt, string aPlz, String aParkhausnummer, int aAnzahlPKW, int aAnzahlMotorrad, int aAnzahlLKW)
        {
            ort = aOrt;
            plz = aPlz;
            parkhausnummer = aParkhausnummer;
            anzahlPKW = aAnzahlPKW;
            anzahlMotorrad = aAnzahlMotorrad;
            anzahlLKW = aAnzahlLKW;
            Stellplatzliste = stellplaetzeAnlegen(aAnzahlPKW, aAnzahlMotorrad, aAnzahlLKW);
        }

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
            int gesamtanzahl = anzahlPKW + anzahlMotorrad + anzahlLKW;
            int motorrad = anzahlPKW + anzahlMotorrad;
            for (int i = 0; i <= gesamtanzahl; i++)
            {
                if (i < anzahlPKW)
                {
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "Fahrzeugverwaltung.PKW", false, parkhausnummer));
                }
                else if (i < motorrad)
                {
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "Fahrzeugverwaltung.Motorrad", false, parkhausnummer));
                }
                else
                {
                    lStellplatzliste.Add(new Stellplatz(Parkhausnummer + i.ToString(), "Fahrzeugverwaltung.LKW", false, parkhausnummer));
                }
            }

            return lStellplatzliste;
        }

    }
}
