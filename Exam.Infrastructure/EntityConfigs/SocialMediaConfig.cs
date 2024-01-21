using Exam.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Infrastructure.EntityConfigs
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {

        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasMany(sm => sm.ChefSocialMedias)
                .WithOne(csm => csm.SocialMedia)
                .HasForeignKey(csm => csm.SocialMediaId);
        }


    }
}
