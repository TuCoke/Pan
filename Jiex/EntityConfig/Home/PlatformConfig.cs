using Jiex.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.EntityConfig.Home
{
    public class PlatformConfig : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.ToTable("platform");
            builder.Property(x => x._videoPlatform).HasMaxLength(255);
            builder.Property(x => x.videoTitle).HasMaxLength(255);
            //builder.Property(x => x.requestUrl).HasMaxLength(255);
            builder.Property(x => x.request301Url).HasMaxLength(255);
            //builder.Property(x=>x.responseUrl).HasMaxLength(255)
        }
    }
}
