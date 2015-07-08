using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using YAS.ComUtility.Common;
using System.Collections.Specialized;

namespace YAS.ComUtility.IM
{
    public class HXIMHelper
    {
       
        //org_name}/{app_name}/users/{owner_username}/contacts/users
        private string _serviceURL = "";//org_name
        private string _orgName = "";//企业Id
        private string _appName = "";//应用名称

        private string _clientId = "";
        private string _clientSecret = "";

        public HXIMHelper(string serviceURL,string orgName,string appName)
        {
            _serviceURL = serviceURL;
            _orgName = orgName;
            _appName = appName;
        }
        public HXIMHelper(string orgName, string appName,string clientId,string clientSecret)
        {
            _serviceURL = "a1.easemob.com";
            //_serviceURL = "www.baidu.com";
            _orgName = orgName;
            _appName = appName;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        #region common
        private string GetAppServiceHostURL()
        {
            return string.Format("https://{0}/{1}/{2}/", _serviceURL,_orgName,_appName);
        }
        private string GetTokenServiceUrl()
        {
            return GetAppServiceHostURL() + "token";
        }
        private string GetUserContactsServiceUrl(string userName)
        {
            return GetAppServiceHostURL() + string.Format("users/{0}/contacts/users",userName);
        }

        private string GetGroupDetailsServiceUrl(string groupId)
        {
            //{org_name}/{app_name}/chatgroups/{group_id}/users
            return GetAppServiceHostURL() + string.Format("chatgroups/{0}/users", groupId);
        }
        
        #endregion
      
        #region service api
        public bool GetAppToken(ref string errMsg)
        {
            
            string url = GetTokenServiceUrl();

            string requestBody = Newtonsoft.Json.JsonConvert.SerializeObject(new TokenRequestBody()
            {
                client_id = _clientId,
                client_secret = _clientSecret
            });
            string responseData = "";
            int statusCode = 0;
            if (!HttpHelper.DoPostJSONHttp(url, requestBody, ref responseData, ref statusCode, ref errMsg))
            {
                return false;
            }
            TokenResponseData obj =
                Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponseData>(responseData);
            return true;
            
            #region _del
            //string requestBody = " {“grant_type”: “client_credentials”,”client_id”: “{app的client_id}”,”client_secret”: “{app的client_secret}”}";
            //try
            //{

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "POST";
            //request.ContentType = "application/json";

            //Encoding encoding = Encoding.UTF8;
            //    using (Stream s = request.GetRequestStream())
            //    {
            //        byte[] postBytes = encoding.GetBytes(requestBody);
            //        s.Write(postBytes, 0, postBytes.Length);
            //        s.Close();
            //    }
            //    #region Send
               
            //    using (System.IO.StreamReader sr = new System.IO.StreamReader(request.GetResponse().GetResponseStream(), encoding))
            //    {
            //        responseData = sr.ReadToEnd();
            //        sr.Close();
            //    }
            //    #endregion

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    errMsg = ex.Message;
            //    return false;
            //}
            #endregion
        }
        public bool GetUserContacts(string userName, string token, ref List<string> friendUserIds, ref string errMsg)
        {
            try
            {
                string url = GetUserContactsServiceUrl(userName);
                NameValueCollection nv = new NameValueCollection();
                nv.Add("Authorization", "Bearer " + token);

                int statusCode = 0;
                string responseData = "";
                if (!HttpHelper.DoGetHttp(url, nv, ref responseData, ref statusCode, ref errMsg))
                {
                    return false;
                }

                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(responseData);
                Newtonsoft.Json.Linq.JArray jarray = jo["data"] as Newtonsoft.Json.Linq.JArray;
                friendUserIds = new List<string>();
                if (jarray != null)
                {
                    foreach (var item in jarray)
                    {
                        friendUserIds.Add(item.ToString());
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        public bool GetGroupDetails(string groupId,string token,
            ref List<string> owners ,
            ref List<string> members,
            ref string errMsg)
        {
            try
            {
                string url = GetGroupDetailsServiceUrl(groupId);
                NameValueCollection nv = new NameValueCollection();
                nv.Add("Authorization", "Bearer " + token);

                int statusCode = 0;
                string responseData = "";
                if (!HttpHelper.DoGetHttp(url, nv, ref responseData, ref statusCode, ref errMsg))
                {
                    return false;
                }

                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(responseData);
                Newtonsoft.Json.Linq.JArray jarray = jo["data"] as Newtonsoft.Json.Linq.JArray;
                owners = new List<string>();
                members = new List<string>();
                if (jarray != null)
                {
                    foreach (var item in jarray)
                    {
                        var o = item["owner"];
                        if (o != null)
                        {
                            owners.Add(o.ToString());
                        }
                        else {
                            members.Add(item["member"].ToString());
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        public bool GetAllGroupsInfo(string token, ref List<string> groups, ref string errMsg)
        {
            try
            {
                string url = "http://127.0.0.1/AngularJS/chatgroups.json";
                NameValueCollection nv = new NameValueCollection();
                nv.Add("Authorization", "Bearer " + token);

                int statusCode = 0;
                string responseData = "";
                if (!HttpHelper.DoGetHttp(url, nv, ref responseData, ref statusCode, ref errMsg))
                {
                    return false;
                }

                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(responseData);
                string jsonStr = jo["data"].ToString();
                List<HXGroupInfoData> aa =
                Newtonsoft.Json.JsonConvert.DeserializeObject<List<HXGroupInfoData>>(jsonStr);
               
                //groups = new List<string>();
                //if (jarray != null)
                //{
                //    foreach (var item in jarray)
                //    {
                //        groups.Add(item.ToString());
                //    }
                //}
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        public bool GetGroupsByUser(string userName, string token, ref List<HXGroupInfoData> groups, ref string errMsg)
        {
            // /{org_name}/{app_name}/users/{username}/joined_chatgroups
            try
            {
                string url = "http://127.0.0.1/AngularJS/joined_chatgroups.json";
                NameValueCollection nv = new NameValueCollection();
                nv.Add("Authorization", "Bearer " + token);

                int statusCode = 0;
                string responseData = "";
                if (!HttpHelper.DoGetHttp(url, nv, ref responseData, ref statusCode, ref errMsg))
                {
                    return false;
                }

                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(responseData);
                string jsonStr = jo["data"].ToString();
                groups =
                Newtonsoft.Json.JsonConvert.DeserializeObject<List<HXGroupInfoData>>(jsonStr);

                if (groups == null)
                    groups = new List<HXGroupInfoData>();

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        #endregion
        #region common data

        #region token
        private class TokenRequestBody
        {
            public string grant_type { get { return "client_credentials"; } }
            public string client_id { get; set; }
            public string client_secret { get; set; }
        }
        private class TokenResponseData
        {
            public string access_token { get; set; }
            public string expires_in { get; set; }
            public string application { get; set; }
        }
//////        //{"access_token":"YWMt2lGc2BtSEeWbazGNlz5gogAAAU9gbY7H-robEI3HU0CThU-iDu6SHmwGeUY",
//////        //"expires_in":5184000,
//////        //"application":"5900e970-1b4a-11e5-a115-8d2733461c90"}
////////YWMt2lGc2BtSEeWbazGNlz5gogAAAU9gbY7H-robEI3HU0CThU-iDu6SHmwGeUY     
////////5900e970-1b4a-11e5-a115-8d2733461c90

        //{"access_token":"YWMtMaxS0htaEeWMuV9qSXPpcgAAAU9gnatR1scIxj7FXk4esB9hc622CbiLSiA","expires_in":5184000,"application":"5900e970-1b4a-11e5-a115-8d2733461c90"}
        #endregion

        #region user contacts
        /*
         {
  "action" : "get",
  "uri" : "http://a1.easemob.com/elevendemo/elevendemoapp/users/u1/contacts/users",
  "entities" : [ ],
  "data" : [ "u2" ],
  "timestamp" : 1435251854683,
  "duration" : 5
         */


        #endregion
         public class HXGroupInfoData
        {
            public string GROUPID { get; set; }
            public string GROUPNAME { get; set; }
            public string owner { get; set; }
            public int affiliations { get; set; }
        }
        #region GroupDetails - user
        /*
         {
  "action" : "get",
  "uri" : "http://a1.easemob.com/elevendemo/elevendemoapp/chatgroups/75932856479646128/users",
  "entities" : [ ],
  "data" : [ {
    "member" : "u2"
  }, {
    "member" : "u3"
  }, {
    "owner" : "u1"
  } ],
  "timestamp" : 1435253631442,
  "duration" : 2
}
         */

        #endregion

        #endregion
    }
}
