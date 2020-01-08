using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class LoggerHelper
{
    private static readonly object obj = new object();
    /// <summary>
    /// 日志记录
    /// </summary>
    /// <param name="Message">记录信息</param>
    public static void Log_WriteLog(string Message)
    {
        string BusinessName = "短网址";
        string LogPath = "c:\\Log\\ShortUrl";
        Log_WriteLog(Message, BusinessName, LogPath);
    }
    /// <summary>
    /// 日志记录
    /// </summary>
    /// <param name="Message">记录信息</param>
    /// <param name="BusinessName">业务名称</param>
    public static void Log_WriteLog(string Message, string BusinessName)
    {
        string LogPath = "c:\\Log\\ShortUrl";
        Log_WriteLog(Message, BusinessName, LogPath);
    }
    /// <summary>
    /// 日志记录
    /// </summary>
    /// <param name="Message">记录信息</param>
    /// <param name="BusinessName">业务名称</param>
    /// <param name="LogPath">保存路径</param>
    public static void Log_WriteLog(string Message, string BusinessName, string LogPath)
    {
        try
        {
            Monitor.Enter(obj);
            DateTime dt = DateTime.Now;
            string message = "\r\n" + dt.ToString() + ":\r\n" + Message + "\r\n";
            string Ppath = string.Format("{0}\\{1}\\{2}", LogPath, dt.ToString("yyyy-MM-dd"), BusinessName);
            if (!Directory.Exists(Ppath))
            {
                Directory.CreateDirectory(Ppath);
            }

            string AName = string.Format("{0}\\{1}.log", Ppath, dt.Hour);
            using (FileStream myFileStream = new FileStream(AName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] byte_arr = Encoding.Default.GetBytes(message);
                myFileStream.Write(byte_arr, 0, byte_arr.Length);
                myFileStream.Close();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Monitor.Pulse(obj);
            Monitor.Exit(obj);
        }
    }
}

