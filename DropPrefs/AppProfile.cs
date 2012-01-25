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
    }

    [DataContract]
    public class LocalAppProfile : AppProfile
    {
        [DataMember]
        public List<string> LocalFolder { get; set; } 
    }
}
