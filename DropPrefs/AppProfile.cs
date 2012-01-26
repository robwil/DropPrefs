using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DropPrefs
{
    [DataContract]
    public class AppProfile
    {
        [DataMember]
        public string AppName { get; set; }

        [DataMember]
        public List<string> Files { get; set; }

        public AppProfile()
        {
            AppName = "";
            Files = new List<string>();
        }

        public AppProfile(string appName, List<string> files)
        {
            AppName = appName;
            Files = files;
        }
    }

    [DataContract]
    public class LocalAppProfile : AppProfile
    {
        [DataMember]
        public string LocalFolder { get; set; }
 
        public LocalAppProfile()
        {
            AppName = "";
            Files = new List<string>();
            LocalFolder = "";
        }

        public LocalAppProfile(AppProfile appProfile, string localFolder)
        {
            AppName = appProfile.AppName;
            Files = new List<string>(appProfile.Files);
            LocalFolder = localFolder;
        }
    }
}
