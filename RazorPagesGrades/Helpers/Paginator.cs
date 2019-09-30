using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesGrades.Helpers
{
    public class Paginator<T> : IPaginationService<T>
    {
        // https://www.mikesdotnetting.com/article/328/simple-paging-in-asp-net-core-razor-pages

        //List<T> _allrows;

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetPaginatedResult(int currentPage, int pageSize = 10)
        {
            throw new NotImplementedException();
        }
    }
}
