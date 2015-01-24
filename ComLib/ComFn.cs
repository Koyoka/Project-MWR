using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

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

        #region IO

        public static string GetSafeDirectory(string directory)
        {
            directory = directory.Trim();

            if (!directory.EndsWith("\\"))
            {
                return directory + "\\";
            }
            else
            {
                return directory;
            }
        }

        public static bool CreateDirectory(string filePath, ref string errMsg)
        {
            try
            {
                string directory = System.IO.Path.GetDirectoryName(filePath);
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        #endregion

        #region App Info
        public static string GetAppExePath()
        {
            try
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                if (!path.EndsWith("\\"))
                {
                    path = path + "\\";
                }

                return path;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region DataBase

        public static string EncryptDBPassword(string key,string text)
        {
            //加密方法 "pROFITEKdbpASSWORD"
            return FW2.DllImport.ISSec.ISEncrypt(text, key);
        }

        public static string DecryptDBPassword(string key,string text)
        {
            //解密方法"pROFITEKdbpASSWORD"
            return FW2.DllImport.ISSec.ISDecrypt(text, key);
        }

        #endregion

        #region XML

        public static string SafeGetXmlNodeInnerText(System.Xml.XmlDocument doc, string path)
        {
            try
            {
                return doc.SelectSingleNode(path).InnerText.Trim();
            }
            catch
            {
                return "";
            }
        }
        public static string SafeGetXmlNodeInnerText(System.Xml.XmlNode node, string path)
        {
            try
            {
                return node.SelectSingleNode(path).InnerText.Trim();
            }
            catch
            {
                return "";
            }
        }

        public static string GetSafeXml(string xml)
        {
            xml = xml.Replace("&", "&amp;");
            xml = xml.Replace("<", "&lt;");
            xml = xml.Replace(">", "&gt;");

            return xml;
        }

        #endregion

        #region Encrypt & Decrypt
        public static string CalculateRFC2104HMAC(string secret, string mk)
        { 
            return CalculateRFC2104HMAC(secret, mk,Encoding.UTF8);
        }
        public static string CalculateRFC2104HMAC(string secret, string mk, Encoding encoder)
        {
            using (HMACSHA1 hmacsha1 = new HMACSHA1())
            {
                //hmacsha1.Key = Encoding.ASCII.GetBytes(secret);
                //byte[] dataBuffer = Encoding.ASCII.GetBytes(mk);

                hmacsha1.Key = encoder.GetBytes(secret);
                byte[] dataBuffer = encoder.GetBytes(mk);
                byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
                return Convert.ToBase64String(hashBytes);
            }
            //using (System.Security.Cryptography.HMACSHA1 hmac =
            //    new System.Security.Cryptography.HMACSHA1(Encoding.ASCII.GetBytes(secret))
            //    )
            //{
            //    return Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(mk)));
            //}
            //return "";
        }

        public static string EncryptStringBy64(string s)
        {
            byte[] bits = UTF8Encoding.Default.GetBytes(s);
            return Convert.ToBase64String(bits);
        }
        public static string DecryptStringBy64(string s)
        {
            byte[] bits = Convert.FromBase64String(s);
            return UTF8Encoding.Default.GetString(bits);
        }

        #endregion

        #region C# Data Convert
       

        public static int StringToInt(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                return 0;
            }
        }
        public static bool StringToIntUnSafe(string s, ref int v)
        {
            try
            {
                v = System.Convert.ToInt32(s);
                return true;
            }
            catch
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public static float StringToFloat(string s)
        {
            try
            {
                return float.Parse(s);
            }
            catch
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                return 0;
            }
        }
        public static bool StringToFloatUnSafe(string s,ref float v)
        {
            try
            {
                v = float.Parse(s);
                return true;
            }
            catch
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public static decimal StringToDecimal(string s)
        {
            try
            {
                return decimal.Parse(s);
            }
            catch
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                return 0;
            }
        }
        public static bool StringToDecimalUnSafe(string s, ref decimal v)
        {
            try
            {
                v = decimal.Parse(s);
                return true;
            }
            catch
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public static double StringToDouble(string s)
        {
            try
            {
                return double.Parse(s);
            }
            catch
            {
                return 0;
            }
        }

        public static string ObjectToString(object s)
        {
            if (s == null)
            {
                return "";
            }
            else
            {
                return s.ToString();
            }
        }
        public static int ObjectToInt(object s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ObjectToDecimal(object s)
        {
            try
            {
                return Convert.ToDecimal(s);
            }
            catch
            {
                return 0;
            }
        }
        public static bool ObjectToBool(object s)
        {
            try
            {
                return Convert.ToBoolean(s);
            }
            catch
            {
                return false;
            }
        }

        public static bool ImageToByte(System.Drawing.Image img, ref byte[] byteDatas, ref string errMsg)
        {
            try
            {
                if (img == null)
                {
                    byteDatas = new byte[0];
                    return true;
                }

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Flush();
                    byteDatas = ms.GetBuffer();
                    ms.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        public static bool ByteToImage(byte[] byteDatas, ref System.Drawing.Image img, ref string errMsg)
        {
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteDatas))
                {
                    using (System.Drawing.Image tmpImg = System.Drawing.Bitmap.FromStream(ms))
                    {
                        img = new System.Drawing.Bitmap(tmpImg);
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

        public static DateTime DateTimeToDate(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
        }

        public static string DateTimeToString(DateTime dt, string format)
        {
            try
            {
                if (dt == DateTime.MinValue)
                {
                    return "";
                }

                return dt.ToString(format);
            }
            catch
            {
                return "";
            }
        }

        public static object[] IntArrayToObjectArray(int[] list)
        {
            object[] c = new object[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                c[i] = list[i];
            }

            return c;
        }

        public static bool StringToDateTimeUnSafe(string s, string format, ref DateTime v)
        {
            try
            {
                IFormatProvider fp = new System.Globalization.CultureInfo("en-gb", true);
                v = DateTime.ParseExact(s, format, fp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime StringToDateTime(string s, string format)
        {
            DateTime v = DateTime.MinValue;
            if (!StringToDateTimeUnSafe(s, format, ref v))
            {
                return DateTime.MinValue;
            }
            else
            {
                return v;
            }
        }
        #endregion

        #region DB Data Convert
        public static string GetDBFieldString(object v)
        {
            if (v == DBNull.Value)
            {
                return "";
            }

            if (v == null)
            {
                return "";
            }

            //return System.Convert.ToString(v).TrimEnd();
            return System.Convert.ToString(v);
        }

        public static double GetDBFieldDouble(object v)
        {
            if (v == DBNull.Value)
            {
                return 0;
            }

            if (v == null)
            {
                return 0;
            }

            return System.Convert.ToDouble(v);
        }

        public static int GetDBFieldInt(object v)
        {
            if (v == DBNull.Value)
            {
                return 0;
            }

            if (v == null)
            {
                return 0;
            }

            return System.Convert.ToInt32(v);
        }

        public static decimal GetDBFieldDecimal(object v)
        {
            if (v == DBNull.Value)
            {
                return 0;
            }

            if (v == null)
            {
                return 0;
            }

            return System.Convert.ToDecimal(v);
        }

        public static DateTime GetDBFieldDateTime(object v)
        {
            if (v == DBNull.Value)
            {
                return DateTime.MinValue;
            }

            if (v == null)
            {
                return DateTime.MinValue;
            }

            ////this code for rs bug.
            ////need delete in the future.
            //if (System.Convert.ToDateTime(v).CompareTo(new DateTime(1901, 1, 1)) < 0)
            //{
            //    return DateTime.MinValue;
            //}

            return System.Convert.ToDateTime(v);
        }

        public static byte[] GetDBFieldBinary(object v)
        {
            if (v == DBNull.Value)
            {
                return null;
            }

            if (v == null)
            {
                return null;
            }

            return (byte[])v;
        }

        public static bool GetDBFieldBool(object v)
        {
            if (v == DBNull.Value)
            {
                return false;
            }

            if (v == null)
            {
                return false;
            }

            return Convert.ToBoolean(v);
        }

        //public static string AddBetweenDateTimeForReport(string field, DateTime value1, DateTime value2)
        //{
        //    value1 = new DateTime(value1.Year, value1.Month, value1.Day, 0, 0, 0);
        //    value2 = new DateTime(value2.Year, value2.Month, value2.Day, 23, 59, 59);
        //    return field + " BETWEEN " + "CONVERT(datetime,'" + ComFn.DateTimeToString(value1, "yyyy-MM-dd HH:mm:ss") + "',120)" + " AND " + "CONVERT(datetime,'" + ComFn.DateTimeToString(value2, "yyyy-MM-dd HH:mm:ss") + "',120)";
        //}

        //public static string AddFromOrToDateTimeForReport(string fieldFrom, string fieldTo, DateTime value1, DateTime value2)
        //{
        //    value1 = new DateTime(value1.Year, value1.Month, value1.Day, 0, 0, 0);
        //    value2 = new DateTime(value2.Year, value2.Month, value2.Day, 23, 59, 59);
        //    return fieldTo + " >= " + "CONVERT(datetime,'" + ComFn.DateTimeToString(value1, "yyyy-MM-dd HH:mm:ss") + "',120)" + " AND " + fieldFrom + "<= CONVERT(datetime,'" + ComFn.DateTimeToString(value2, "yyyy-MM-dd HH:mm:ss") + "',120)";
        //}

        #endregion

        #region String Help
        public static string GetMaskNumString(int n, string TxnNumMask)
        {
            string defineNextNum = "";
            string prefix = TxnNumMask.Replace("#", "");
            string num = TxnNumMask.TrimStart(prefix.ToCharArray());
            int len = num.Length;
            int nextIdLen = n.ToString().Length;
            if (nextIdLen > len)
            {
                return null;
            }
            defineNextNum = prefix + defineNextNum.PadLeft(len - nextIdLen, '0') + n;
            return defineNextNum;
        }

        public static string SafeString(string s)
        {
            if (s == null)
            {
                return "";
            }
            else
            {
                return s;
            }
        }

        public static string EmptyToString(string s, string outString)
        {
            return string.IsNullOrEmpty(s.Trim()) ? outString : s;
        }

        public static string AppendEnd(string s, int len, char appendChar)
        {
            int less = len - s.Length;
            if (less <= 0)
            {
                return s;
            }

            return s + new string(appendChar, less);
        }

        public static string AppendBegin(string s, int len, char appendChar)
        {
            int less = len - s.Length;
            if (less <= 0)
            {
                return s;
            }

            return new string(appendChar, less) + s;
        }

        public static string GetBeforeText(string s, string key)
        {
            int pos = s.IndexOf(key);

            if (pos < 0)
            {
                return "";
            }

            return s.Substring(0, pos);
        }

        public static string GetAfterText(string s, string key)
        {
            int pos = s.IndexOf(key);

            if (pos < 0)
            {
                return "";
            }

            return s.Substring(pos + 1);
        }

        public static string GetMidText(string s, string key)
        {
            return GetMidText(s, "#" + key + "B#", "#" + key + "E#");
        }
        public static string GetMidText(string s, string beginKey, string endKey)
        {
            int pos1 = s.IndexOf(beginKey);
            if (pos1 < 0)
            {
                return null;
            }
            pos1 = pos1 + beginKey.Length;
            //abc=ddx
            //0123456
            int pos2 = s.IndexOf(endKey, pos1);
            if (pos2 < 0)
            {
                return null;
            }

            return s.Substring(pos1, pos2 - pos1);
        }

        public static void SetMidText(ref string s, string key, string value)
        {
            SetMidText(ref s, "#" + key + "B#", "#" + key + "E#", value);
        }
        public static void SetMidText(ref string s, string beginKey, string endKey, string value)
        {
            int pos1 = s.IndexOf(beginKey);
            if (pos1 < 0)
            {
                s = s + beginKey + value + endKey;
                return;
            }
            pos1 = pos1 + beginKey.Length;
            //abc=ddx
            //0123456
            int pos2 = s.IndexOf(endKey, pos1);
            if (pos2 < 0)
            {
                s = beginKey + value + endKey + s;
                return;
            }

            //2323BEGIN***END232
            //012345678901234567
            s = s.Substring(0, pos1 - beginKey.Length) + beginKey + value + endKey + s.Substring(pos2 + endKey.Length);
        }

        public static void ClearMidText(ref string s, string key)
        {
            ClearMidText(ref s, "#" + key + "B#", "#" + key + "E#");
        }
        public static void ClearMidText(ref string s, string beginKey, string endKey)
        {
            int pos1 = s.IndexOf(beginKey);
            if (pos1 < 0)
            {
                return;
            }
            pos1 = pos1 + beginKey.Length;
            //abc=ddx
            //0123456
            int pos2 = s.IndexOf(endKey, pos1);
            if (pos2 < 0)
            {
                return;
            }

            //2323BEGIN***END232
            //012345678901234567
            s = s.Substring(0, pos1 - beginKey.Length) + s.Substring(pos2 + endKey.Length);
        }

        public static string SafeSubstring(string text, int length)
        {
            if (text.Length > length)
            {
                text = text.Substring(0, length);
            }

            return text;
        }

        public static string SafeFormatString(string s, params object[] args)
        {
            try
            {
                return string.Format(s, args);
            }
            catch
            {
                return s;
            }
        }

        public static string JoinIntArray(int[] list, string separator)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Length; i++)
            {
                sb.Append(list[i].ToString());
                if (i < list.Length - 1)
                {
                    sb.Append(separator);
                }
            }

            return sb.ToString();
        }

        public static int[] ArrayStringToIntArray(string s, char separator)
        {
            string[] strList = s.Trim().Split(new char[] { separator });

            int[] intList = new int[strList.Length];
            for (int i = 0; i < strList.Length; i++)
            {
                intList[i] = ComFn.StringToInt(strList[i].Trim());
            }

            return intList;
        }

        public static bool[] ArrayStringToBoolArray(string s, char separator)
        {
            string[] strList = s.Trim().Split(new char[] { separator });

            bool[] blnList = new bool[strList.Length];
            for (int i = 0; i < strList.Length; i++)
            {
                blnList[i] = (strList[i].Trim() == "1");
            }

            return blnList;
        }

        public static string JoinStringArray(string[] orgList, string separator, bool ignoreEmpty)
        {
            List<string> newList = new List<string>();

            for (int i = 0; i < orgList.Length; i++)
            {
                if (ignoreEmpty && orgList[i] == "")
                {
                    continue;
                }

                newList.Add(orgList[i]);
            }

            if (newList.Count > 0)
            {
                return string.Join(separator, newList.ToArray());
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region Dll Import

        //private class ISSec
        //{
        //    [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        //    public static extern string ISEncrypt(string text, string key);

        //    [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        //    public static extern string ISDecrypt(string text, string key);

        //    [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int ISCheckLicenseNumber(string info, string LicenseNumber, int CheckNumOfLicense);

        //    [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        //    public static extern string ISDBPassword();
        //    [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int ISCheckAdminPassword(string password);
        //    public static bool ValidateISSec()
        //    {
        //        string text = @"xURkAiTjSM}\`\hhMN]HKc}{GMtrhjDisfbSA@o[zHP";
        //        string result = ISDecrypt(text, "2688 Shell Road");

        //        if (result == "InfoSpec Systems Inc.")
        //            return true;

        //        return false;
        //    }

        //    public static string OneWayEncrypt(string text)
        //    {
        //        byte[] data = Encoding.Unicode.GetBytes(text);
        //        byte[] result = ComputeHash(data);
        //        string final = Convert.ToBase64String(result);
        //        return final;
        //    }

        //    public static byte[] ComputeHash(byte[] data)
        //    {
        //        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //        return md5.ComputeHash(data);
        //    }
        //    public static string EncryptPassword(string password)
        //    {
        //        return EncryptPassword(password, "AZBYCXDWEQ");
        //    }

        //    public static string EncryptPassword(string password, string key)
        //    {
        //        string text = "";
        //        char lrc = GetLRC(key + password);
        //        int c;
        //        password += "                                     ";
        //        for (int i = 0; i < key.Length; i++)
        //        {
        //            c = password[i] ^ key[i] ^ lrc;
        //            text += c.ToString("X02");
        //        }
        //        text += ((int)lrc).ToString("X02");
        //        return text;
        //    }

        //    public static string DecryptPassword(string text)
        //    {
        //        return DecryptPassword(text, "AZBYCXDWEQ");
        //    }

        //    public static string DecryptPassword(string text, string key)
        //    {
        //        if (text.Length == 0) return "";

        //        char lrc = (char)Convert.ToInt16(text.Substring(text.Length - 2, 2), 16);
        //        char c;

        //        string password = "";
        //        int max = key.Length;

        //        for (int i = 0; i < max; i++)
        //        {
        //            c = (char)Convert.ToInt16(text.Substring(i * 2, 2), 16);
        //            c ^= lrc;
        //            c ^= key[i];
        //            password += c;
        //        }
        //        return password.Trim();
        //    }

        //    private static char GetLRC(string text)
        //    {
        //        char c = (char)0;
        //        for (int i = 0; i < text.Length; i++)
        //        {
        //            c ^= text[i];
        //        }
        //        return c;
        //    }
        //}

        #endregion
    }
}
