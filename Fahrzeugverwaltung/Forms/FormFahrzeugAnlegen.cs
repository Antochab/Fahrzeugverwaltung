using Fahrzeugverwaltung.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrzeugverwaltung
{
    public partial class FormFahrzeugAnlegen : Form
    {
        private readonly String fahrzeugtyp;
        private readonly Fahrzeugpool fahrzeugpool;
        public FormFahrzeugAnlegen(Fahrzeugpool aFahrzeugpool, String aFahrzeugtyp)
        {
            InitializeComponent();
            fahrzeugtyp = aFahrzeugtyp;
            fahrzeugpool = aFahrzeugpool;
        }

        //Hinzufügen eines neuen Fahrzeugs
        //TODO select case oder if case zur abfrage des momentanen Fahrzeugs...
        private void ButtonAnlegen_Click(object sender, EventArgs e)
        {
            string hersteller = textBoxHersteller.Text;
            string modell = textBoxModell.Text;
            string kennzeichen = textBoxKennzeichen.Text;
            int erstzulassung = Convert.ToInt32(textBoxZulassung.Text);
            float anschaffungspreis = float.Parse(textBoxAnschaffungspreis.Text);

            switch (fahrzeugtyp)
            {
                case "PKW":
                    //TODO übersichtlicher darstellen
                    fahrzeugpool.neuenPKWAnlegen(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, Convert.ToInt32(textBoxHubraum.Text), Convert.ToInt32(textBoxLeistung.Text), Convert.ToInt32(textBoxSchadstoffklasse.Text));
                    break;

                case "Motorrad":
                    fahrzeugpool.neuesMotorradAnlegen(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, Convert.ToInt32(textBoxHubraum.Text));
                    break;

                case "LKW":
                    fahrzeugpool.neuenLKWAnlegen(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, Convert.ToInt32(textBoxAnzahlAchsen.Text), Convert.ToInt32(textBoxZuladung.Text));
                    break;
            }
        }

        private void ButtonAbbrechen_Click(object sender, EventArgs e)
        {
// Console.WriteLine(fahrzeugpool.fahrzeugliste.Count());
        }

        //Anzeige hängt von der Auswahl im Hauptmenü ab! 
        // TODO Wenn Auto nur entsprechende Felder anzeigen!
        private void FormAutoAnlegen_Load(object sender, EventArgs e)
        {
            switch (fahrzeugtyp)
            {
                case "PKW":
                    labelAnzahlAchsen.Visible = false;
                    labelZuladung.Visible = false;
                    textBoxAnzahlAchsen.Visible = false;
                    textBoxZuladung.Visible = false;
                    break;

                case "Motorrad":
                    labelAnzahlAchsen.Visible = false;
                    labelZuladung.Visible = false;
                    labelLeistung.Visible = false;
                    labelSchadstoffklasse.Visible = false;
                    textBoxAnzahlAchsen.Visible = false;
                    textBoxZuladung.Visible = false;
                    textBoxLeistung.Visible = false;
                    textBoxSchadstoffklasse.Visible = false;
                    break;

                case "LKW":
                    labelLeistung.Visible = false;
                    labelSchadstoffklasse.Visible = false;
                    textBoxLeistung.Visible = false;
                    textBoxSchadstoffklasse.Visible = false;
                    break;
            }

        }
    }
}
