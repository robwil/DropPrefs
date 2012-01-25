using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DropPrefs
{
    [DataContract]
    public class GlobalPreferences
    {
        [DataMember]
        public List<AppProfile> AppProfiles { get; set; }
    }

    
}
