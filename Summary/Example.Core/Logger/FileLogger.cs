using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Example.Logging
{
    public class FileLogger : ILogger
    {
        public static string LogPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "");
            }
        }

        public void Debug(string message)
        {
            WriteLog(string.Format("Level:Debug Custom message :{0}", message));
        }

        public void Trace(string message)
        {
            WriteLog(string.Format("Level:Trace Custom message :{0}", message));
        }

        public void Info(string message)
        {
            WriteLog(string.Format("Level:Info Custom message :{0}", message));
        }

        public void Warn(string message)
        {
            WriteLog(string.Format("Level:Warn Custom message :{0}", message));
        }

        public void Error(string message)
        {
            WriteLog(string.Format("Level:Error Custom message :{0}", message));
        }

        public void Error(string message, Exception e)
        {
            WriteLog(string.Format("Level:Error Ex Msg :{0}, Custom message :{1}", e.Message, message));
        }

        public void Error(Exception e)
        {
            WriteLog(string.Format("Level:Error Ex Msg :{0}", e.Message));
        }

        public void Fatal(string message, Exception e)
        {
            WriteLog(string.Format("Level:Fatal Ex Msg :{0}, Custom message :{1}", e.Message, message));
        }

        public void Fatal(Exception e)
        {
            WriteLog(string.Format("Level:Fatal Ex Msg :{0}", e.Message));
        }

        private static void WriteLog(string message)
        {
            var path = LogPath + string.Format(@"\Logs\{0}\", DateTime.Now.ToString("yyyy年MM月dd日"));

            var fileName = string.Format("{0}.txt", DateTime.Now.ToString("HH时mm分ss秒"));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            using (FileStream fs = new FileStream(path + fileName, FileMode.Append, FileAccess.Write,
                                                  FileShare.Write, 1024, FileOptions.Asynchronous))
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(message + "\r\n");
                IAsyncResult writeResult = fs.BeginWrite(buffer, 0, buffer.Length,
                    (asyncResult) =>
                    {

                        var fStream = (FileStream)asyncResult.AsyncState;
                        fStream.EndWrite(asyncResult);
                    },

                    fs);
                fs.Close();
            }
        }
    }
}
