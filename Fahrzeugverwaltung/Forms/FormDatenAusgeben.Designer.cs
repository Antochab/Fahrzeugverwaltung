namespace Fahrzeugverwaltung.Forms
{
    partial class FormDatenAusgeben
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAlleDaten = new System.Windows.Forms.Button();
            this.buttonFahrzeugDaten = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonParkhäuser = new System.Windows.Forms.Button();
            this.buttonStellplätze = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAlleDaten
            // 
            this.buttonAlleDaten.Location = new System.Drawing.Point(64, 3);
            this.buttonAlleDaten.Name = "buttonAlleDaten";
            this.buttonAlleDaten.Size = new System.Drawing.Size(101, 65);
            this.buttonAlleDaten.TabIndex = 0;
            this.buttonAlleDaten.Text = "Alle Daten ausgeben";
            this.buttonAlleDaten.UseVisualStyleBackColor = true;
            this.buttonAlleDaten.Click += new System.EventHandler(this.buttonAlleDaten_Click);
            // 
            // buttonFahrzeugDaten
            // 
            this.buttonFahrzeugDaten.Location = new System.Drawing.Point(64, 74);
            this.buttonFahrzeugDaten.Name = "buttonFahrzeugDaten";
            this.buttonFahrzeugDaten.Size = new System.Drawing.Size(101, 72);
            this.buttonFahrzeugDaten.TabIndex = 1;
            this.buttonFahrzeugDaten.Text = "Bestimmtes Fahrzeug zeigen";
            this.buttonFahrzeugDaten.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonStellplätze);
            this.panel1.Controls.Add(this.buttonParkhäuser);
            this.panel1.Controls.Add(this.buttonAlleDaten);
            this.panel1.Controls.Add(this.buttonFahrzeugDaten);
            this.panel1.Location = new System.Drawing.Point(305, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 265);
            this.panel1.TabIndex = 2;
            // 
            // buttonParkhäuser
            // 
            this.buttonParkhäuser.Location = new System.Drawing.Point(195, 3);
            this.buttonParkhäuser.Name = "buttonParkhäuser";
            this.buttonParkhäuser.Size = new System.Drawing.Size(166, 82);
            this.buttonParkhäuser.TabIndex = 2;
            this.buttonParkhäuser.Text = "Parkhäuser";
            this.buttonParkhäuser.UseVisualStyleBackColor = true;
            this.buttonParkhäuser.Click += new System.EventHandler(this.buttonParkhäuser_Click);
            // 
            // buttonStellplätze
            // 
            this.buttonStellplätze.Location = new System.Drawing.Point(195, 142);
            this.buttonStellplätze.Name = "buttonStellplätze";
            this.buttonStellplätze.Size = new System.Drawing.Size(166, 75);
            this.buttonStellplätze.TabIndex = 3;
            this.buttonStellplätze.Text = "Stellplätze";
            this.buttonStellplätze.UseVisualStyleBackColor = true;
            this.buttonStellplätze.Click += new System.EventHandler(this.buttonStellplätze_Click);
            // 
            // FormDatenAusgeben
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormDatenAusgeben";
            this.Text = "FormDatenAusgeben";
            this.Load += new System.EventHandler(this.FormDatenAusgeben_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAlleDaten;
        private System.Windows.Forms.Button buttonFahrzeugDaten;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonStellplätze;
        private System.Windows.Forms.Button buttonParkhäuser;
    }
}