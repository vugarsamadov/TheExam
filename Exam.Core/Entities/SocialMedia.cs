using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Entities
{
    public class SocialMedia : BaseEntity
    {

        public string SocialName { get; set; }
        public string SocialIcon{ get; set; }

        public ICollection<ChefSocialMedia> ChefSocialMedias { get; set; }
    }
}
