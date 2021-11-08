using Jiex.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.EntityConfig.Home
{
    public class DiscussionsConfig : IEntityTypeConfiguration<Discussions>
    {
        public void Configure(EntityTypeBuilder<Discussions> builder)
        {
            builder.ToTable("Discussions");
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.Slug).HasMaxLength(255);
            builder.Property(x => x.Ids).HasMaxLength(255);
        }
    }
}
