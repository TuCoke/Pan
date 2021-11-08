using Jiex.EFcore;
using System;
using System.Collections.Generic;

namespace Jiex.Entities
{
    public partial class Discussions:BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Ids { get; set; }
    }
}
