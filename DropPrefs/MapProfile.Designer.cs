namespace DropPrefs
{
    partial class MapProfile
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
            this.btnBrowseLocalFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocalLocation = new System.Windows.Forms.TextBox();
            this.tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSaveMapping = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowseLocalFolder
            // 
            this.btnBrowseLocalFolder.Location = new System.Drawing.Point(241, 28);
            this.btnBrowseLocalFolder.Name = "btnBrowseLocalFolder";
            this.btnBrowseLocalFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLocalFolder.TabIndex = 5;
            this.btnBrowseLocalFolder.Text = "Browse...";
            this.btnBrowseLocalFolder.UseVisualStyleBackColor = true;
            this.btnBrowseLocalFolder.Click += new System.EventHandler(this.BtnBrowseLocalFolderClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Local Folder: [?]";
            this.tooltips.SetToolTip(this.label1, "Browse for a folder inside your Dropbox where all files for this application will" +
                    " be moved.");
            // 
            // txtLocalLocation
            // 
            this.txtLocalLocation.Location = new System.Drawing.Point(12, 28);
            this.txtLocalLocation.Name = "txtLocalLocation";
            this.txtLocalLocation.Size = new System.Drawing.Size(223, 20);
            this.txtLocalLocation.TabIndex = 3;
            // 
            // btnSaveMapping
            // 
            this.btnSaveMapping.Location = new System.Drawing.Point(13, 54);
            this.btnSaveMapping.Name = "btnSaveMapping";
            this.btnSaveMapping.Size = new System.Drawing.Size(303, 23);
            this.btnSaveMapping.TabIndex = 6;
            this.btnSaveMapping.Text = "Save Mapping";
            this.btnSaveMapping.UseVisualStyleBackColor = true;
            this.btnSaveMapping.Click += new System.EventHandler(this.BtnSaveMappingClick);
            // 
            // MapProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 91);
            this.Controls.Add(this.btnSaveMapping);
            this.Controls.Add(this.btnBrowseLocalFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalLocation);
            this.Name = "MapProfile";
            this.Text = "Map Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseLocalFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalLocation;
        private System.Windows.Forms.ToolTip tooltips;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnSaveMapping;
    }
}