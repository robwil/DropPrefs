using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DropPrefs
{
    public partial class CreateAppProfile : Form
    {
        public AppProfile NewAppProfile;
        private readonly List<string> _linkedFiles; 
        private readonly bool _isExistingProfile ;

        public CreateAppProfile()
        {
            InitializeComponent();
            NewAppProfile = null;
            _linkedFiles = new List<string>();
            _isExistingProfile = false;
        }

        public CreateAppProfile(AppProfile existingProfile)
        {
            InitializeComponent();
            
            // Create a copy of the existing profile
            NewAppProfile = new AppProfile();
            NewAppProfile.AppName = existingProfile.AppName;
            _linkedFiles = new List<string>(existingProfile.Files);
            NewAppProfile.Files = _linkedFiles;

            // Show those values on the screen
            txtAppName.Text = NewAppProfile.AppName;
            foreach (string fileName in NewAppProfile.Files)
            {
                lstLinkedFiles.Items.Add(fileName);
            }

            _isExistingProfile = true;
        }

        private void BtnBrowseClick(object sender, EventArgs e)
        {
            openFileDialog.Reset();
            openFileDialog.Multiselect = true;
            openFileDialog.ShowDialog();

            foreach (string fileName in openFileDialog.FileNames)
            {
                lstLinkedFiles.Items.Add(fileName);
                _linkedFiles.Add(fileName);
            }
        }

        private void BtnClearFilesClick(object sender, EventArgs e)
        {
            if (_isExistingProfile)
            {
                MessageBox.Show("You cannot remove files when editing an App Profile, but only add new files.",
                                "Cannot remove files", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _linkedFiles.Clear();
                lstLinkedFiles.Items.Clear();
            }
        }

        private void BtnSaveAppProfileClick(object sender, EventArgs e)
        {
            NewAppProfile = new AppProfile(txtAppName.Text, _linkedFiles);
            Close();
        }
    }
}
