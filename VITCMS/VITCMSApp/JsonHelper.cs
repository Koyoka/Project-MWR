using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace VITCMSApp
{
    public static class JsonHelper
    {
        public static bool ConventJsonToValue<T>(JObject jo, string key, ref List<T> t)
        {
            JToken jt;
            if (!jo.TryGetValue(key, out jt))
            {
                return false;
            }
            else
            {
                if (jt.Type == JTokenType.Array)
                {
                    List<JToken> oo = jt.ToList();
                    foreach (JToken item in oo)
                    {
                        t.Add(item.Value<T>());
                    }
                }
            }
            return true;
        }

        public static bool ConventJsonToValue(JObject jo, string key, ref string t)
        {
            JToken jt;
            if (!jo.TryGetValue(key, out jt))
            {
                return false;
            }
            else
            {
                if (jt.Type == JTokenType.String)
                {
                    t = jt.Value<string>();
                }
                else if(jt.Type == JTokenType.Object)
                {
                    t = jt.ToString();
                }
            }
            return true;
        }

        public static bool ConventJsonToValue<T>(JObject jo, string key, ref T t)
        {
            JToken jt;
            if (!jo.TryGetValue(key, out jt))
            {
                return false;
            }
            else
            {
                if (jt.Type != JTokenType.Object)
                {
                    t = jt.Value<T>();
                }
              
            }
            return true;
        }

       
    }
}
