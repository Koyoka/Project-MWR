using System;
using System.Collections.Generic;
using System.Text;
using ComLib;



namespace DBUpdate.WinAppBase
{
    public class WinAppFn
    {
        public static string GetAppFolder()
        {
            string path = ComFn.GetAppExePath();
            if (path.ToUpper().EndsWith(@"\BIN\DEBUG\"))
            {
                return path.Substring(0, path.Length - 11) + @"\";
            }
            else if (path.ToUpper().EndsWith(@"\BIN\RELEASE\"))
            {
                return path.Substring(0, path.Length - 13) + @"\";
            }
            else if (path.ToUpper().EndsWith(@"\BIN\"))
            {
                return path.Substring(0, path.Length - 5) + @"\";
            }
            else
            {
                return path;
            }
        }

        public static string GetSettingFolder()
        {
            return GetAppFolder() + @"Setting" + @"\";
        }

        public static string GetImageFolder()
        {
            return GetAppFolder() + @"Setting\Images" + @"\";
        }

        public static bool GetAppBaseResourceText(string name, ref string text, ref string errMsg)
        {
            try
            {
                using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Profitek.Qooway.WinBase.WinAppBase.Resource.Text." + name))
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                    {
                        text = sr.ReadToEnd();
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

        public static bool GetAppBaseReourceImage(string name, ref System.Drawing.Image image, ref string errMsg)
        {
            
            try
            {

                using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                {
                    image = new System.Drawing.Bitmap(stream);
                }

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        public static System.Drawing.Image GetAppBaseReourceImageSafe(string name)
        {
            try
            {

                using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Profitek.Qooway.WinBase.WinAppBase.Resource.Image." + name))
                {
                    return new System.Drawing.Bitmap(stream);
                }
            }
            catch 
            {
                return new System.Drawing.Bitmap(10,10);
            }
        }
    }
}
