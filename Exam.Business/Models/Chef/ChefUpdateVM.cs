using Exam.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Models.Chef
{
    public class ChefUpdateVM
    {
        public string ChefName { get; set; }
        public string ChefBio { get; set; }

        public IFormFile? ProfileImage { get; set; }
    }
}
