using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DropPrefs
{
    [DataContract]
    public class GlobalPreferences
    {
        [DataMember]
        public Dictionary<string, AppProfile> AppProfiles { get; set; }

        public GlobalPreferences()
        {
            AppProfiles = new Dictionary<string, AppProfile>();
        }
    }
}
