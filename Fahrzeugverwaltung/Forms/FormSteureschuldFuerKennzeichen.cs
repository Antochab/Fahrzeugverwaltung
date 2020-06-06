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
    public partial class FormSteureschuldFuerKennzeichen : Form
    {
        private readonly Fahrzeugpool fahrzeugpool;
        public FormSteureschuldFuerKennzeichen(Fahrzeugpool aFahrzeugpool)
        {
            InitializeComponent();
            fahrzeugpool = aFahrzeugpool;
        }

        private void buttonSteuerBerechnen_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxSteuerschuld.Text = ;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
