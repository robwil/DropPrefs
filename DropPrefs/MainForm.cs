using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

/**
 * TODO:
 *      - Restore feature.
 *      - Allow re-mapping.
 *      - Allow un-mapping (move all linked files to original location, deleting sym links).
 *      - Add compression to JSON files.
 *      - Crowd Sourcing feature. Will require some srs thinking.
 **/

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
         * Import CreateSymbolicLink API call
         **/
        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);
        //[DllImport("kernel32.dll", SetLastError = true)]
        //static extern int GetFinalPathNameByHandle(IntPtr handle, [In, Out] StringBuilder path, int bufLen, int flags);

        /**
         * Perform the actual work to make this program function.
         * Moves the file to the mapped location and then creates a link at the original location.
         * This method gets run when a profile is first mapped, and then any time the profile gets editted.
         * Therefore, it needs to be idempotent.
         **/
        private void MoveAndLinkFiles(LocalAppProfile localAppProfile)
        {
            foreach (string filePath in localAppProfile.Files)
            {
                // Construct new file path (in Dropbox)
                string fileName = Path.GetFileName(filePath);
                if (fileName != null)
                {
                    string newPath = localAppProfile.LocalFolder + Path.DirectorySeparatorChar + fileName;

                    // Check if file is already link
                    FileAttributes attributes = File.GetAttributes(filePath);
                    if (attributes.HasFlag(FileAttributes.ReparsePoint))
                    {
                        //using (FileStream fs = File.OpenRead(filePath))
                        // {
                        //      // get the target of the symbolic link
                        //     StringBuilder path = new StringBuilder(512);
                        //    GetFinalPathNameByHandle(fs.SafeFileHandle.DangerousGetHandle(), path, path.Capacity, 0);
                        //     fs.Close();
                        //    string linkTargetPath = path.ToString();
                        //     // delete the symbolic link, then move target file to symbolic link location
                        //File.Delete(filePath);
                        //File.Move(newPath, filePath);

                        // Do nothing
                    }
                    else
                    {

                        // Move file to new path in Dropbox
                        File.Move(filePath, newPath);

                        // Create symbolic link from old path to new path.
                        if (!CreateSymbolicLink(filePath, newPath, 0))
                            MessageBox.Show("Failed to create symbolic link from " + newPath + " to " + filePath,
                                            "Error: Failed to create link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Problem with filename parsing. Make sure you use the browse windows to enter all directory and filenames.",
                        "Error: Failed to Parse Filename", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        /**
         * When the user right-clicks an App Profile and chooses Edit, launch the
         * Create App Profile form with the existing information preloaded.
         **/
        private void CtxMenuEditAppProfileClick(object sender, EventArgs e)
        {
            if (lstAppProfiles.SelectedItems.Count != 1)
            {
                MessageBox.Show(this, "Please select exactly one App Profile before trying to edit it.",
                                "Error: Too Many or Too Few Selected Profiles", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Get the AppProfile which corresponds with the selected row
            ListViewItem selectedItem = lstAppProfiles.SelectedItems[0];
            string appName = selectedItem.Text;
            AppProfile appProfile = _globalPreferences.AppProfiles[appName];

            // Launch the Create App Profile form with the existing profile pre-filled
            CreateAppProfile form = new CreateAppProfile(appProfile);
            form.ShowDialog();

            // Handle the changes, if they were saved (making them non-null).
            if (form.NewAppProfile != null)
            {
                // Remove the profile from Global Preferences keyed by old App Name (in case the name changed)
                _globalPreferences.AppProfiles.Remove(appName);
                // Insert the new App Profile to Global Prefs
                _globalPreferences.AppProfiles.Add(form.NewAppProfile.AppName, form.NewAppProfile);
                // update Local Preferences if needed
                if (_localPreferences.LocalAppProfiles.ContainsKey(appName))
                {
                    string localFolder = _localPreferences.LocalAppProfiles[appName].LocalFolder;
                    _localPreferences.LocalAppProfiles.Remove(appName);
                    _localPreferences.LocalAppProfiles.Add(form.NewAppProfile.AppName, new LocalAppProfile(form.NewAppProfile, localFolder));
                    // Since mapped files may have changed, remap them.
                    MoveAndLinkFiles(_localPreferences.LocalAppProfiles[form.NewAppProfile.AppName]);
                }
                // Update screen
                UpdateAppProfileView();
            }
        }

        /**
         * When the user right-clicks an App Profile and chooses Remove, delete it from
         * the Global/Local preferences and the screen (ListView).
         **/
        private void CtxMenuRemoveAppProfileClick(object sender, EventArgs e)
        {
            // For each selected item, delete it from both the screen (ListView)
            // and Global (and/or Local) Preferences
            foreach(ListViewItem appProfileItem in lstAppProfiles.SelectedItems)
            {
                string key = appProfileItem.Text;
                lstAppProfiles.Items.RemoveAt(appProfileItem.Index);
                _globalPreferences.AppProfiles.Remove(key);
                _localPreferences.LocalAppProfiles.Remove(key);
            }
        }
        
    }
}
