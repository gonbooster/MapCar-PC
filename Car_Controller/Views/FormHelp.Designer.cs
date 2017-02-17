namespace Car_Controller.View
{
    partial class FormHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp));
            this.create_lbl = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.license_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // create_lbl
            // 
            this.create_lbl.AutoSize = true;
            this.create_lbl.Location = new System.Drawing.Point(15, 21);
            this.create_lbl.Name = "create_lbl";
            this.create_lbl.Size = new System.Drawing.Size(199, 13);
            this.create_lbl.TabIndex = 0;
            this.create_lbl.Text = "Created by: Gonzalo del Palacio Jiménez";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Location = new System.Drawing.Point(15, 48);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(156, 13);
            this.email_label.TabIndex = 1;
            this.email_label.Text = "Email: delpalacio91@gmail.com";
            // 
            // license_label
            // 
            this.license_label.AutoSize = true;
            this.license_label.Location = new System.Drawing.Point(15, 76);
            this.license_label.Name = "license_label";
            this.license_label.Size = new System.Drawing.Size(50, 13);
            this.license_label.TabIndex = 2;
            this.license_label.Text = "License: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Car_Controller.Properties.Resources.by_petit;
            this.pictureBox1.Location = new System.Drawing.Point(62, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 42);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 146);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.license_label);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.create_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHelp";
            this.Text = "Help";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHelp_FormClosed);
            this.Load += new System.EventHandler(this.FormHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label create_lbl;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label license_label;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}