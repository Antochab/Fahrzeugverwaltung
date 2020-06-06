namespace Fahrzeugverwaltung.Forms
{
    partial class FormParkhäuserAnzeigen
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
            this.listBoxParkhäuser = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxParkhäuser
            // 
            this.listBoxParkhäuser.FormattingEnabled = true;
            this.listBoxParkhäuser.ItemHeight = 20;
            this.listBoxParkhäuser.Location = new System.Drawing.Point(13, 13);
            this.listBoxParkhäuser.Name = "listBoxParkhäuser";
            this.listBoxParkhäuser.Size = new System.Drawing.Size(885, 404);
            this.listBoxParkhäuser.TabIndex = 0;
            // 
            // FormParkhäuserAnzeigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(992, 450);
            this.Controls.Add(this.listBoxParkhäuser);
            this.Name = "FormParkhäuserAnzeigen";
            this.Text = "Parkhäuser";
            this.Load += new System.EventHandler(this.FormParkhäuserAnzeigen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxParkhäuser;
    }
}