namespace Fahrzeugverwaltung.Forms
{
    partial class Steuerschulden_berechnen
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
            this.buttonSteuerschuldFuerAlle = new System.Windows.Forms.Button();
            this.buttonFuerKennzeichen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSteuerschuldFuerAlle
            // 
            this.buttonSteuerschuldFuerAlle.Location = new System.Drawing.Point(343, 79);
            this.buttonSteuerschuldFuerAlle.Name = "buttonSteuerschuldFuerAlle";
            this.buttonSteuerschuldFuerAlle.Size = new System.Drawing.Size(155, 90);
            this.buttonSteuerschuldFuerAlle.TabIndex = 0;
            this.buttonSteuerschuldFuerAlle.Text = "alle Steuerschulden berechnen";
            this.buttonSteuerschuldFuerAlle.UseVisualStyleBackColor = true;
            this.buttonSteuerschuldFuerAlle.Click += new System.EventHandler(this.buttonSteuerschuldFuerAlle_Click);
            // 
            // buttonFuerKennzeichen
            // 
            this.buttonFuerKennzeichen.Location = new System.Drawing.Point(343, 198);
            this.buttonFuerKennzeichen.Name = "buttonFuerKennzeichen";
            this.buttonFuerKennzeichen.Size = new System.Drawing.Size(155, 86);
            this.buttonFuerKennzeichen.TabIndex = 1;
            this.buttonFuerKennzeichen.Text = "Steuerschuld für Fahrzeug";
            this.buttonFuerKennzeichen.UseVisualStyleBackColor = true;
            this.buttonFuerKennzeichen.Click += new System.EventHandler(this.buttonFuerKennzeichen_Click);
            // 
            // Steuerschulden_berechnen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonFuerKennzeichen);
            this.Controls.Add(this.buttonSteuerschuldFuerAlle);
            this.Name = "Steuerschulden_berechnen";
            this.Text = "Steuerschulden_berechnen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSteuerschuldFuerAlle;
        private System.Windows.Forms.Button buttonFuerKennzeichen;
    }
}