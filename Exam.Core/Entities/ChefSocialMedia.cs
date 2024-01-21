using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Entities
{
    public class ChefSocialMedia : BaseEntity
    {
        public int ChefId { get; set; }
        public int SocialMediaId { get; set; }

        public string SocialMediaUrl { get; set; }

        public Chef Chef { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}
