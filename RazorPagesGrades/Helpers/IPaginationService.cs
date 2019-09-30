using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesGrades.Helpers
{
    interface IPaginationService<T>
    {
        IEnumerable<T> GetPaginatedResult(int currentPage, int pageSize = 10);
        int GetCount();
    }
}
