using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib
{
    public class ComFn
    {
        #region other
        public static long getPageCount(long pageSize, long rowCount)
        {
            long pageCount = rowCount % pageSize == 0 ? ((rowCount - (rowCount % pageSize)) / pageSize) : ((rowCount - (rowCount % pageSize)) / pageSize) + 1;
            return pageCount;
        }
        #endregion
    }
}
