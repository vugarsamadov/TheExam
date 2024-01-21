using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Models
{
    public class GenericPaginatedModel<T>
    {
        public GenericPaginatedModel(T data, int currentPage, int rowCount, int perPage, string baseUrl)
        {
            Data = data;
            CurrentPage = currentPage;
            RowCount = rowCount;
            PerPage = perPage;
            BaseUrl = baseUrl;
        }

        public T Data { get; set; }
        public int CurrentPage { get; set; }
        public int RowCount { get; set; }
        public int PerPage { get; set; }

        public string BaseUrl { get; set; }

        public int PageCount { get => (int)Math.Ceiling(RowCount * 1.0 / PerPage); }
        public bool HasNext { get => CurrentPage < PageCount; }
        public bool HasPrev { get => CurrentPage > 1; }
    }
}
