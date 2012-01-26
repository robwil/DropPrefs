namespace DropPrefs
{
    partial class CreateAppProfile
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.lstLinkedFiles = new System.Windows.Forms.ListBox();
            this.btnSaveAppProfile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "App Name: [?]";
            this.tooltips.SetToolTip(this.label1, "The name of the application this profile is for. This name will appear on the mai" +
                    "n screen.");
            // 
            // txtAppName
            // 
            this.txtAppName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppName.Location = new System.Drawing.Point(15, 25);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(317, 20);
            this.txtAppName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Linked Files: [?]";
            this.tooltips.SetToolTip(this.label2, "Browse for the files you want to link to this application\'s profile. You can use " +
                    "the \'Add to Files\' multiple times to select files from more than one directory.");
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 64);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Add Files...";
            this.tooltips.SetToolTip(this.btnBrowse, "Add files to the Linked Files. Hold control to select multiple files.");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Location = new System.Drawing.Point(97, 63);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(75, 23);
            this.btnClearFiles.TabIndex = 8;
            this.btnClearFiles.Text = "Clear Files";
            this.tooltips.SetToolTip(this.btnClearFiles, "Clear all linked files, essentially starting over.");
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.BtnClearFilesClick);
            // 
            // lstLinkedFiles
            // 
            this.lstLinkedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLinkedFiles.FormattingEnabled = true;
            this.lstLinkedFiles.Location = new System.Drawing.Point(15, 93);
            this.lstLinkedFiles.Name = "lstLinkedFiles";
            this.lstLinkedFiles.Size = new System.Drawing.Size(317, 199);
            this.lstLinkedFiles.TabIndex = 4;
            // 
            // btnSaveAppProfile
            // 
            this.btnSaveAppProfile.Location = new System.Drawing.Point(15, 298);
            this.btnSaveAppProfile.Name = "btnSaveAppProfile";
            this.btnSaveAppProfile.Size = new System.Drawing.Size(317, 23);
            this.btnSaveAppProfile.TabIndex = 6;
            this.btnSaveAppProfile.Text = "Save App Profile";
            this.btnSaveAppProfile.UseVisualStyleBackColor = true;
            this.btnSaveAppProfile.Click += new System.EventHandler(this.BtnSaveAppProfileClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // CreateAppProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 333);
            this.Controls.Add(this.btnClearFiles);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSaveAppProfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstLinkedFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAppName);
            this.Name = "CreateAppProfile";
            this.Text = "Create App Profile";
            this.Load += new System.EventHandler(this.CreateAppProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tooltips;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.ListBox lstLinkedFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveAppProfile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnClearFiles;
    }
}