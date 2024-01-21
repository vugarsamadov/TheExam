using Exam.Business.Models.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services.Abstract
{
    public interface ISocialMediaService
    {
        public Task<IEnumerable<SocialMediaVM>> GetAllAsync();
    }
}
