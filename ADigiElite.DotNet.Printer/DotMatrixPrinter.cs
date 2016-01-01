using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADigiElite.DotNet.Printer
{
    public class DotMatrixPrinter
    {
       

        [NonSerialized]
        private string printBuffer;

        public string PrinterName { get; set; }
        public string FontSizeChar { get; set; }
        public string LineHeightChar { get; set; } 
        public string PageBreakChar { get; set; }
        public string BoldStartChar { get; set; }
        public string BoldEndChar { get; set; }

        public string PrintBuffer
        {
            get
            {
                return printBuffer;
            }

            set
            {
                printBuffer = value;
            }
        }

        public void ResetToDefault()
        {
            this.PrinterName = "LPT1";
            this.FontSizeChar = '\x1B' + "P";
            this.LineHeightChar = '\x1B' + "3" + ((char)35).ToString();
            this.PageBreakChar = '\x0C' + "";
            this.BoldStartChar = '\x1B' + "E";
            this.BoldEndChar = '\x1B' + "F";
        }

        public void SaveConfig()
        {

        }

        public void LoadConfig()
        {
            ResetToDefault();
        }

        public void Print()
        {
            Print(PrintBuffer);
        }

        public void Print(string printBuffer)
        {
            Print(printBuffer, PrinterName);
        }

        public void Print(string printBuffer,string printer)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = string.Format("/C echo {0} > {1}", printBuffer, printer);
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public void PrintFile(string filefullname)
        {
            PrintFile(filefullname, PrinterName);
        }
        public void PrintFile(string filefullname, string printer)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = string.Format("/C type {0} > {1}", filefullname, printer);
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }


    }
}
