using System.Runtime.Serialization;

namespace DropPrefs
{
    [DataContract]
    public class PreferenceLocations
    {
        [DataMember]
        public string DropboxLocation { get; set; }

        [DataMember]
        public string GlobalPreferenceLocation { get; set; }

        [DataMember]
        public string LocalPreferenceLocation { get; set; }
    }
}
