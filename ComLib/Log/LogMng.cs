using System;
using System.IO;

namespace ComLib.Log
{
	public class LogMng
	{
        public static TextLog _log = null;

        public static bool InitLog(string logFileFolder, string logFileName, ref string errMsg)
        {
			try
			{
                lock (typeof(LogMng))
                {
                    _log = new TextLog(logFileFolder, logFileName);
                }

				return true;
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				return false;
			}
		}

		public static TextLog GetLog()
		{
            return _log;
		}

	}
}
