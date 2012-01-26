using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace DropPrefs
{
    public partial class MainForm : Form
    {
        private const string _kPreferenceLocationFileName = "PreferenceLocations.js";
        private PreferenceLocations _preferenceLocations;
        private GlobalPreferences _globalPreferences;
        private LocalPreferences _localPreferences;

        public MainForm()
        {
            InitializeComponent();

            // Initialize all local fields
            _preferenceLocations = new PreferenceLocations();
            _globalPreferences = new GlobalPreferences();
            _localPreferences = new LocalPreferences();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            // Attempt to load preference files. If it fails, loads up Initial Setup Form.
            if (LoadPreferences())
            {
                InitialSetupForm form = new InitialSetupForm(_preferenceLocations);
                form.ShowDialog();
                // Save preferences for first (or perhaps subsequent) time, just in case.
                CreateOrSavePreferences();
            }

            // Setup columns for App Profiles ListView.
            lstAppProfiles.Columns.Add("Application Name", 150);
            lstAppProfiles.Columns.Add("Profile Status", 150);

            // Ensure ListView includes profiles just loaded from preference files.
            UpdateAppProfileView();
        }

        /**
         * Load the PreferenceLocations.cs file to learn where GlobalPreferences.cs
         * and LocalPreferences.cs are, and then load them as well.
         *
         * Returns 'true' if the program should show Initial Setup dialog.
         **/
        private bool LoadPreferences()
        {            
            // Read PreferenceLocations.js file and deserialize into PreferenceLocations object for easier usage.            
            using (FileStream fileStream = new FileStream(_kPreferenceLocationFileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length == 0)
                    return true;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PreferenceLocations));
                _preferenceLocations = serializer.ReadObject(fileStream) as PreferenceLocations;                
            }

            // Check if each of the locations are specified. If any are missing, set isMissing to true.
            bool isMissing = (_preferenceLocations == null);
            if (!isMissing)
            {
                if (_preferenceLocations.DropboxLocation == null || _preferenceLocations.DropboxLocation.Length <= 0)
                    isMissing = true;

                if (_preferenceLocations.GlobalPreferenceLocation == null || _preferenceLocations.GlobalPreferenceLocation.Length <= 0)
                    isMissing = true;
                else
                {
                    // If Global Preferences are not missing, then load them.
                    LoadGlobalPreferences();
                }

                if (_preferenceLocations.LocalPreferenceLocation == null || _preferenceLocations.LocalPreferenceLocation.Length <= 0)
                    isMissing = true;
                else
                {
                    // If Local Preferences are not missing, then load them.
                    LoadLocalPreferences();
                }
            }

            return isMissing;
        }

        /**
         * Open GlobalPrefs.js (actual location is coming from LocationPreferences.js)
         * and de-serialize into local field.
         **/
        private void LoadGlobalPreferences()
        {
            using (FileStream fileStream = new FileStream(_preferenceLocations.GlobalPreferenceLocation, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length == 0)
                    return;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GlobalPreferences));
                _globalPreferences = serializer.ReadObject(fileStream) as GlobalPreferences;
            }
        }

        /**
         * Open LocalPrefs.js (actual location is coming from LocationPreferences.js)
         * and de-serialize into local field.
         **/
        private void LoadLocalPreferences()
        {
            using (FileStream fileStream = new FileStream(_preferenceLocations.LocalPreferenceLocation, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length == 0)
                    return;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(LocalPreferences));
                _localPreferences = serializer.ReadObject(fileStream) as LocalPreferences;
            }
        }

        /**
         * If they don't exist, create the preference files at the specified (in PreferenceLocations) locations.
         * If they do exist, save the new values.
         **/
        private void CreateOrSavePreferences()
        {
            // Write Preference Locations to file
            using (FileStream fileStream = new FileStream(_kPreferenceLocationFileName, FileMode.Create, FileAccess.Write))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PreferenceLocations));
                serializer.WriteObject(fileStream, _preferenceLocations);
            }

            // Write Global Preferences to file
            using (FileStream fileStream = new FileStream(_preferenceLocations.GlobalPreferenceLocation, FileMode.Create, FileAccess.Write))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GlobalPreferences));
                serializer.WriteObject(fileStream, _globalPreferences);
            }

            // Write Local Preferences to file
            using (FileStream fileStream = new FileStream(_preferenceLocations.LocalPreferenceLocation, FileMode.Create, FileAccess.Write))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(LocalPreferences));
                serializer.WriteObject(fileStream, _localPreferences);
            }
        }

        /**
         * Ensure that preferences get saved on exit.
         **/
        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            CreateOrSavePreferences();
        }

        /**
         * Create App Profile button was clicked, so launch the appropriate form.
         **/
        private void BtnCreateAppProfileClick(object sender, EventArgs e)
        {
            // Show Create App Profile form.
            CreateAppProfile form = new CreateAppProfile();
            form.ShowDialog();

            // If the user pressed 'Save' the NewAppProfile will be non-null, so let's save it.
            if (form.NewAppProfile != null)
            {
                _globalPreferences.AppProfiles.Add(form.NewAppProfile.AppName, form.NewAppProfile);
                // Force refresh of ListView with newly added profile.
                UpdateAppProfileView();
            }
        }

        /**
         * Map Profile button was clicked, so launch the appropriate form.
         **/
        private void BtnMapProfileLocallyClick(object sender, EventArgs e)
        {
            if (lstAppProfiles.SelectedItems.Count != 1)
            {
                MessageBox.Show(this, "Please select exactly one App Profile before trying to map it.",
                                "Error: Too Many or Too Few Selected Profiles", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // determine App Name of selected ListViewItem
            ListViewItem selectedItem = lstAppProfiles.SelectedItems[0];
            string appName = selectedItem.Text;
            AppProfile appProfile = _globalPreferences.AppProfiles[appName];

            // create and launch Map Profile dialog
            MapProfile form = new MapProfile(_preferenceLocations, appProfile);
            form.ShowDialog();

            // If the user pressed 'Save' the NewAppProfile will be non-null, so let's save it.
            if (form.NewAppProfile != null)
            {
                _localPreferences.LocalAppProfiles.Add(form.NewAppProfile.AppName, form.NewAppProfile);
                // Move the file to the mapped location, and create the actual file link
                MoveAndLinkFiles(form.NewAppProfile);
                // Force refresh of ListView with newly added profile.
                UpdateAppProfileView();
            }
        }

        /**
         * Perform the actual work to make this program function.
         * Moves the file to the mapped location and then creates a link at the original location.
         **/
        private void MoveAndLinkFiles(LocalAppProfile localAppProfile)
        {
            foreach (string filePath in localAppProfile.Files)
            {
                string fileName = Path.GetFileName(filePath);
                if (fileName != null)
                {
                    File.Move(filePath, localAppProfile.LocalFolder + Path.DirectorySeparatorChar + fileName);
                }
            }
        }

        /**
         * Updates the list view to reflect the latest App Profiles
         * in the Global and Local preferences.
         **/
        private void UpdateAppProfileView()
        {
            // Clear ListView so we are starting with a clean slate.
            lstAppProfiles.Items.Clear();

            // Store the profile names (keys) we've seen so we don't display it twice when doing LocalAppProfiles
            List<string> seenProfilesNames = new List<string>();

            foreach (KeyValuePair<string, AppProfile> pair in _globalPreferences.AppProfiles)
            {
                ListViewItem newItem = lstAppProfiles.Items.Add(pair.Key);
                newItem.SubItems.Add(_localPreferences.LocalAppProfiles.ContainsKey(pair.Key)
                                         ? "Mapped"
                                         : "Not Mapped");
                seenProfilesNames.Add(pair.Key);
            }
        }

        private void CtxMenuRemoveAppProfileClick(object sender, EventArgs e)
        {
            // For each selected item, delete it from both the screen (ListView)
            // and Global (or Local) Preferences
            foreach(ListViewItem appProfileItem in lstAppProfiles.SelectedItems)
            {
                string key = appProfileItem.Text;
                lstAppProfiles.Items.RemoveAt(appProfileItem.Index);
                _globalPreferences.AppProfiles.Remove(key);
            }
        }

        
    }
}
