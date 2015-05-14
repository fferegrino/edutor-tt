using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data
{
    public class QueryResult<T>
    {
        public int PageSize { get; private set; }
        public int TotalItemCount { get; private set; }
        public IEnumerable<T> QueriedItems { get; private set; }

        public QueryResult(IEnumerable<T> queriedItems, int totalItemCount, int pageSize)
        {
            PageSize = pageSize;
            TotalItemCount = totalItemCount;
            QueriedItems = queriedItems ?? new List<T>();
        }

        public int TotalPageCount { get { return ResultsPagingUtility.CalculatePageCount(TotalItemCount, PageSize); } }

    }
}
