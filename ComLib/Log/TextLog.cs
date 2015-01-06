using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ComLib.Log
{
	public class TextLog
	{
        private string _fileFolder = "";
        public string _fileName = "";

        public TextLog(string fileFolder, string fileName)
		{
            _fileFolder = fileFolder;
            _fileName = fileName;

            if (!System.IO.Directory.Exists(fileFolder))
            {
                System.IO.Directory.CreateDirectory(fileFolder);
            }

            //Write(DateTime.Now.ToString("yyyyMMddHHmmss") + ";INF;Log Test--------------------------------");
        }

        private Dictionary<int, int> _errorList = new Dictionary<int, int>();
        public void PrintError(string className, string fnName, Exception ex)
        {
            lock (this)
            {
                if (_errorList.Count > 50000)
                {
                    _errorList.Clear();
                }

                int curError = className.GetHashCode() + fnName.GetHashCode() + ex.Message.GetHashCode();
                if (_errorList.ContainsKey(curError))
                {
                    return;
                }
                else
                {
                    _errorList.Add(curError, 0);
                }
            }

            try
            {
                StringBuilder s = new StringBuilder();
                s.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
                s.Append(";");
                s.Append("ERR");
                s.Append(";");
                s.Append(className + "." + fnName);
                s.Append(";");
                s.Append(ex.Message);

                System.Exception subEx = ex.InnerException;
                int subExLevel = 0;
                while (subEx != null)
                {
                    s.Append("(InnerException:" + subEx.Message + ")");
                    subEx = subEx.InnerException;
                    subExLevel++;

                    if (subExLevel > 200)
                    {
                        break;
                    }
                }

                s.AppendLine(ex.StackTrace);

                Write(s.ToString());
            }
            catch
            {
                //nothing
            }
        }

        public void PrintInfo(string className, string fnName, string msg)
        {
            try
            {
                StringBuilder s = new StringBuilder();
                s.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
                s.Append(";");
                s.Append("INF");
                s.Append(";");
                s.Append(className + "." + fnName);
                s.Append(";");
                s.Append(msg);

                Write(s.ToString());
            }
            catch
            {
                //nothing
            }
        }

        private Dictionary<int, int> _warningList = new Dictionary<int, int>();
        public void PrintWarning(string className, string fnName, string msg)
        {
            lock (this)
            {
                if (_warningList.Count > 50000)
                {
                    _warningList.Clear();
                }

                //int curWarning = className.GetHashCode() + fnName.GetHashCode() + msg.GetHashCode();
                //if (_warningList.ContainsKey(curWarning))
                //{
                //    return;
                //}
                //else
                //{
                //    _warningList.Add(curWarning, 0);
                //}
            }

            try
            {
                StringBuilder s = new StringBuilder();
                s.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
                s.Append(";");
                s.Append("WAN");
                s.Append(";");
                s.Append(className + "." + fnName);
                s.Append(";");
                s.Append(msg);

                Write(s.ToString());
            }
            catch
            {
                //nothing
            }
        }

        private void Write(string msg)
        {
            lock (this)
            {
                string path = ComFn.GetSafeDirectory(_fileFolder) + _fileName + DateTime.Now.ToString("yyyyMMdd") + ".syslog";

                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(msg);
                }
            }
        }
	}
}
