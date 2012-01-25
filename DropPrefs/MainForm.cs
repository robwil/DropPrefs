using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace DropPrefs
{
    public partial class MainForm : Form
    {
        private PreferenceLocations _preferenceLocations;

        public MainForm()
        {
            InitializeComponent();

            _preferenceLocations = new PreferenceLocations();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            if (!LoadPreferences())
            {
                InitialSetupForm form = new InitialSetupForm(_preferenceLocations);
                form.ShowDialog();                
            }

            lstAppProfiles.View = View.Details;
            lstAppProfiles.Columns.Add("Application Name");
            lstAppProfiles.Columns.Add("Profile Status");

            lstAppProfiles.Items.Add("Test");
            lstAppProfiles.Items[0].SubItems.Add("Test2");
        }

        /**
         * Load the PreferenceLocations.cs file to learn where GlobalPreferences.cs
         * and LocalPreferences.cs are, and then load them as well.
         **/
        private bool LoadPreferences()
        {
            using (FileStream fileStream = new FileStream("PreferenceLocations.js", FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length == 0)
                    return false;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PreferenceLocations));
                _preferenceLocations = serializer.ReadObject(fileStream) as PreferenceLocations;                
            }
            // Invalid or non-existent Preference Locations, so return False. Will cause Initial Setup wizard to be used.
            if (_preferenceLocations != null && (_preferenceLocations.GlobalPreferenceLocation.Length <= 0 || _preferenceLocations.LocalPreferenceLocation.Length <= 0))
                return false;

            return true;
        }
    }
}
