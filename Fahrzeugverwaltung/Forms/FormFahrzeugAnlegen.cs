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
        private readonly Fahrzeugpool fahrzeugpool = new Fahrzeugpool();
        private readonly String fahrzeugtyp;
        public FormFahrzeugAnlegen(String aFahrzeugtyp)
        {
            InitializeComponent();
            fahrzeugtyp = aFahrzeugtyp;
        }

        //Hinzufügen eines neuen Fahrzeugs
        //TODO select case oder if case zur abfrage des momentanen Fahrzeugs...
        private void ButtonAnlegen_Click(object sender, EventArgs e)
        {
            switch (fahrzeugtyp)
            {
                case "PKW":
                    //Luca: hier würde ich die Exception behandeln
                    fahrzeugpool.neuenPKWAnlegen(textBoxHersteller.Text, textBoxModell.Text, textBoxKennzeichen.Text, Convert.ToInt32(textBoxZulassung.Text), float.Parse(textBoxAnschaffungspreis.Text), Convert.ToInt32(textBoxHubraum.Text), Convert.ToInt32(textBoxLeistung.Text), Convert.ToInt32(textBoxSchadstoffklasse.Text));
                    break;

                case "Motorrad":

                    break;

                case "LKW":

                    break;
            }
        }

        private void ButtonAbbrechen_Click(object sender, EventArgs e)
        {
            Console.WriteLine(fahrzeugpool.Fahrzeugliste.Count());
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
