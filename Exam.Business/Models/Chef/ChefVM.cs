using Exam.Business.Models.SocialMedia;
using Exam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Models.Chef
{
    public class ChefVM
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string ChefName { get; set; }
        public string ChefBio { get; set; }
        public string ProfileImageUrl { get; set; }
        public IEnumerable<SocialMediaVM> ChefSocialMedias { get; set; }
    }
}
