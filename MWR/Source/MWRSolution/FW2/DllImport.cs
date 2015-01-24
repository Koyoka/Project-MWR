using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace FW2
{
    public class DllImport
    {
        public class ISSec
        {
            [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            public static extern string ISEncrypt(string text, string key);

            [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            public static extern string ISDecrypt(string text, string key);

            [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            public static extern int ISCheckLicenseNumber(string info, string LicenseNumber, int CheckNumOfLicense);

            [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            public static extern string ISDBPassword();
            [DllImport("ISSec.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            public static extern int ISCheckAdminPassword(string password);
            public static bool ValidateISSec()
            {
                string text = @"xURkAiTjSM}\`\hhMN]HKc}{GMtrhjDisfbSA@o[zHP";
                string result = ISDecrypt(text, "2688 Shell Road");

                if (result == "InfoSpec Systems Inc.")
                    return true;

                return false;
            }

            public static string OneWayEncrypt(string text)
            {
                byte[] data = Encoding.Unicode.GetBytes(text);
                byte[] result = ComputeHash(data);
                string final = Convert.ToBase64String(result);
                return final;
            }

            public static byte[] ComputeHash(byte[] data)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                return md5.ComputeHash(data);
            }
            public static string EncryptPassword(string password)
            {
                return EncryptPassword(password, "AZBYCXDWEQ");
            }

            public static string EncryptPassword(string password, string key)
            {
                string text = "";
                char lrc = GetLRC(key + password);
                int c;
                password += "                                     ";
                for (int i = 0; i < key.Length; i++)
                {
                    c = password[i] ^ key[i] ^ lrc;
                    text += c.ToString("X02");
                }
                text += ((int)lrc).ToString("X02");
                return text;
            }

            public static string DecryptPassword(string text)
            {
                return DecryptPassword(text, "AZBYCXDWEQ");
            }

            public static string DecryptPassword(string text, string key)
            {
                if (text.Length == 0) return "";

                char lrc = (char)Convert.ToInt16(text.Substring(text.Length - 2, 2), 16);
                char c;

                string password = "";
                int max = key.Length;

                for (int i = 0; i < max; i++)
                {
                    c = (char)Convert.ToInt16(text.Substring(i * 2, 2), 16);
                    c ^= lrc;
                    c ^= key[i];
                    password += c;
                }
                return password.Trim();
            }

            private static char GetLRC(string text)
            {
                char c = (char)0;
                for (int i = 0; i < text.Length; i++)
                {
                    c ^= text[i];
                }
                return c;
            }
        }
    }
}
