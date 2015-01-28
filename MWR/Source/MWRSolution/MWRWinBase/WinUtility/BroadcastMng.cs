using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRKJ.MWR.WinBase.WinUtility
{
    public class BroadcastMng
    {
        public class BroadcastMessage
        {
            public int Message = 0;
            public object Data = new object();
        }

        Dictionary<string, OnBroadcastListen> _listens = new Dictionary<string,OnBroadcastListen>();
        public delegate void OnBroadcastListen(BroadcastMessage msg);
        
        public void Listen(string name, OnBroadcastListen l)
        {
            //cc += new OnBroadcastListen(BroadcastMng_cc);
            if (!_listens.ContainsKey(name))
            {
                _listens.Add(name, l);
            }
            else {
                _listens[name] += l;
            }
           
        }

        public void Send(string name, BroadcastMessage v)
        {
            if (!_listens.ContainsKey(name))
            {
                return;
            }
            OnBroadcastListen defineL;
            if (_listens.TryGetValue(name, out defineL))
            {
                defineL(v);
            }
        }

        private static BroadcastMng _broadcastMng = null;
        public static BroadcastMng GetInstance()
        {
            if (_broadcastMng == null)
            {
                _broadcastMng = new BroadcastMng();
            }
            return _broadcastMng;
        }
       
    }
}
