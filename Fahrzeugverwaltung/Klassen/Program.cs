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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //Testen, ob Suche Fahrzeug funktioniert
            PKW f1 = new PKW("Mercedes", "A", "12345", 12, 1200.5f, 1, 1, 1);
            PKW f2= new PKW("Ford", "Focus", "67890", 13, 1100.5f, 1, 1, 1);
            List<Fahrzeug> testliste = new List<Fahrzeug>();
            testliste.Add(f1);
            testliste.Add(f2);
            Fahrzeugpool fp = new Fahrzeugpool(testliste);
            Fahrzeug f3 = fp.sucheFahrzeug("12345");
            Console.Write("Marke: {0}",f3.Hersteller );
        }
    }
}
