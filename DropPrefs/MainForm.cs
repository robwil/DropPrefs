using System;
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

            _preferenceLocations = new PreferenceLocations();
            _globalPreferences = new GlobalPreferences();
            _localPreferences = new LocalPreferences();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            if (LoadLocationPreferences())
            {
                InitialSetupForm form = new InitialSetupForm(_preferenceLocations);
                form.ShowDialog();
                CreateOrSavePreferences();
            }

            lstAppProfiles.View = View.Details;
            lstAppProfiles.Columns.Add("Application Name", 150);
            lstAppProfiles.Columns.Add("Profile Status", 100);           
        }

        /**
         * Load the PreferenceLocations.cs file to learn where GlobalPreferences.cs
         * and LocalPreferences.cs are, and then load them as well.
         *
         * Returns 'true' if the program should show Initial Setup dialog.
         **/
        private bool LoadLocationPreferences()
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
        private void btnCreateAppProfile_Click(object sender, EventArgs e)
        {
           ListViewItem newItem = lstAppProfiles.Items.Add("Test");
            newItem.SubItems.Add("Test2");
        }
    }
}
