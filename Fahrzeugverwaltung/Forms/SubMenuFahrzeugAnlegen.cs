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
    public partial class SubMenuFahrzeugAnlegen : Form
    {
        public SubMenuFahrzeugAnlegen()
        {
            InitializeComponent();
        }

    private void SubMenuFahrzeugAnlegen_Load(object sender, EventArgs e)
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.Click += button_Click;
                    
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "buttonPKWAnlegen":
                    FormFahrzeugAnlegen pkwForm = new FormFahrzeugAnlegen("PKW");
                    pkwForm.Show();
            break;
                case "buttonMotorradAnlegen.Name":
                    FormFahrzeugAnlegen motorradForm = new FormFahrzeugAnlegen("Motorrad");
                    motorradForm.Show();
                    break;
                case "buttonLKWAnlegen":
                    FormFahrzeugAnlegen lkwForm = new FormFahrzeugAnlegen("LKW");
                    lkwForm.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
