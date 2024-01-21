using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Entities
{
    public class Chef : BaseEntity
    {
        public string ChefName { get; set; }
        public string ChefBio { get; set; }

        public string ProfileImageUrl { get; set; }

        public ICollection<ChefSocialMedia> ChefSocialMedias { get; set; }

    }
}
