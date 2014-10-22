using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class BaseDataModule
    {
        public int TEM_COLUMN_COUNT = 0;
        //	public int PageCount = 0;

        public int getTEM_COLUMN_COUNT()
        {
            return TEM_COLUMN_COUNT;
        }


        public void setTEM_COLUMN_COUNT(int tEM_COLUMN_COUNT)
        {
            TEM_COLUMN_COUNT = tEM_COLUMN_COUNT;
        }
    }
}
