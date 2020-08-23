using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

namespace AeonLabs.CrashAndDiagnostics
{
    static class CrashDataLib
    {
        public static bool saveCrash(Exception e)
        {
            var state = new environmentVars(LOAD_SETTINGS);
            if (state.SendDiagnosticData.Equals(false))
            {
                return true;
            }

            var trace = new StackTrace(e, true);
            string line = Strings.Right(trace.ToString(), 5);
            int Xcont = 0;
            string report = e.Message.ToString().Replace("'", "") + Environment.NewLine;
            report += "--------- Stack trace ---------" + Environment.NewLine;
            report += "----------" + DateTime.Now.ToString() + "----------" + Environment.NewLine;
            report += "----------OS version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString + "----------" + Environment.NewLine;
            report += "    Error Line:" + Strings.Right(trace.ToString(), 5) + Environment.NewLine;
            report += "-------------------------------" + Environment.NewLine;
            report += "--------- Cause ---------" + Environment.NewLine;
            foreach (StackFrame sf in trace.GetFrames())
            {
                Xcont = Xcont + 1;
                report += Xcont + "- " + sf.GetMethod().ReflectedType.ToString().Replace("'", "") + " " + sf.GetMethod().Name.Replace("'", "") + Environment.NewLine;
            }

            report += "-------------end report---------------" + Environment.NewLine;


            Single start;
            start = Conversions.ToSingle(DateAndTime.Timer);
            try
            {
                System.IO.StreamWriter file;
                file = Computer.FileSystem.OpenTextFileWriter(Path.Combine(string.Format(@"{0}\", Environment.CurrentDirectory), "crash.log"), true);
                file.WriteLine(report + Environment.NewLine);
                file.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}