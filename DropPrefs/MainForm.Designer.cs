﻿namespace DropPrefs
{
    partial class MainForm
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
            this.btnCreateAppProfile = new System.Windows.Forms.Button();
            this.btnMapProfileLocally = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstAppProfiles = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnCreateAppProfile
            // 
            this.btnCreateAppProfile.Location = new System.Drawing.Point(12, 25);
            this.btnCreateAppProfile.Name = "btnCreateAppProfile";
            this.btnCreateAppProfile.Size = new System.Drawing.Size(145, 23);
            this.btnCreateAppProfile.TabIndex = 0;
            this.btnCreateAppProfile.Text = "1. Create App Profile";
            this.btnCreateAppProfile.UseVisualStyleBackColor = true;
            // 
            // btnMapProfileLocally
            // 
            this.btnMapProfileLocally.Location = new System.Drawing.Point(163, 25);
            this.btnMapProfileLocally.Name = "btnMapProfileLocally";
            this.btnMapProfileLocally.Size = new System.Drawing.Size(145, 23);
            this.btnMapProfileLocally.TabIndex = 1;
            this.btnMapProfileLocally.Text = "2. Map Profile Locally";
            this.btnMapProfileLocally.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(12, 501);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(145, 23);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "3. Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Backing up App content";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Restoring App content";
            // 
            // lstAppProfiles
            // 
            this.lstAppProfiles.Location = new System.Drawing.Point(12, 54);
            this.lstAppProfiles.Name = "lstAppProfiles";
            this.lstAppProfiles.Size = new System.Drawing.Size(296, 428);
            this.lstAppProfiles.TabIndex = 5;
            this.lstAppProfiles.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 531);
            this.Controls.Add(this.lstAppProfiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnMapProfileLocally);
            this.Controls.Add(this.btnCreateAppProfile);
            this.Name = "MainForm";
            this.Text = "DropPrefs";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateAppProfile;
        private System.Windows.Forms.Button btnMapProfileLocally;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstAppProfiles;
    }
}

