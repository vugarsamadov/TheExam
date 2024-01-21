using Exam.Business.Models;
using Exam.Business.Models.Chef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services.Abstract
{
    public interface IChefService
    {

        public Task<ChefVM> GetByIdAsync(int id);

        public Task CreateAsync(ChefCreateVM model);
        public Task UpdateAsync(int id, ChefUpdateVM model);

        public Task<IEnumerable<ChefVM>> GetTalantedChefs();

        public Task<GenericPaginatedModel<IEnumerable<ChefVM>>> GetPaginatedChefsAsync(int currentPage, int perPage, string baseUrl);

        public Task SoftDelete(int id);
        public Task RevokeSoftDelete(int id);

    }
}
