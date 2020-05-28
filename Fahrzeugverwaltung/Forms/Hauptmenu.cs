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
    public partial class Hauptmenu : Form
    {
        public Hauptmenu()
        {
            InitializeComponent();
        }

        private void buttonFahrzeugAnlegen_Click(object sender, EventArgs e)
        {
            SubMenuFahrzeugAnlegen subMenuFahrzeugAnlegen = new SubMenuFahrzeugAnlegen();
            subMenuFahrzeugAnlegen.Show();
        }
    }
}
