using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DropPrefs
{
    [DataContract]
    public class LocalPreferences
    {        
        [DataMember]
        public List<LocalAppProfile> LocalAppProfiles { get; set; }
    }
}
