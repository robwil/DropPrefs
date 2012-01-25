using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DropPrefs
{
    public partial class CreateAppProfile : Form
    {
        public AppProfile NewAppProfile;
        private readonly List<string> _linkedFiles; 

        public CreateAppProfile()
        {
            InitializeComponent();
            NewAppProfile = null;
            _linkedFiles = new List<string>();
        }

        private void BtnBrowseClick(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            foreach (string fileName in openFileDialog.FileNames)
            {
                lstLinkedFiles.Items.Add(fileName);
                _linkedFiles.Add(fileName);
            }
        }

        private void BtnClearFilesClick(object sender, EventArgs e)
        {
            _linkedFiles.Clear();
            lstLinkedFiles.Items.Clear();
        }

        private void BtnSaveAppProfileClick(object sender, EventArgs e)
        {
            NewAppProfile = new AppProfile(txtAppName.Text, _linkedFiles);
            Close();
        }
    }
}
