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
    public class ChefConfig : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.HasMany(c => c.ChefSocialMedias)
                .WithOne(csm => csm.Chef).HasForeignKey(csm=>csm.ChefId);
        }
    }
}
