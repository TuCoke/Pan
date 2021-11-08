using Jiex.EFcore;
using System;
using System.Collections.Generic;

namespace Jiex.Entities
{
    public partial class Posts : BaseEntity
    {
        public uint DiscussionId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string IpAddress { get; set; }

    }
}
