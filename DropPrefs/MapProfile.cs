using System;
using System.Windows.Forms;

namespace DropPrefs
{
    public partial class MapProfile : Form
    {
        public LocalAppProfile NewAppProfile;
        private readonly PreferenceLocations _preferenceLocations;
        private readonly AppProfile _appProfile;

        public MapProfile(PreferenceLocations preferenceLocations, AppProfile appProfile)
        {
            InitializeComponent();
            _preferenceLocations = preferenceLocations;
            _appProfile = appProfile;
            NewAppProfile = null;
        }

        private void BtnBrowseLocalFolderClick(object sender, EventArgs e)
        {
            // Show a Folder Browser dialog which starts at the user's Dropbox.
            folderBrowserDialog.Description =
                "Browse for a folder inside your Dropbox where all files for this application will be moved.";
            folderBrowserDialog.SelectedPath = _preferenceLocations.DropboxLocation;
            folderBrowserDialog.ShowDialog();

            // Save selected folder to text box.
            txtLocalLocation.Text = folderBrowserDialog.SelectedPath;
        }

        private void BtnSaveMappingClick(object sender, EventArgs e)
        {
            NewAppProfile = new LocalAppProfile(_appProfile, txtLocalLocation.Text);
            Close();
        }
    }
}
