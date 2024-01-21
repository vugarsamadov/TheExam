using Exam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Infrastructure.Repositories.Abstract
{
    public interface IChefRepository : IGenericRepository<Chef>
    {
        public Task<Chef> GetByIdAsync(int id, bool tracking,params string[] includes);

        public Task<IEnumerable<Chef>> GetPaginatedEntities(int? page, int? perpage, bool includeDeleted);
    }
}
