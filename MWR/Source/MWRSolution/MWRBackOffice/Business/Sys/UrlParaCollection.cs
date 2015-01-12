using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class UrlParaCollection
    {
        private List<UrlParaData> _list = new List<UrlParaData>();

        public void Add(string name, string value)
        {
            _list.Add(new UrlParaData(name, value));
        }

        public void Add(UrlParaData data)
        {
            _list.Add(data);
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < _list.Count; i++)
            {
                sb.Append(_list[i].Name + "=" + HttpUtility.UrlEncode(_list[i].Value));
                if (i < _list.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }
    }
}