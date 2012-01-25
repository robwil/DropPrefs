using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DropPrefs
{
    [DataContract]
    public class LocalPreferences
    {        
        [DataMember]
        public Dictionary<string, LocalAppProfile> LocalAppProfiles { get; set; }

        public LocalPreferences()
        {
            LocalAppProfiles = new Dictionary<string, LocalAppProfile>();
        }
    }
}
