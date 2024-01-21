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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _dbContext { get; }
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public Task<int> GetCountAsync()
        {
            return _dbContext.Set<T>().CountAsync();
        }

        public async Task<IEnumerable<T>> GetLastNAsync(int n)
        {
            return await _dbContext.Set<T>().OrderByDescending(c => c.CreatedAt).Take(n).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
