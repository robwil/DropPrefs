namespace DropPrefs
{
    partial class InitialSetupForm
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
            this.components = new System.ComponentModel.Container();
            this.txtDropboxFolderLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseDropbox = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseGlobal = new System.Windows.Forms.Button();
            this.txtGlobalPreferenceFileLocation = new System.Windows.Forms.TextBox();
            this.btnBrowseLocal = new System.Windows.Forms.Button();
            this.txtLocalPreferenceFileLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.btnSavePreferences = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // txtDropboxFolderLocation
            // 
            this.txtDropboxFolderLocation.Location = new System.Drawing.Point(12, 29);
            this.txtDropboxFolderLocation.Name = "txtDropboxFolderLocation";
            this.txtDropboxFolderLocation.Size = new System.Drawing.Size(317, 20);
            this.txtDropboxFolderLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dropbox Folder Location: [?]";
            this.tooltips.SetToolTip(this.label1, "The location for your Dropbox folder. This will be the start of all further Brows" +
                    "e windows, so it will make your life easier.");
            // 
            // btnBrowseDropbox
            // 
            this.btnBrowseDropbox.Location = new System.Drawing.Point(335, 26);
            this.btnBrowseDropbox.Name = "btnBrowseDropbox";
            this.btnBrowseDropbox.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDropbox.TabIndex = 2;
            this.btnBrowseDropbox.Text = "Browse...";
            this.btnBrowseDropbox.UseVisualStyleBackColor = true;
            this.btnBrowseDropbox.Click += new System.EventHandler(this.BtnBrowseDropboxClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Global Preference File Location: [?]";
            this.tooltips.SetToolTip(this.label2, "The location of your Global Preference File. This is where your application profi" +
                    "les are stored, and probably makes sense to store this in your Dropbox and use t" +
                    "he same one on all your computers.");
            // 
            // btnBrowseGlobal
            // 
            this.btnBrowseGlobal.Location = new System.Drawing.Point(335, 65);
            this.btnBrowseGlobal.Name = "btnBrowseGlobal";
            this.btnBrowseGlobal.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseGlobal.TabIndex = 5;
            this.btnBrowseGlobal.Text = "Browse...";
            this.btnBrowseGlobal.UseVisualStyleBackColor = true;
            this.btnBrowseGlobal.Click += new System.EventHandler(this.btnBrowseGlobal_Click);
            // 
            // txtGlobalPreferenceFileLocation
            // 
            this.txtGlobalPreferenceFileLocation.Location = new System.Drawing.Point(12, 68);
            this.txtGlobalPreferenceFileLocation.Name = "txtGlobalPreferenceFileLocation";
            this.txtGlobalPreferenceFileLocation.Size = new System.Drawing.Size(317, 20);
            this.txtGlobalPreferenceFileLocation.TabIndex = 4;
            // 
            // btnBrowseLocal
            // 
            this.btnBrowseLocal.Location = new System.Drawing.Point(335, 104);
            this.btnBrowseLocal.Name = "btnBrowseLocal";
            this.btnBrowseLocal.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLocal.TabIndex = 8;
            this.btnBrowseLocal.Text = "Browse...";
            this.btnBrowseLocal.UseVisualStyleBackColor = true;
            this.btnBrowseLocal.Click += new System.EventHandler(this.btnBrowseLocal_Click);
            // 
            // txtLocalPreferenceFileLocation
            // 
            this.txtLocalPreferenceFileLocation.Location = new System.Drawing.Point(12, 107);
            this.txtLocalPreferenceFileLocation.Name = "txtLocalPreferenceFileLocation";
            this.txtLocalPreferenceFileLocation.Size = new System.Drawing.Size(317, 20);
            this.txtLocalPreferenceFileLocation.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Local Preference File Location: [?]";
            this.tooltips.SetToolTip(this.label3, "The location of the Local Preference File. This stores the local locations of fil" +
                    "es referenced by the Application Profiles. The idea is that each computer will h" +
                    "ave its own Local Preference File.");
            // 
            // btnSavePreferences
            // 
            this.btnSavePreferences.Location = new System.Drawing.Point(12, 134);
            this.btnSavePreferences.Name = "btnSavePreferences";
            this.btnSavePreferences.Size = new System.Drawing.Size(398, 23);
            this.btnSavePreferences.TabIndex = 9;
            this.btnSavePreferences.Text = "Save Preferences";
            this.btnSavePreferences.UseVisualStyleBackColor = true;
            this.btnSavePreferences.Click += new System.EventHandler(this.BtnSavePreferencesClick);
            // 
            // InitialSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 166);
            this.Controls.Add(this.btnSavePreferences);
            this.Controls.Add(this.btnBrowseLocal);
            this.Controls.Add(this.txtLocalPreferenceFileLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseGlobal);
            this.Controls.Add(this.txtGlobalPreferenceFileLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseDropbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDropboxFolderLocation);
            this.Name = "InitialSetupForm";
            this.Text = "Initial Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDropboxFolderLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseDropbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseGlobal;
        private System.Windows.Forms.TextBox txtGlobalPreferenceFileLocation;
        private System.Windows.Forms.Button btnBrowseLocal;
        private System.Windows.Forms.TextBox txtLocalPreferenceFileLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip tooltips;
        private System.Windows.Forms.Button btnSavePreferences;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}