using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahrzeugverwaltung.Forms
{
    public partial class Form_Steureschuld_fuer_Kennzeichen : Form
    {
        private readonly Fahrzeugpool fahrzeugpool;
        public Form_Steureschuld_fuer_Kennzeichen(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void buttonSteuerBerechnen_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxSteuerschuld.Text = fahrzeugpool.berechneSteuerschuldKennzeichen(textBoxKennzeichen.Text).ToString();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
