namespace Fahrzeugverwaltung.Forms
{
    partial class FormSteureschuldFuerKennzeichen
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
            this.buttonSteuerBerechnen = new System.Windows.Forms.Button();
            this.textBoxKennzeichen = new System.Windows.Forms.TextBox();
            this.labelKennzeichen = new System.Windows.Forms.Label();
            this.textBoxSteuerschuld = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSteuerBerechnen
            // 
            this.buttonSteuerBerechnen.Location = new System.Drawing.Point(485, 296);
            this.buttonSteuerBerechnen.Name = "buttonSteuerBerechnen";
            this.buttonSteuerBerechnen.Size = new System.Drawing.Size(266, 85);
            this.buttonSteuerBerechnen.TabIndex = 0;
            this.buttonSteuerBerechnen.Text = "Steuer berechnen";
            this.buttonSteuerBerechnen.UseVisualStyleBackColor = true;
            this.buttonSteuerBerechnen.Click += new System.EventHandler(this.buttonSteuerBerechnen_Click);
            // 
            // textBoxKennzeichen
            // 
            this.textBoxKennzeichen.Location = new System.Drawing.Point(76, 93);
            this.textBoxKennzeichen.Name = "textBoxKennzeichen";
            this.textBoxKennzeichen.Size = new System.Drawing.Size(100, 26);
            this.textBoxKennzeichen.TabIndex = 1;
            // 
            // labelKennzeichen
            // 
            this.labelKennzeichen.AutoSize = true;
            this.labelKennzeichen.Location = new System.Drawing.Point(76, 31);
            this.labelKennzeichen.Name = "labelKennzeichen";
            this.labelKennzeichen.Size = new System.Drawing.Size(200, 20);
            this.labelKennzeichen.TabIndex = 2;
            this.labelKennzeichen.Text = "Bitte Kenneichen eingeben";
            // 
            // textBoxSteuerschuld
            // 
            this.textBoxSteuerschuld.Location = new System.Drawing.Point(485, 93);
            this.textBoxSteuerschuld.Name = "textBoxSteuerschuld";
            this.textBoxSteuerschuld.ReadOnly = true;
            this.textBoxSteuerschuld.Size = new System.Drawing.Size(100, 26);
            this.textBoxSteuerschuld.TabIndex = 3;
            // 
            // Form_Steureschuld_fuer_Kennzeichen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxSteuerschuld);
            this.Controls.Add(this.labelKennzeichen);
            this.Controls.Add(this.textBoxKennzeichen);
            this.Controls.Add(this.buttonSteuerBerechnen);
            this.Name = "Form_Steureschuld_fuer_Kennzeichen";
            this.Text = "Form_Steureschuld_fuer_Kennzeichen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSteuerBerechnen;
        private System.Windows.Forms.TextBox textBoxKennzeichen;
        private System.Windows.Forms.Label labelKennzeichen;
        private System.Windows.Forms.TextBox textBoxSteuerschuld;
    }
}