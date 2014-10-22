using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib
{
    public class ComFn
    {
        public static int getPageCount(int pageSize, int rowCount)
        {
            int pageCount = rowCount % pageSize == 0 ? ((rowCount - (rowCount % pageSize)) / pageSize) : ((rowCount - (rowCount % pageSize)) / pageSize) + 1;
            return pageCount;
        }
    }
}
