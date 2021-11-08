using Jiex.EFcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.Entities
{
    public class Platform : BaseEntity
    {
        public string _videoPlatform { get; set; }
        public string videoTitle { get; set; }
        public string requestUrl { get; set; }
        public string request301Url { get; set; }
        public string responseUrl { get; set; }

    }
}
