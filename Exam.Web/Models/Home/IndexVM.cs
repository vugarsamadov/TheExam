using Exam.Business.Models.Chef;

namespace Exam.Web.Models.Home
{
    public class IndexVM
    {
        public IEnumerable<ChefVM> TalantedChefs { get; set; }
    }
}
