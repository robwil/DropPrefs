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
            txtDropboxFolderLocation.Text = folderBrowserDialog.SelectedPath;
            _preferenceLocations.DropboxLocation = txtDropboxFolderLocation.Text;
        }

        private void btnBrowseGlobal_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Choose where to save Global Preferences file";
            saveFileDialog.FileName = "GlobalPrefs.js";
            saveFileDialog.InitialDirectory = _preferenceLocations.DropboxLocation;
            saveFileDialog.ShowDialog();
            txtGlobalPreferenceFileLocation.Text = saveFileDialog.FileName;
            _preferenceLocations.GlobalPreferenceLocation = txtGlobalPreferenceFileLocation.Text;
        }

        private void btnBrowseLocal_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Choose where to save Local Preferences file";
            saveFileDialog.FileName = "LocalPrefs.js";
            saveFileDialog.ShowDialog();
            txtLocalPreferenceFileLocation.Text = saveFileDialog.FileName;
            _preferenceLocations.LocalPreferenceLocation = txtLocalPreferenceFileLocation.Text;
        }
    }
}
