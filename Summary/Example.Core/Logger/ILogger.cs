using System;
using System.Collections.Generic;

namespace Example.Logging
{
    public partial interface ILogger
    {
        void Debug(string message);
        void Trace(string message);
        /// <summary>
        /// 普通信息
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// 警告信息
        /// </summary>
        /// <param name="message"></param>
        void Warn(string message);

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void Error(string message, Exception e);

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="e"></param>
        void Error(Exception e);

        /// <summary>
        /// 致命错误信息
        /// </summary>
        /// <param name="message"></param>
        void Fatal(string message, Exception e);

        /// <summary>
        /// 致命错误信息
        /// </summary>
        /// <param name="x"></param>
        void Fatal(Exception e);
    }
}
