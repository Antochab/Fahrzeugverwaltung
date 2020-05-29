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
            this.panel1.Controls.Add(this.buttonAlleDaten);
            this.panel1.Controls.Add(this.buttonFahrzeugDaten);
            this.panel1.Location = new System.Drawing.Point(255, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 202);
            this.panel1.TabIndex = 2;
            // 
            // FormDatenAusgeben
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormDatenAusgeben";
            this.Text = "FormDatenAusgeben";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAlleDaten;
        private System.Windows.Forms.Button buttonFahrzeugDaten;
        private System.Windows.Forms.Panel panel1;
    }
}