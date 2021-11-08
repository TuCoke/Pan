using Jiex.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.EntityConfig.Home
{
    public class PostsConfig : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.ToTable("posts");
            builder.Property(x => x.Type).HasMaxLength(255);
            // builder.Property(x => x.Content).HasColumnType("mediumtext");
            builder.Property(x => x.IpAddress).HasMaxLength(255);

        }
    }
}
