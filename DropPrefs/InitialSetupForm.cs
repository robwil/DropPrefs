using System;
using System.Windows.Forms;
using DropPrefs.Properties;

namespace DropPrefs
{
    public partial class InitialSetupForm : Form
    {
        private readonly PreferenceLocations _preferenceLocations;

        public InitialSetupForm(PreferenceLocations preferenceLocations)
        {
            InitializeComponent();
            _preferenceLocations = preferenceLocations;

            // Initialize text boxes with locations read from preference file, in case some existed.
            // (If all exist, it shouldn't launch this Initial Setup at all)
            txtDropboxFolderLocation.Text = _preferenceLocations.DropboxLocation;
            txtGlobalPreferenceFileLocation.Text = _preferenceLocations.GlobalPreferenceLocation;
            txtLocalPreferenceFileLocation.Text = _preferenceLocations.LocalPreferenceLocation;
        }

        private void BtnSavePreferencesClick(object sender, EventArgs e)
        {
            _preferenceLocations.DropboxLocation = txtDropboxFolderLocation.Text;
            _preferenceLocations.GlobalPreferenceLocation = txtGlobalPreferenceFileLocation.Text;
            _preferenceLocations.LocalPreferenceLocation = txtLocalPreferenceFileLocation.Text;
            Close();
        }

        private void BtnBrowseDropboxClick(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Please select your Dropbox folder";
            folderBrowserDialog.ShowDialog();
        }
    }
}
