using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Infrastructure.Repositories.Abstract
{
    public interface IGenericRepository<T>
    {
        public void Update(T entity);

        public Task SaveChangesAsync();

        public Task CreateAsync(T entity);

        public Task<IEnumerable<T>> GetAllAsync();
        public Task<int> GetCountAsync();

        public Task<IEnumerable<T>> GetLastNAsync(int n);
    }
}
