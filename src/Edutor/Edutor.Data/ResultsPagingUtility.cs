using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data
{
    public static class ResultsPagingUtility
    {
        private const string ValueLessThanOneErrorMessage = "Value may not be less than 1.";
        private const string ValueLessThanZeroErrorMessage = "Value may not be less than 0.";

        public static int CalculatePageSize(int requestdeVal, int maxVal)
        {
            if (requestdeVal < 1)
                throw new ArgumentOutOfRangeException("requestedVal", requestdeVal, ValueLessThanOneErrorMessage);

            if (maxVal < 1)
                throw new ArgumentOutOfRangeException("maxVal", maxVal, ValueLessThanOneErrorMessage);

            return Math.Min(requestdeVal, maxVal);
        }

        public static int CalculateStartIndex(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(Edutor.Common.Constants.CommonParameterNames.PageNumber, pageNumber, ValueLessThanOneErrorMessage);
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(Edutor.Common.Constants.CommonParameterNames.PageSize, pageSize, ValueLessThanOneErrorMessage);
            var startIndex = (pageNumber - 1) * pageSize;
            return startIndex;
        }

        public static int CalculatePageCount(int totalItemCount, int pageSize)
        {
            if (totalItemCount < 0)
                throw new ArgumentOutOfRangeException("totalItemCount", totalItemCount, ValueLessThanZeroErrorMessage);
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(Edutor.Common.Constants.CommonParameterNames.PageSize, pageSize, ValueLessThanOneErrorMessage);

            var totalPageCount = (totalItemCount + pageSize - 1) / pageSize;
            return totalPageCount;
        }
    }
}
