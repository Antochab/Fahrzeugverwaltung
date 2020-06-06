using System;
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
            string erstzulassung = textBoxZulassung.Text;
            string anschaffungspreis = textBoxAnschaffungspreis.Text;

            try
            {
                switch (fahrzeugtyp)
                {
                    case "PKW":
                        fahrzeugpool.neuenPKWAnlegen(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, textBoxHubraum.Text, textBoxLeistung.Text, textBoxSchadstoffklasse.Text);
                        break;

                    case "Motorrad":
                        fahrzeugpool.neuesMotorradAnlegen(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, textBoxHubraum.Text);
                        break;

                    case "LKW":
                        fahrzeugpool.neuenLKWAnlegen(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis, textBoxAnzahlAchsen.Text, textBoxZuladung.Text);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textBoxHersteller.Clear();
                textBoxModell.Clear();
                textBoxKennzeichen.Clear();
                textBoxZulassung.Clear();
                textBoxAnschaffungspreis.Clear();
                textBoxHubraum.Clear();
                textBoxLeistung.Clear();
                textBoxSchadstoffklasse.Clear();
                textBoxAnzahlAchsen.Clear();
                textBoxZuladung.Clear();

            }
        }

        private void ButtonAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
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
