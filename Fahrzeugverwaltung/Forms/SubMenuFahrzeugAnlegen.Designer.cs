namespace Fahrzeugverwaltung.Forms
{
    partial class SubMenuFahrzeugAnlegen
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
            this.buttonPKWAnlegen = new System.Windows.Forms.Button();
            this.buttonMotorradAnlegen = new System.Windows.Forms.Button();
            this.buttonLKWAnlegen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPKWAnlegen
            // 
            this.buttonPKWAnlegen.Location = new System.Drawing.Point(3, 3);
            this.buttonPKWAnlegen.Name = "buttonPKWAnlegen";
            this.buttonPKWAnlegen.Size = new System.Drawing.Size(142, 44);
            this.buttonPKWAnlegen.TabIndex = 0;
            this.buttonPKWAnlegen.Text = "PKW anlegen";
            this.buttonPKWAnlegen.UseVisualStyleBackColor = true;
           // 
            // buttonMotorradAnlegen
            // 
            this.buttonMotorradAnlegen.Location = new System.Drawing.Point(3, 56);
            this.buttonMotorradAnlegen.Name = "buttonMotorradAnlegen";
            this.buttonMotorradAnlegen.Size = new System.Drawing.Size(142, 41);
            this.buttonMotorradAnlegen.TabIndex = 1;
            this.buttonMotorradAnlegen.Text = "Motorrad anlegen";
            this.buttonMotorradAnlegen.UseVisualStyleBackColor = true;
            // 
            // buttonLKWAnlegen
            // 
            this.buttonLKWAnlegen.Location = new System.Drawing.Point(3, 113);
            this.buttonLKWAnlegen.Name = "buttonLKWAnlegen";
            this.buttonLKWAnlegen.Size = new System.Drawing.Size(142, 41);
            this.buttonLKWAnlegen.TabIndex = 2;
            this.buttonLKWAnlegen.Text = "LKW anlegen";
            this.buttonLKWAnlegen.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonPKWAnlegen);
            this.panel1.Controls.Add(this.buttonLKWAnlegen);
            this.panel1.Controls.Add(this.buttonMotorradAnlegen);
            this.panel1.Location = new System.Drawing.Point(327, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 191);
            this.panel1.TabIndex = 3;
            // 
            // SubMenuFahrzeugAnlegen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "SubMenuFahrzeugAnlegen";
            this.Text = "Fahrzeug anlegen";
            this.Load += new System.EventHandler(this.SubMenuFahrzeugAnlegen_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPKWAnlegen;
        private System.Windows.Forms.Button buttonMotorradAnlegen;
        private System.Windows.Forms.Button buttonLKWAnlegen;
        private System.Windows.Forms.Panel panel1;
    }
}