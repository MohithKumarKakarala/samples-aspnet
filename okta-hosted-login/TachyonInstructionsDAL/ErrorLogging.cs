using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Net;

namespace DXC.Tachyon.TachyonInstructionsDAL
{
    public static class ErrorLogging
    {
        private static string sLogFormat;
        private static string sErrorTime;

        /// <summary>
        /// Logs the application information to a log and appends additional information
        /// </summary>
        /// <param name="sErrMsg"></param>
        /// <param name="iMessageType"></param>
        /* Write to Txt Log File*/
        public static void WriteToLogFile(string sErrMsg, int iMessageType)
        {
            try
            {
                //sLogFormat used to create log format :  
                // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message  
                if (iMessageType == 0)
                    sLogFormat = "MESSAGE: " + DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
                else if (iMessageType == 1)
                    sLogFormat = "WARNING: " + DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
                else if (iMessageType == 2)
                    sLogFormat = "ERROR: " + DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

                //this variable used to create log filename format "  
                //for example filename : ErrorLogYYYYMMDD  
                string sYear = DateTime.Now.Year.ToString();
                string sMonth = DateTime.Now.Month.ToString();
                string sDay = DateTime.Now.Day.ToString();
                sErrorTime = sYear + sMonth + sDay;

                //writing to log file  
                
                string sPathName = HttpContext.Current.Server.MapPath(@"~\ErrorLogs\ErrorLog");// .Url.LocalPath  "~\\ErrorLogs\\ErrorLog" + sErrorTime;
                StreamWriter sw = new StreamWriter(sPathName + ".txt", true);
                sw.WriteLine(sLogFormat + sErrMsg);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                //WriteToEventLog("TachyonExplorer", "Logging.WriteToLogFile", "Error: " + ex.ToString(), EventLogEntryType.Error);
                WriteToEventLog("TachyonExplorer", "Log manager", "Error while accessing or creating text file. " + ex.Message, EventLogEntryType.Error);
                throw new FileLoadException("Exception while logging error messages " + ex.Message);
            }
        }

        /// <summary>
        /// Writes error information to system event viewer
        /// </summary>
        /// <param name="sLog"></param>
        /// <param name="sSource"></param>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public static void WriteToEventLog(string sLog, string sSource, string message, EventLogEntryType level)
        {
            if (!System.Diagnostics.EventLog.SourceExists(sSource)) EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, message, level);
        }
    }
}
