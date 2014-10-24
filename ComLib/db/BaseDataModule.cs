using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class BaseDataModule
    {
        private long _TEM_COLUMN_COUNT = 0;
        public long TEM_COLUMN_COUNT
        {
            get
            {
                return _TEM_COLUMN_COUNT;
            }
            set
            {
                _TEM_COLUMN_COUNT = value;
            }
            
        }
        //	public int PageCount = 0;

        //public int getTEM_COLUMN_COUNT()
        //{
        //    return TEM_COLUMN_COUNT;
        //}


        //public void setTEM_COLUMN_COUNT(int tEM_COLUMN_COUNT)
        //{
        //    TEM_COLUMN_COUNT = tEM_COLUMN_COUNT;
        //}
    }
}
