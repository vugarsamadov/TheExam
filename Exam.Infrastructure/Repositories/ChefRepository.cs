using Exam.Core.Entities;
using Exam.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Infrastructure.Repositories
{
    public class ChefRepository : GenericRepository<Chef>, IChefRepository
    {
        private ApplicationDbContext _dbContext { get; }

        public ChefRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Chef> GetByIdAsync(int id, bool tracking, params string[] includes)
        {
            var query = _dbContext.Set<Chef>().AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includes != null && includes.Length > 0)
                foreach (var includeItem in includes)
                    query = query.Include(includeItem);

            query = query.Include(c => c.ChefSocialMedias).ThenInclude(csm => csm.SocialMedia);

            var entity = await query.FirstOrDefaultAsync(c=>c.Id == id);

            return entity;
        }

        public async Task<IEnumerable<Chef>> GetPaginatedEntities(int? page, int? perpage, bool includeDeleted)
        {
            var query = _dbContext.Set<Chef>().AsQueryable();
            if (!includeDeleted)
                query = query.Where(c=>c.IsDeleted);

            if (page != null && perpage != null)
                query = query.Skip(((int)(page -1) * (int)(perpage))).Take((int)perpage);

            query = query.Include(c => c.ChefSocialMedias).ThenInclude(csm => csm.SocialMedia);

            var entities = await query.ToListAsync();

            return entities;
        }
    }
}
