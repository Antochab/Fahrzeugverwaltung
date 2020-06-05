﻿using Fahrzeugverwaltung.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrzeugverwaltung
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Hauptmenu());

           /*
            //Testen, ob Suche Fahrzeug funktioniert
                        PKW f2= new PKW("Ford", "Focus", "67890", 13, 1100.5f, 1, 1, 1);
                        List<Fahrzeug> testliste = new List<Fahrzeug>();
                        testliste.Add(f1);
                        testliste.Add(f2);
                        Fahrzeugpool fp = new Fahrzeugpool(testliste);
                        Fahrzeug f3 = fp.sucheFahrzeug("12345");
                        Console.Write("Marke: {0}",f3.Hersteller );
            */
        }
    }
}
